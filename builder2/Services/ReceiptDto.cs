using System.Collections.Generic;

namespace DesignPatterns.Builder2.Services
{
    public record ReceiptDto(
        string CustomerId,
        List<ReceiptDto.LineItemDto> LineItems,
        decimal Total
    )
    {
        public record LineItemDto(
            decimal Price,
            string ProductName,
            ushort Quantity
        );
    }
}
