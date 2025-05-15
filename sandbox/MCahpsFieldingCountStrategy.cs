namespace DesignPatterns.Sandbox;

public class MCahpsFieldingCountStrategy : IFieldingCountStrategy
{
    private readonly IFieldingCountsRepository _repo;

    public MCahpsFieldingCountStrategy(IFieldingCountsRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args) =>
        _repo.GetSurveyIds(args.CahpsTypeId, args.SampleYear, args.ProjectId);

    public WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args) =>
        _repo.GetUndeliverableCount(args.CahpsTypeId, args.SampleYear, args.ProjectId);
}
