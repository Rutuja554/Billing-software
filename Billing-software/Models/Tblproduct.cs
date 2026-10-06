using System;
using System.Collections.Generic;

namespace Billing_software.Models;

public partial class Tblproduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? Rate { get; set; }

    public double? Gst { get; set; }

    public double? StockQuantity { get; set; }

    public virtual ICollection<Tblinvoiceproduct> Tblinvoiceproducts { get; set; } = new List<Tblinvoiceproduct>();
}
