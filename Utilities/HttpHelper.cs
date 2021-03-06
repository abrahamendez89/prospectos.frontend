using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace utilities
{
    public class Httphelper
    {
        public Uri BaseURI { get; set; }

        public async Task<T> Get<T>(string path, String token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //GET Method
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                throw new Exception("Http error [GET("+ path + ")]: " + response.StatusCode.ToString());

            }
        }
        public async Task<T> Post<T, U>(string path, U bodyJson, String token = "")
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = this.BaseURI;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.PostAsJsonAsync(path, bodyJson);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                throw new Exception("Http error [POST(" + path + ")]: " + response.StatusCode.ToString());

            }
        }
    }
}
