namespace DesignPatterns.Sandbox.TemplateMethod;

public class FieldingCountsServiceFactory
{
    private readonly Dictionary<int, Func<
        IInfoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider,
        IFieldingCountsRepository,
        ISldRepository,
        FieldingCountsService>> _createService = new()
    {
        { 13, (i, p, r, s) => new McahpsFieldingCountsService(i, p, r, s) },
        { 15, (i, p, r, s) => new QhpFieldingCountsService(i, p, r, s) },
        { 16, (i, p, r, s) => new HosFieldingCountsService(i, p, r, s) }
    };

    private readonly IInfoTurnUnitOfWorkFactory _infoTurnUnitOfWorkFactory;
    private readonly IFieldingCountsRepository _repo;
    private readonly SldUnitOfWorkProvider _sldProvider;
    private readonly ISldRepository _sldRepo;

    public FieldingCountsServiceFactory(
        IFieldingCountsRepository repo,
        IInfoTurnUnitOfWorkFactory infoTurnUnitOfWorkFactory,
        SldUnitOfWorkProvider sldProvider,
        ISldRepository sldRepo
    )
    {
        _repo = repo;
        _infoTurnUnitOfWorkFactory = infoTurnUnitOfWorkFactory;
        _sldProvider = sldProvider;
        _sldRepo = sldRepo;
    }

    public FieldingCountsService Create(int cahpsTypeId) =>
        _createService[cahpsTypeId](_infoTurnUnitOfWorkFactory, _sldProvider, _repo, _sldRepo);
}
