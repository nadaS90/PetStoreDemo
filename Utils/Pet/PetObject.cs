using FluentAssertions;
using PetStoreDemo.dto;
using System;
using System.Collections.Generic;
using System.Net;
using System;
using PetStoreDemo.Dto.Response;
using System.Linq;
using PetStoreDemo.Helpers;
using PetStoreDemo.Requests.Pet;
using PetStoreDemo.dto.Pet;

namespace PetStoreDemo.Utils.Pet
{
    public class PetObject
    { 
        public int? Id { get; set; }
        public PetCategoryDto Category { get; set; }
        public string Name { get; set; }
        public IList<string> PhotoUrls { get; set; }
        public IList<TagDto> Tags { get; set; }
        public string Status { get; set; }

        public PetObject()
        {
            var defaultPet = TestDataReader.Read<PetDto>("DefaultPet");
            Id = defaultPet.Id;
            Category = defaultPet.Category;
            Name = defaultPet.Name;
            PhotoUrls = defaultPet.PhotoUrls;
            Tags = defaultPet.Tags;
            Status = defaultPet.Status;
        }

        public PetObject GetDeafult()
        {
            var defaultPet = TestDataReader.Read<PetDto>("DefaultPet");
            Id = defaultPet.Id;
            Category = defaultPet.Category;
            Name = defaultPet.Name;
            PhotoUrls = defaultPet.PhotoUrls;
            Tags = defaultPet.Tags;
            Status = defaultPet.Status;
            return this;
        }

        public PetObject SetPetData(string name, string status = "active")
        {
            Name = name;
            Status = status;
            return this;
        }

        public PetObject SetCategory(string name, int? id = null)
        {
            Category.Name = name;
            Category.Id = id;
            return this;
        }

        public PetObject AddTag(string name, int? id = null)
        {
            Tags.Add(new TagDto
            {
                Name = name,
                Id = id
            });
            return this;
        }

        public PetObject AddPhotoUrl(string url)
        {
            PhotoUrls.Add(url);
            return this;
        }

        public PetObject Create(int? id = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Id = id;
            var response = RequestsPet.CreatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Get(HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
            var response = RequestsPet.GetPetById(Id.GetValueOrDefault(), statusCode).Deserialize<ApiResponseDto>();
            if (statusCode != HttpStatusCode.OK)
            {
                response.Message.Should().Be(errorMessage);
            }
            return this;
        }

        public PetObject Update(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = RequestsPet.UpdatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            RequestsPet.DeletePet(Id.GetValueOrDefault(), statusCode);
            return this;
        }
    }
}
