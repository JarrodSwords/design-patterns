namespace DesignPatterns.Sandbox;

public class AdministrationStatusFieldingCount
{
    public int RawEmailCount { get; set; }
    public int RawMailCount { get; set; }
    public int RawPhoneCount { get; set; }
    public int Undeliverable { get; set; }

    public static AdministrationStatusFieldingCount operator +(
        AdministrationStatusFieldingCount source,
        WaveTypeQuantity wtq
    )
    {
        switch (wtq.WaveType)
        {
            case WaveType.Email:
                source.RawEmailCount += wtq.Quantity;
                break;
            case WaveType.Mail:
                source.RawMailCount += wtq.Quantity;
                break;
            case WaveType.Phone:
                source.RawPhoneCount += wtq.Quantity;
                break;
        }

        return source;
    }
}

public class WaveTypeQuantity
{
    public int Quantity { get; set; }
    public WaveType WaveType { get; set; }
    public string WaveTypeString { get; set; }
}
