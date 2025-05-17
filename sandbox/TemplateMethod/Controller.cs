namespace DesignPatterns.Sandbox.TemplateMethod;

public class Controller
{
    private readonly FieldingCountsServiceFactory _fact;

    public Controller(FieldingCountsServiceFactory fact)
    {
        _fact = fact;
    }

    public AdministrationStatusFieldingData GetAdminStatusFieldingData(CahpsDataRequestParameters args)
    {
        var service = _fact.Create(args.CahpsTypeId);
        return service.GetAdminStatusFieldingData(args);
    }
}
