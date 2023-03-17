using PetStoreDemo.dto.Pet;
using PetStoreDemo.Utils.Pet;
using RestSharp;
using System;
using PetStoreDemo.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using PetStoreDemo.Helpers;
using FluentAssertions;

namespace PetStoreDemo.Requests.Pet
{
    public static class RequestsPet
    {
        private static RestClient client;
        private static RestClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new RestClient(ConfigurationProvider.CurrentEnviroment.Url);
                }
                return client;
            }
        }

        public static RestResponse GetPetById(long petId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.GetByPetId.AddUrlSegment("petId", petId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreatePet(PetDto petDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.CreatePet.AddJsonBody(petDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse CreatePet(PetObject petObject, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.CreatePet.AddJsonBody(petObject);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse UpdatePet(PetDto petDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.CreatePet.AddJsonBody(petDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse UpdatePet(PetObject petObject, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.UpdatePet.AddJsonBody(petObject);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }

        public static RestResponse DeletePet(long petId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = EndpointsPet.DeletePet.AddUrlSegment("petId", petId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return response;
        }
    }
}