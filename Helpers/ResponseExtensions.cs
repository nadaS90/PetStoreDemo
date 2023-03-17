using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDemo.Helpers
{
    public static class ResponseExtensions
    {
        public static T Deserialize<T>(this RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static T Deserialize<T>(this RestResponse response, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, settings);
        }

        public static JObject Deserialize(this RestResponse response)
        {
            return JsonConvert.DeserializeObject<JObject>(response.Content);
        }

        public static object Deserialize(this RestResponse response, Type type)
        {
            return JsonConvert.DeserializeObject(response.Content, type);
        }
    }
}
