namespace DesignPatterns.Sandbox.StatePattern;

public class QhpState : State
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
        if (!args.ClientId.HasValue || args.Designator is null)
            throw new FieldingCountsDataException("Requests for Qhp must include a Client Id and Designator");
    }
}
