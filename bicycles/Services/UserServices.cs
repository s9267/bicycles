using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using bicycles.Models;
using Newtonsoft.Json;

namespace bicycles.Services
{
    public class UserServices
    {

        private HttpClient httpClient;

        public UserServices()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://jsonplaceholder.typicode.com/users/")
            };
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var response = await httpClient.GetAsync(string.Empty);

            CheckStatusCode(response.StatusCode);

            return await DeserializeResponse<IEnumerable<User>>(response);
        }

        private async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private static void CheckStatusCode(HttpStatusCode statusCode)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unexpected status code: {statusCode}");
            }
        }
    }
}
