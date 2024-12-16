using System.Net;

namespace LogsAggregatorApis.HelperTypes.General
{
    public sealed record GenericApiResponse<T>(HttpStatusCode StatusCode,
                                               T? Data);
}
