using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Compass.Net.Client.Exceptions;
using Newtonsoft.Json;

namespace Compass.Net.Client.Shared
{
    public class CompassRestClient
    {
        public static async Task<T> SendRequestAsync<T>(Uri uri, object payload)
        {
            var httpClient = GetHttpClient();
            string resultString = await SendRequest(uri.ToString(), payload, httpClient);
            return string.IsNullOrWhiteSpace(resultString) ? default(T) : JsonConvert.DeserializeObject<T>(resultString);
        }

        private static async Task<string> SendRequest(string url, object payload, HttpClient httpClient)
        {
            // format payload to json
            var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, httpContent);

            // Validate the request succeeded.
            if (response.StatusCode != HttpStatusCode.OK) throw new CompassClientException("Request did not succeed");

            var resultString = await response.Content.ReadAsStringAsync();
            return resultString;
        }

        private static HttpClient GetHttpClient()
        {
            // initialize rest client
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
