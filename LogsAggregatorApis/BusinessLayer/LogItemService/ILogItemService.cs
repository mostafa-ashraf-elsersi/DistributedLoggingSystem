using LogsAggregatorApis.DatabaseLayer.Entities;
using LogsAggregatorApis.HelperTypes.Dtos;
using LogsAggregatorApis.HelperTypes.General;
using System.Text.Json;

namespace LogsAggregatorApis.BusinessLayer.LogItemService
{
    public interface ILogItemService
    {
        Task<GenericApiResponse<List<LogItemDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<GenericApiResponse<LogItemDto>> GetAsync(string id, CancellationToken cancellationToken = default);

        Task<GenericApiResponse<List<LogItemDto>>> CreateRangeAsync(JsonElement newEntitiesList, CancellationToken cancellationToken = default);
    }
}
