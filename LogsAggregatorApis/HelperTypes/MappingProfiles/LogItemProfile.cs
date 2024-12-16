using AutoMapper;
using LogsAggregatorApis.DatabaseLayer.Entities;
using LogsAggregatorApis.HelperTypes.Dtos;

namespace LogsAggregatorApis.HelperTypes.MappingProfiles
{
    public class LogItemProfile : Profile
    {
        public LogItemProfile()
        {
            CreateMap<LogItem, LogItemDto>();
        }
    }
}
