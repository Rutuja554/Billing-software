using Billing_software.Models;
using Billing_software.Services.Invoices;
using Billing_software.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace Billing_software.Controllers
{
    
    public class ProductController : Controller
    {
        IProduct product;

        public ProductController(IProduct product)
        {
            this.product = product;

        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult FetchProduct()
        {
            List<Tblproduct> lst = product.GetAllProduct();
            return Json(lst);
        }

        public JsonResult FetchProductById(int id)
        {
            Tblproduct p = product.GetProductByID(id);
            return Json(p);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public string AddProduct([FromBody]Tblproduct p)
        {
            product.AddProduct(p);
            return "Product Addedd Successfully";
        }



        [HttpPost]
        public string UpdateProduct([FromBody]Tblproduct p)
        {
            product.UpdateProduct(p);
            return "Product Updated Successfully";
        }

        [HttpPost]
        public string DeleteProduct(int id)
        {
            product.DeleteProduct(id);
            return "Product Deleted Successfully";
        }

        


    }
}
