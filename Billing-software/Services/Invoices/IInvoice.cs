using Billing_software.Models;

namespace Billing_software.Services.Invoices
{
    public interface IInvoice
    {
        public void AddNewInvoice(Tblinvoicedetail d);

        List<invoicemodel> GetAllInvoice();

        invoicemodel GetInvoiceById(int id);

        void AddInvoicePayment(Tblinvoicepayment p);


        Tblinvoicedetail GetInvoiceData(int id);




    }
}
