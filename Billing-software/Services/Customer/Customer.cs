using Billing_software.Models;

namespace Billing_software.Services
{
    public class Customer:ICustomer
    {
        InvoicebillingDbContext db;

        public Customer()
        {
            db = new InvoicebillingDbContext();
        }

        public void AddCustomer(Tblcustomer custmer)
        {
            db.Tblcustomers.Add(custmer);
            db.SaveChanges();
        }

        public void DeleteCustomer(int customer_id)
        {
            Tblcustomer lst = db.Tblcustomers.Find(customer_id);
            db.Tblcustomers.Remove(lst);
            db.SaveChanges();
        }

        public List<Tblcustomer> GetAllCustomer()
        {
            List<Tblcustomer> lst = db.Tblcustomers.ToList();
            return lst;
        }

        public Tblcustomer GetCustomerById(int customer_id)
        {
            Tblcustomer c = db.Tblcustomers.Find(customer_id);
            return c;
        }

        public void UpdateCustomer(Tblcustomer customer)
        {
            db.Tblcustomers.Update(customer);
            db.SaveChanges();
        }
    }
}
