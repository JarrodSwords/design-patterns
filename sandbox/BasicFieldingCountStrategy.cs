namespace DesignPatterns.Sandbox;

public class BasicFieldingCountStrategy : IFieldingCountStrategy
{
    private readonly IFieldingCountsRepository _repo;

    public BasicFieldingCountStrategy(IFieldingCountsRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return _repo.GetSurveyIds(clientId, cahpsTypeId, sampleYear, designator);
    }

    public WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return _repo.GetUndeliverableCount(clientId, cahpsTypeId, sampleYear, designator);
    }
}
