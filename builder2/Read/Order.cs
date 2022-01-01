using System;
using System.Collections.Generic;

namespace DesignPatterns.Builder2.Read
{
    public record Order(
        Guid Id,
        Customer Customer,
        List<LineItem> LineItems
    );
}
