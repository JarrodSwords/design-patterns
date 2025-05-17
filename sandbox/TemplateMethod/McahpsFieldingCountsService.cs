namespace DesignPatterns.Sandbox.TemplateMethod;

public class McahpsFieldingCountsService : FieldingCountsService
{
    public McahpsFieldingCountsService(
        IInfoTurnUnitOfWorkFactory infoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider sldProvider,
        IFieldingCountsRepository repo,
        ISldRepository sldRepo
    ) : base(infoTurnUnitOfWorkFactory, sldProvider, repo, sldRepo)
    {
    }

    protected override IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return Repo.GetSurveyIds(cahpsTypeId, sampleYear, projectId);
    }

    protected override WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args)
    {
        var (cahpsTypeId, _, projectId, _, sampleYear) = args;
        return Repo.GetUndeliverableCount(cahpsTypeId, sampleYear, projectId);
    }

    protected override void ValidateArgs(CahpsDataRequestParameters args)
    {
        if (string.IsNullOrWhiteSpace(args.ProjectId))
            throw new FieldingCountsDataException("Requests for MCahps must include a Project Id");
    }
}
