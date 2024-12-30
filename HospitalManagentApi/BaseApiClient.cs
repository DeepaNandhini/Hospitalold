using Newtonsoft.Json;
using System.Text;
namespace HospitalManagentApi
{
    public class BaseApiClient:IBaseApiClient
    {
        private HttpClient _httpClient;
        public BaseApiClient(IHttpClientFactory httpClientFactory)
        {

            _httpClient = httpClientFactory.CreateClient("TestClient");

        }
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default(T);
        }

        public async Task<TResponse> PostAsync<TRequest,TResponse>(string url,TRequest body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(data);
            }
            return default(TResponse);
        }

        
    }

    public interface IBaseApiClient
    {
        Task<T> GetAsync<T>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest body);
    }
}
