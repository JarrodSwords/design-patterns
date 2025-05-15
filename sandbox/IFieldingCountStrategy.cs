namespace DesignPatterns.Sandbox;

public interface IFieldingCountStrategy
{
    IEnumerable<long> GetSurveyIds(CahpsDataRequestParameters args);
    WaveTypeQuantity GetUndeliverableCount(CahpsDataRequestParameters args);
}
