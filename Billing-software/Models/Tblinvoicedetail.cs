using System;
using System.Collections.Generic;

namespace Billing_software.Models;

public partial class Tblinvoicedetail
{
    public int InvoiceId { get; set; }

    public int CustomerId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public double? TotalAmt { get; set; }

    public virtual Tblcustomer Customer { get; set; } = null!;

    public virtual ICollection<Tblinvoicepayment> Tblinvoicepayments { get; set; } = new List<Tblinvoicepayment>();

    public virtual ICollection<Tblinvoiceproduct> Tblinvoiceproducts { get; set; } = new List<Tblinvoiceproduct>();
}
