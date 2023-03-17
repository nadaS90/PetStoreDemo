using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStoreDemo.Configuration;

namespace PetStoreDemo.Requests.Pet
{
    public static class EndpointsPet
    {
        public static RestRequest GetByPetId => new RestRequest(ConfigurationProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.Get);
        public static RestRequest CreatePet => new RestRequest(ConfigurationProvider.CurrentEnviroment.Url + "/pet", Method.Post);
        public static RestRequest UpdatePet => new RestRequest(ConfigurationProvider.CurrentEnviroment.Url + "/pet", Method.Put);
        public static RestRequest DeletePet => new RestRequest(ConfigurationProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.Delete);

    }
}
