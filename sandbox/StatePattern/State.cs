namespace DesignPatterns.Sandbox.StatePattern;

public abstract class State
{
    private static readonly Dictionary<int, Func<State>> _createState = new()
    {
        { 13, () => new McahpsState() },
        { 15, () => new QhpState() },
        { 16, () => new HosState() }
    };

    public State ChangeState(int cahpsTypeId) => _createState[cahpsTypeId]();

    public abstract IEnumerable<long> GetSurveyIds(
        CahpsDataRequestParameters args,
        IFieldingCountsRepository repo
    );

    public abstract WaveTypeQuantity GetUndeliverableCount(
        CahpsDataRequestParameters args,
        IFieldingCountsRepository repo
    );

    public abstract void ValidateArgs(CahpsDataRequestParameters args);
}
