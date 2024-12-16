using LogsAggregatorApis.BusinessLayer.LogItemService;
using LogsAggregatorApis.DatabaseLayer.Entities;
using LogsAggregatorApis.HelperTypes.Dtos;
using LogsAggregatorApis.HelperTypes.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LogsAggregatorApis.PresentationLayer
{
    [Route("api/log-items")]
    [ApiController]
    public class LogItemController : ControllerBase
    {
        private ILogItemService _logItemService;

        public LogItemController(ILogItemService logItemService) => _logItemService = logItemService;


        [HttpGet]
        public async Task<GenericApiResponse<List<LogItemDto>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _logItemService.GetAllAsync(cancellationToken);

        [HttpGet("{id}")]
        public async Task<GenericApiResponse<LogItemDto>> GetAsync(string id, CancellationToken cancellationToken = default) =>
            await _logItemService.GetAsync(id, cancellationToken);

        [HttpPost]
        public async Task<GenericApiResponse<List<LogItemDto>>> CreateRangeAsync(JsonElement newEntitiesList, CancellationToken cancellationToken = default) =>
            await _logItemService.CreateRangeAsync(newEntitiesList, cancellationToken);
    }
}
