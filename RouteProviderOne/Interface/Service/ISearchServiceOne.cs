using TestTask;

namespace RouteProviderOne.Interface.Service
{
    public interface ISearchServiceOne
    {
        Task<ProviderOneSearchResponse> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken);

        Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
    }
}
