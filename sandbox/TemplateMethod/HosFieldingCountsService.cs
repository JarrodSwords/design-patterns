namespace DesignPatterns.Sandbox.TemplateMethod;

public class HosFieldingCountsService : FieldingCountsService
{
    public HosFieldingCountsService(
        IInfoTurnUnitOfWorkFactory infoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider sldProvider,
        IFieldingCountsRepository repo,
        ISldRepository sldRepo
    ) : base(infoTurnUnitOfWorkFactory, sldProvider, repo, sldRepo)
    {
    }

    protected override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return Repo.GetSurveyIds(clientId, cahpsTypeId, sampleYear, designator);
    }

    protected override WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, clientId, _, designator, sampleYear) = args;
        return Repo.GetUndeliverableCount(clientId, cahpsTypeId, sampleYear, designator);
    }

    protected override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (!args.ClientId.HasValue)
            throw new FieldingCountsDataException("Requests for Hos must include a Client Id");
    }
}
