namespace DesignPatterns.Sandbox;

public interface IFieldingCountsRepository
{
    IEnumerable<long> GetSurveyIds(long? clientId, int cahpsTypeId, int sampleYear, string designator);
    IEnumerable<long> GetSurveyIds(int cahpsTypeId, int sampleYear, string projectId);
    WaveTypeQuantity GetUndeliverableCount(long? clientId, int cahpsTypeId, int sampleYear, string designator);
    WaveTypeQuantity GetUndeliverableCount(int cahpsTypeId, int sampleYear, string projectId);
}
