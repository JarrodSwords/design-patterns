namespace DesignPatterns.Sandbox.StatePattern;

public class FieldingCountsService : IFieldingCountsService
{
    private readonly IInfoTurnUnitOfWorkFactory _infoTurnUnitOfWorkFactory;
    private readonly IFieldingCountsRepository _repo;
    private readonly SldUnitOfWorkProvider _sldProvider;
    private readonly ISldRepository _sldRepo;
    private State _state;

    public FieldingCountsService(
        IInfoTurnUnitOfWorkFactory infoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider sldProvider,
        IFieldingCountsRepository repo,
        ISldRepository sldRepo
    )
    {
        _infoTurnUnitOfWorkFactory = infoTurnUnitOfWorkFactory;
        _sldProvider = sldProvider;
        _repo = repo;
        _sldRepo = sldRepo;
    }

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

    public IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args) => _state.GetSurveyIds(args, _repo);

    public WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args) =>
        _state.GetUndeliverableCount(args, _repo);

    public AdministrationStatusFieldingData GetAdminStatusFieldingData(CahpsDataRequestParameters args)
    {
        _state
            .ChangeState(args.CahpsTypeId)
            .ValidateArgs(args);

        return new AdministrationStatusFieldingData
        {
            ClientId = args.ClientId.Value,
            Designator = args.Designator,
            SampleYear = args.SampleYear,
            CahpsTypeId = args.CahpsTypeId,
            AdministrationStatus = BuildAdminStatusFieldingCount(args)
        };
    }
}
