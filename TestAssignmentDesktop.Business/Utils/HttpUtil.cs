using Newtonsoft.Json;
using System.Text;

namespace TestAssignmentDesktop.Business.HttpUtils
{
    public class HttpUtil : IHttpUtil
    {
        private readonly HttpClient _client;

        private static HttpUtil _instance;

        private HttpUtil()
        {
            _client = new HttpClient();
        }

        public static HttpUtil GetInstance()
        {
            if(_instance == null)
            {
                _instance = new HttpUtil();
            }
            return _instance;
        }


        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage httpResponse = await _client.SendAsync(requestMessage);

            return httpResponse;
        }

        public async Task<HttpResponseMessage> PatchAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), url);

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> PostJsonAsync<T>(string url, T postData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> PutJsonAsync<T>(string url, T postData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;
        }

        public bool IsSuccessfulStatusCode(HttpResponseMessage httpResponse)
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
