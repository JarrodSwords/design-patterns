namespace DesignPatterns.Sandbox.StatePattern;

public class McahpsState : State
{
    public override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args, IFieldingCountsRepository repo)
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return repo.GetSurveyIds(cahpsTypeId, sampleYear, projectId);
    }

    public override WaveTypeQuantity GetUndeliverableCount(
        CahpsDataRequestParameters args,
        IFieldingCountsRepository repo
    )
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return repo.GetUndeliverableCount(cahpsTypeId, sampleYear, projectId);
    }

    public override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (string.IsNullOrWhiteSpace(args.ProjectId))
            throw new FieldingCountsDataException("Requests for MCahps must include a Project Id");
    }
}
