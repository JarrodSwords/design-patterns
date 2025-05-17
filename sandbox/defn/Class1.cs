namespace DesignPatterns.Sandbox.defn;

public class PayerAdministrationDefn
{
    public int WaveId { get; set; }
    public int? DaysFromWaveOneMailedDay { get; set; }
    public int? TotalAdminDays { get; set; }
    public string WaveDescription { get; set; }
    public string WaveType { get; set; }

    /// <remarks>Factory method</remarks>
    public WaveFieldingCount Create(DateTime? wave1MailedDate, int waveQuantity = 0)
    {
        if (!DaysFromWaveOneMailedDay.HasValue || !TotalAdminDays.HasValue)
            throw new FieldingCountsDataException("whatever");

        return new WaveFieldingCount(
            WaveType,
            WaveDescription,
            GetStartDate(wave1MailedDate),
            GetEndDate(wave1MailedDate),
            waveQuantity
        );
    }

    public DateTime? GetEndDate(DateTime? wave1MailedDate) => wave1MailedDate.Value.AddDays(TotalAdminDays.Value);

    public DateTime? GetStartDate(DateTime? wave1MailedDate) =>
        wave1MailedDate.Value.AddDays(DaysFromWaveOneMailedDay.Value);
}

public class WaveQuantity
{
    public int WaveId { get; set; }
    public int Quantity { get; set; }
}

public class WaveFieldingCount
{
    public WaveFieldingCount()
    {
    }

    public WaveFieldingCount(
        string mode,
        string description,
        DateTime? startDate,
        DateTime? endDate,
        long quantity
    )
    {
        Description = description;
        EndDate = endDate;
        Mode = mode;
        Quantity = quantity;
        StartDate = startDate;
    }

    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public string Mode { get; set; }
    public long Quantity { get; set; }
    public DateTime? StartDate { get; set; }
}

public class FooService
{
    private readonly Builder _builder = new();

    public IEnumerable<WaveFieldingCount> Bar2(
        IEnumerable<PayerAdministrationDefn> admindefns,
        IEnumerable<WaveQuantity> waveCounts
    )
    {
        var wave1MailedDate = new DateTime?(new DateTime(1, 1, 2000));

        _builder
            .With(wave1MailedDate)
            .With(waveCounts);

        admindefns.Select(_builder.Add);

        return _builder.GetWaveFieldingCounts();
    }
}

public class Builder
{
    private readonly List<WaveFieldingCount> _fieldingCounts = new();
    private DateTime? _wave1MailedDate;
    private Dictionary<int, int> _waveCounts;

    public Builder Add(PayerAdministrationDefn defn)
    {
        _fieldingCounts.Add(defn.Create(_wave1MailedDate, _waveCounts[defn.WaveId]));
        return this;
    }

    public IEnumerable<WaveFieldingCount> GetWaveFieldingCounts() => _fieldingCounts;

    public Builder With(IEnumerable<WaveQuantity> waveCounts)
    {
        _waveCounts = waveCounts.ToDictionary(x => x.WaveId, x => x.Quantity);
        return this;
    }

    public Builder With(DateTime? wave1MailedDate)
    {
        _wave1MailedDate = wave1MailedDate;
        return this;
    }
}
