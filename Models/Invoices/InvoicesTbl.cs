using System;
using System.Collections.Generic;

namespace RestApiGraphQL.Models.Invoices;

public partial class InvoicesTbl
{
    public long Id { get; set; }

    public string? OrderId { get; set; }

    public DateTime? PlacedOn { get; set; }

    public int? ItemsQty { get; set; }
}
