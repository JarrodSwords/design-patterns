namespace DesignPatterns.Sandbox.TemplateMethod;

public abstract class FieldingCountsService
{
    protected readonly IFieldingCountsRepository Repo;
    private readonly IInfoTurnUnitOfWorkFactory _infoTurnUnitOfWorkFactory;
    private readonly SldUnitOfWorkProvider _sldProvider;
    private readonly ISldRepository _sldRepo;

    protected FieldingCountsService(
        IInfoTurnUnitOfWorkFactory infoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider sldProvider,
        IFieldingCountsRepository repo,
        ISldRepository sldRepo
    )
    {
        _infoTurnUnitOfWorkFactory = infoTurnUnitOfWorkFactory;
        _sldProvider = sldProvider;
        Repo = repo;
        _sldRepo = sldRepo;
    }

    /// <remarks>This is a template method because it contains some deferred steps.</remarks>
    public AdministrationStatusFieldingCount BuildAdminStatusFieldingCount(CahpsDataRequestParameters args)
    {
        using (_infoTurnUnitOfWorkFactory.StartUnitOfWork())
        using (_sldProvider.StartUnitOfWork(args.CahpsTypeId))
        {
            var surveyIds = GetSurveyIds(args);
            var administrationStatusFieldingCount = _sldRepo.GetRawFieldingCount(surveyIds);
            administrationStatusFieldingCount.Undeliverable = GetUndeliverableCount(args).Quantity;

            return administrationStatusFieldingCount;
        }
    }

    /// <remarks>This is a template method because it contains some deferred steps.</remarks>
    public AdministrationStatusFieldingData GetAdminStatusFieldingData(CahpsDataRequestParameters args)
    {
        ValidateArgs(args);

        return new AdministrationStatusFieldingData
        {
            ClientId = args.ClientId.Value,
            Designator = args.Designator,
            SampleYear = args.SampleYear,
            CahpsTypeId = args.CahpsTypeId,
            AdministrationStatus = BuildAdminStatusFieldingCount(args)
        };
    }

    protected abstract IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args);
    protected abstract WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args);
    protected abstract void ValidateArgs(CahpsDataRequestParameters args);
}
