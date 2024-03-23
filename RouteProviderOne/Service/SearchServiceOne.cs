using RouteProviderOne.Interface.Service;
using System;
using TestTask;

namespace RouteProviderOne.Service
{
    public class SearchServiceOne : ISearchServiceOne
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchServiceOne(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:7180/api/v1/ping");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProviderOneSearchResponse> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            // создаем JsonContent
            JsonContent content = JsonContent.Create(request);

            // отправляем запрос
            var response = await httpClient.PostAsync($"https://localhost:7180/api/v1/search", content);
            var result = await response.Content.ReadFromJsonAsync<ProviderOneSearchResponse>();

            return result;
        }
    }
}
