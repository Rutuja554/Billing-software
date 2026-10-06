using System;
using System.Collections.Generic;

namespace Billing_software.Models;

public partial class Tblinvoicepayment
{
    public int PaymentId { get; set; }

    public int InvoiceId { get; set; }

    public DateTime PaymentDate { get; set; }

    public double PaymentAmt { get; set; }

    public string PaymentMode { get; set; } = null!;

    public string PaymentDescription { get; set; } = null!;

    public virtual Tblinvoicedetail Invoice { get; set; } = null!;
}
