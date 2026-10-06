using Billing_software.Models;

namespace Billing_software.Services.Invoices
{
    public class Invoice : IInvoice
    {

        InvoicebillingDbContext db;

        public Invoice()
        {
            db = new InvoicebillingDbContext();
        }

        public void AddInvoicePayment(Tblinvoicepayment p)
        {
            db.Tblinvoicepayments.Add(p);
            db.SaveChanges();
        }

        public void AddNewInvoice(Tblinvoicedetail d)
        {
            db.Tblinvoicedetails.Add(d);
            db.SaveChanges();
        }

        public List<invoicemodel> GetAllInvoice()
        {
            List<invoicemodel> lst = new List<invoicemodel>();

            List<Tblinvoicedetail>data = db.Tblinvoicedetails.ToList();

            foreach(Tblinvoicedetail d in data)
            {
                Tblcustomer c = db.Tblcustomers.Find(d.CustomerId);
                float total_amt = 0, paid_amt = 0, remaining = 0;
                total_amt = (float)d.TotalAmt;

                List<Tblinvoicepayment> payments = db.Tblinvoicepayments.ToList().Where(e => e.InvoiceId.Equals(d.InvoiceId)).ToList();

                if(payments != null)
                {
                    paid_amt = (float)payments.Sum(e => e.PaymentAmt);
                }

                remaining = total_amt - paid_amt;

                string status = "";
                if(paid_amt==0)
                {
                    status = "UnPaid";
                }else if(paid_amt>0 && paid_amt<total_amt)
                {
                    status = "Partial Paid";
                }
                else
                {
                    status = "Paid";
                }

                    invoicemodel p = new invoicemodel()
                    {
                        CustomerId = (int)d.CustomerId,
                        InvoiceId = d.InvoiceId,
                        InvoiceDate = d.InvoiceDate,
                        TotalAmount = total_amt,
                        CustomerName = c.CustomerName,
                        RemainigAmount = remaining,
                        PaidAmount = paid_amt,
                        Status=status





                    };
                lst.Add(p);

            }

            return lst;

        }

        public invoicemodel GetInvoiceById(int id)
        {

            return GetAllInvoice().FirstOrDefault(e => e.InvoiceId.Equals(id));
        }

        public Tblinvoicedetail GetInvoiceData(int id)
        {
            Tblinvoicedetail d = db.Tblinvoicedetails.Find(id);
            Tblcustomer c = db.Tblcustomers.Find(d.CustomerId);
            List<Tblinvoiceproduct> products = db.Tblinvoiceproducts.Where(e => e.InvoiceId.Equals(d.InvoiceId)).ToList();
            List<Tblinvoicepayment> payments = db.Tblinvoicepayments.Where(e => e.InvoiceId.Equals(d.InvoiceId)).ToList();

            List<Tblinvoiceproduct> lstproduct = new List<Tblinvoiceproduct>();

            foreach(Tblinvoiceproduct pr in products)
            {
                //Tblinvoiceproduct pro = db.Tblinvoiceproducts.Find(pr.ProductId);
                pr.Product = db.Tblproducts.Find(pr.ProductId);
                lstproduct.Add(pr);
            }
            d.Customer = c;
            d.Tblinvoiceproducts = lstproduct;
            d.Tblinvoicepayments = payments;

            return d;
        }
    }
}
