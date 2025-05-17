namespace DesignPatterns.Sandbox.TemplateMethod;

public class QhpFieldingCountsService : FieldingCountsService
{
    public QhpFieldingCountsService(
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
        if (!args.ClientId.HasValue || args.Designator is null)
            throw new FieldingCountsDataException("Requests for Qhp must include a Client Id and Designator");
    }
}
