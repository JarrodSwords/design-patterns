namespace DesignPatterns.Sandbox.StatePattern;

public class HosState : State
{
    public override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args, IFieldingCountsRepository repo)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return repo.GetSurveyIds(clientId, cahpsTypeId, sampleYear, designator);
    }

    public override WaveTypeQuantity GetUndeliverableCount(
        CahpsDataRequestParameters args,
        IFieldingCountsRepository repo
    )
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return repo.GetUndeliverableCount(clientId, cahpsTypeId, sampleYear, designator);
    }

    public override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (!args.ClientId.HasValue)
            throw new FieldingCountsDataException("Requests for Hos must include a Client Id");
    }
}
