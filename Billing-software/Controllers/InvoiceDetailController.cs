using Microsoft.AspNetCore.Mvc;
using Billing_software.Models;
using Billing_software.Services;
using Billing_software.Services.Product;
using Billing_software.Services.Invoices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Billing_software.Controllers
{
    public class InvoiceDetailController : Controller
    {
        ICustomer customer;
        IProduct product;
        IInvoice invoice;

        public InvoiceDetailController(ICustomer customer,IProduct product,IInvoice invoice)
        {
            this.customer = customer;
            this.product = product;
            this.invoice = invoice;

        }



        public IActionResult Index()
        {
            List<invoicemodel> lst = invoice.GetAllInvoice();

            return View(lst);
        }

        [HttpGet]
        public IActionResult NewInvoice()
        {
            List<Tblcustomer> c = customer.GetAllCustomer();
            ViewBag.customers = new SelectList(c, "CustomerId", "CustomerName");
            List<Tblproduct> p = product.GetAllProduct();
            ViewBag.products = new SelectList(p,"ProductId", "ProductName");

            return View();
        }

        [HttpPost]
        public string GenerateInvoice([FromBody]Tblinvoicedetail d)
        {
            invoice.AddNewInvoice(d);
            return "Invoice Generated Successfully";
        }

        
        public IActionResult PayInvoice(int id)
        {
            invoicemodel m = invoice.GetInvoiceById(id);
            Tblinvoicepayment p = new Tblinvoicepayment() { InvoiceId = m.InvoiceId };
            ViewData["invoice"] = m;
            return View(p);
        }

        [HttpPost]
        public IActionResult PayInvoice(Tblinvoicepayment pay)
        {
            invoice.AddInvoicePayment(pay);
            ModelState.Clear();
            ViewBag.msg = "Payment Accepted Successfully";
            invoicemodel m = invoice.GetInvoiceById((int)pay.InvoiceId);

            Tblinvoicepayment p = new Tblinvoicepayment() { InvoiceId = m.InvoiceId };
            ViewData["invoice"] = m;
            return View(p);
        }

        public IActionResult ViewInvoice(int id)
        {
            Tblinvoicedetail d = invoice.GetInvoiceData(id);
            return View(d);
        }
    }
}
