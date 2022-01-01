using System;

namespace DesignPatterns.Builder2.Read
{
    public record Customer(
        Guid Id,
        string Email,
        string Name,
        string RecordName
    )
    {
        public static Customer Jon = new(Guid.NewGuid(), "jon.doe@gmail.com", "Jon", "CUST001");
    }
}
