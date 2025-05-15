namespace DesignPatterns.Sandbox;

public class McahpsState : State
{
    public McahpsState(IFieldingCountsRepository repo) : base(repo)
    {
    }

    public override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return Repo.GetSurveyIds(cahpsTypeId, sampleYear, projectId);
    }

    public override WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return Repo.GetUndeliverableCount(cahpsTypeId, sampleYear, projectId);
    }

    public override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (string.IsNullOrWhiteSpace(args.ProjectId))
            throw new FieldingCountsDataException("Requests for MCahps must include a Project Id");
    }
}
