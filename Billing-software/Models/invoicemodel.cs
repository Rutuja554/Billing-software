namespace Billing_software.Models
{
    public class invoicemodel
    {
        public int InvoiceId { get; set; } 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }
        public float TotalAmount { get; set; }
        public float PaidAmount { get; set; }

        public float RemainigAmount { get; set; }

        public string Status { get; set; }
      


    }
}
