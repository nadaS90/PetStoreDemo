using NUnit.Framework;
using RestSharp;
using PetStoreDemo.Configuration;

namespace PetStoreDemo.Base
{
    public class BasePage
    {
        public RestClient client;

        [OneTimeSetUp]
        public void SetUp()
        {
            ConfigurationProvider.LoadConfiguration();
        }
    }
}
