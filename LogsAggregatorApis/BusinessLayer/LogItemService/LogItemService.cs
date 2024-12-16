using AutoMapper;
using LogsAggregatorApis.DataAccessLayer.GenericDbRepositoryAbstraction;
using LogsAggregatorApis.DatabaseLayer.Entities;
using LogsAggregatorApis.HelperTypes.Dtos;
using LogsAggregatorApis.HelperTypes.General;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace LogsAggregatorApis.BusinessLayer.LogItemService
{
    public class LogItemService : ILogItemService
    {
        private readonly IGenericDbRepository<LogItem> _logItemRepository;

        private readonly IMapper _mapper;

        public LogItemService(IGenericDbRepository<LogItem> logItemService, IMapper mapper)
        {
            _logItemRepository = logItemService;
            _mapper = mapper;
        }

        public async Task<GenericApiResponse<List<LogItemDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var logItems = await _logItemRepository.GetAllAsync(cancellationToken);

            var logItemsDtos = _mapper.Map<List<LogItemDto>>(logItems);

            var statusCode = logItemsDtos.Count > 0 ? HttpStatusCode.OK : HttpStatusCode.NotFound;

            return new GenericApiResponse<List<LogItemDto>>(statusCode, logItemsDtos);
        }
            
        public async Task<GenericApiResponse<LogItemDto>> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            var logItem = await _logItemRepository.GetAsync(id, cancellationToken);

            var logItemDto = _mapper.Map<LogItemDto>(logItem);

            var statusCode = logItemDto is not null ? HttpStatusCode.OK : HttpStatusCode.NotFound;

            return new GenericApiResponse<LogItemDto>(statusCode, logItemDto);
        }

        public async Task<GenericApiResponse<List<LogItemDto>>> CreateRangeAsync(JsonElement newEntitiesList, CancellationToken cancellationToken = default)
        {
            var deserializedLogItemsList = JsonSerializer.Deserialize<List<LogItem>>(newEntitiesList) ?? [];

            await _logItemRepository.CreateRangeAsync(deserializedLogItemsList, cancellationToken);

            var statusCode = deserializedLogItemsList.Count > 0 ? HttpStatusCode.NoContent : HttpStatusCode.InternalServerError;

            return new GenericApiResponse<List<LogItemDto>>(statusCode, null);
        }
    }
}
