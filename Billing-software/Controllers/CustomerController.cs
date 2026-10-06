using Billing_software.Models;
using Billing_software.Services;
using Microsoft.AspNetCore.Mvc;

namespace Billing_software.Controllers
{
    public class CustomerController : Controller
    {
        ICustomer customer;

        public CustomerController(ICustomer customer)
        {
            this.customer = customer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            Tblcustomer customerlst = new Tblcustomer();
            ViewData["customerdata"] = customer.GetAllCustomer();
            ViewBag.btnvalue = "Submit";
            ViewBag.Header = "Add Customer";
            ViewBag.btnclass = "btn btn-primary";
            return View(customerlst);
        }

        [HttpPost]

        public IActionResult Create(Tblcustomer c)
        {
            customer.AddCustomer(c);
            ModelState.Clear();
            ViewBag.msg = "Customer Addedd Successfully";
            Tblcustomer customerlst = new Tblcustomer();
            ViewBag.btnvalue = "Submit";
            ViewBag.Header = "Add Customer";
            ViewBag.btnclass = "btn btn-primary";
            ViewData["customerdata"] = customer.GetAllCustomer();
            return View(customerlst);

        }

        public IActionResult Edit(int id)
        {
            Tblcustomer ct = customer.GetCustomerById(id);
            ViewData["customerdata"] = customer.GetAllCustomer();
            ViewBag.btnvalue = "Update";
            ViewBag.Header = "Update Customer";
            ViewBag.btnclass = "btn btn-success";
            return View(ct);


        }

        [HttpPost]
        public IActionResult Edit(Tblcustomer cr)
        {
            customer.UpdateCustomer(cr);
            ModelState.Clear();
            Tblcustomer c = new Tblcustomer();
            ViewData["customerdata"] = customer.GetAllCustomer();
            ViewBag.btnvalue = "Update";
            ViewBag.Header = "Update Customer";
            ViewBag.btnclass = "btn btn-success";
            ViewBag.msg = "Customer Updatec Successfully";
            return View(c);
        }

        public IActionResult Delete(int id)
        {
            customer.DeleteCustomer(id);
            return RedirectToAction("Create");
        }
    }
}
