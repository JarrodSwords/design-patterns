namespace DesignPatterns.Sandbox;

public abstract class State
{
    protected readonly IFieldingCountsRepository Repo;

    private static readonly Dictionary<int, Func<IFieldingCountsRepository, State>> _createState = new()
    {
        { 13, repo => new McahpsState(repo) },
        { 15, repo => new QhpState(repo) },
        { 16, repo => new HosState(repo) }
    };

    protected State(IFieldingCountsRepository repo)
    {
        Repo = repo;
    }

    public State ChangeState(int cahpsTypeId, IFieldingCountsRepository repo) => _createState[cahpsTypeId](repo);

    public abstract IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args);
    public abstract WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args);
    public abstract void ValidateArgs(CahpsDataRequestParameters args);
}
