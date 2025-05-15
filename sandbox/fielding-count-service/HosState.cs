namespace DesignPatterns.Sandbox;

public class HosState : State
{
    public HosState(IFieldingCountsRepository repo) : base(repo)
    {
    }

    public override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return Repo.GetSurveyIds(clientId, cahpsTypeId, sampleYear, designator);
    }

    public override WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return Repo.GetUndeliverableCount(clientId, cahpsTypeId, sampleYear, designator);
    }

    public override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (!args.ClientId.HasValue)
            throw new FieldingCountsDataException("Requests for Hos must include a Client Id");
    }
}
