namespace TestAssignmentDesktop.Business.HttpUtils
{
    public interface IHttpUtil
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> PostJsonAsync<T>(string url, T postData);

        Task<HttpResponseMessage> PutJsonAsync<T>(string url, T postData);

        Task<HttpResponseMessage> DeleteAsync(string url);

        Task<HttpResponseMessage> PatchAsync(string url);

        bool IsSuccessfulStatusCode(HttpResponseMessage httpResponse);
    }
}
