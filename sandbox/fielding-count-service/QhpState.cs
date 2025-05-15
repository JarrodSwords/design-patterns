namespace DesignPatterns.Sandbox;

public class QhpState : State
{
    public QhpState(IFieldingCountsRepository repo) : base(repo)
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
        if (!args.ClientId.HasValue || args.Designator is null)
            throw new FieldingCountsDataException("Requests for Qhp must include a Client Id and Designator");
    }
}
