using Billing_software.Models;

namespace Billing_software.Services.Product
{
    public interface IProduct
    {

        public void AddProduct(Tblproduct product);

        public void UpdateProduct(Tblproduct pr);

        public void DeleteProduct(int product_id);

         List<Tblproduct> GetAllProduct();

        Tblproduct GetProductByID(int product_id);
    }
}
