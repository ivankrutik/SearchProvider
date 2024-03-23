using TestTask;

namespace RouteProviderOne.Interface.Service
{
    public interface ISearchServiceTwo
    {
        Task<ProviderTwoSearchResponse> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken);

        Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
    }
}
