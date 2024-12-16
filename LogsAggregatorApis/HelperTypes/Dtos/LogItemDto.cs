namespace LogsAggregatorApis.HelperTypes.Dtos
{
    public sealed record LogItemDto(DateTime Timestamp,
                                    string ConnectionId,
                                    string MachineName,
                                    string Level,
                                    string Exception,
                                    string RequestPath,
                                    string RequestMethod,
                                    int StatusCode,
                                    double Elapsed);
}
