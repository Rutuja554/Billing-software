using System;
using System.Collections.Generic;

namespace Billing_software.Models;

public partial class Tblcustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNo { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Tblinvoicedetail> Tblinvoicedetails { get; set; } = new List<Tblinvoicedetail>();
}
