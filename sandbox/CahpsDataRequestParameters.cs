namespace DesignPatterns.Sandbox;

public class CahpsDataRequestParameters
{
    public CahpsDataRequestParameters(
        long? clientId,
        int cahpsTypeId,
        int sampleYear,
        string designator,
        string projectId
    )
    {
        ClientId = clientId;
        CahpsTypeId = cahpsTypeId;
        SampleYear = sampleYear;
        Designator = designator;
        ProjectId = projectId;
    }

    public void Deconstruct(
        out int cahpsTypeId,
        out long? clientId,
        out string projectId,
        out string designator,
        out int sampleYear
    )
    {
        cahpsTypeId = CahpsTypeId;
        clientId = ClientId;
        projectId = ProjectId;
        designator = Designator;
        sampleYear = SampleYear;
    }

    public int CahpsTypeId { get; }
    public long? ClientId { get; }
    public string ProjectId { get; }
    public string Designator { get; }
    public int SampleYear { get; }
}
