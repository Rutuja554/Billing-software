using System;
using System.Collections.Generic;

namespace Billing_software.Models;

public partial class Tblinvoiceproduct
{
    public int InvoiceProductid { get; set; }

    public int InvoiceId { get; set; }

    public int ProductId { get; set; }

    public double Quantity { get; set; }

    public virtual Tblinvoicedetail Invoice { get; set; } = null!;

    public virtual Tblproduct Product { get; set; } = null!;
}
