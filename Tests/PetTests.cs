using NUnit.Framework;
using PetStoreDemo.Base;
using PetStoreDemo.Requests.Pet;
using PetStoreDemo.Utils.Pet;
using PetStoreDemo.Helpers;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace PetStoreDemo.Tests
{
    [Category("Pet Tests")]
    public class PetTests : BasePage
    {
        PetObject _petObject = new PetObject();
        [TestCase]
        [Order(1)]
        public void CreatePet()
        {
            _petObject.SetPetData("Oreooo");
            _petObject.SetCategory("Persian", 1);
            _petObject.AddPhotoUrl("https://www.shutterstock.com/image-photo/persian-cat-front-white-background-154687202");

            _petObject.Create();
            var createdPet = RequestsPet.GetPetById(_petObject.Id.GetValueOrDefault()).Deserialize<PetObject>();
            createdPet.Name.Should().Be(_petObject.Name);
            createdPet.Id.Should().Be(_petObject.Id.GetValueOrDefault());
        }
        [TestCase]
        [Order(2)]
        public void UpdatePet()
        {
            _petObject.SetPetData("Nada", "unactive");
            _petObject.AddTag("not active pet", 1);

            _petObject.Update();
            var updatedPet = RequestsPet.GetPetById(_petObject.Id.GetValueOrDefault()).Deserialize<PetObject>();
            updatedPet.Name.Should().Be(_petObject.Name);
        }

        [TestCase]
        [Order(3)]
        public void DeletePet()
        {
            _petObject.Delete();
            _petObject.Get(HttpStatusCode.OK, $"{_petObject.Id.GetValueOrDefault()}");
        }

        [TestCase]
        [Order(4)]
        public void GetPetByNotProvidingId()
        {
            _petObject.Id = null;

            _petObject.Get(HttpStatusCode.NotFound, "Pet not found");
        }
    }
}

