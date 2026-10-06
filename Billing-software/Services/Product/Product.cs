using Billing_software.Models;

namespace Billing_software.Services.Product
{
    public class Product : IProduct
    {
        InvoicebillingDbContext db;

        public Product()
        {
            db = new InvoicebillingDbContext();
        }
        public void AddProduct(Tblproduct product)
        {
            db.Tblproducts.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int product_id)
        {
            Tblproduct p = db.Tblproducts.Find(product_id);
            db.Tblproducts.Remove(p);
            db.SaveChanges();
        }

        public List<Tblproduct> GetAllProduct()
        {
            List<Tblproduct> lst = db.Tblproducts.ToList();
            return lst;
        }

        public Tblproduct GetProductByID(int product_id)
        {
            Tblproduct p = db.Tblproducts.Find(product_id);
            return p;
        }

        public void UpdateProduct(Tblproduct pr)
        {
            db.Tblproducts.Update(pr);
            db.SaveChanges();
        }
    }
}
