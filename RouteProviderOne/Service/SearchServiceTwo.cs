using RouteProviderOne.Interface.Service;
using TestTask;

namespace RouteProvider.Service
{
    public class SearchServiceTwo : ISearchServiceTwo
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchServiceTwo(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            try
            {
                var response = await httpClient.GetAsync($"http://provider-one/api/v2/ping");
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

        public async Task<ProviderTwoSearchResponse> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
