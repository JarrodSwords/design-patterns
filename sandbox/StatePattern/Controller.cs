namespace DesignPatterns.Sandbox.StatePattern;

public class Controller
{
    private readonly IFieldingCountsService _service;

    public Controller(IFieldingCountsService service)
    {
        _service = service;
    }

    public AdministrationStatusFieldingData GetAdminStatusFieldingData(CahpsDataRequestParameters args) =>
        _service.GetAdminStatusFieldingData(args);
}
