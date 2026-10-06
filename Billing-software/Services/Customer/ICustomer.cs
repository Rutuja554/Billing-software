using Billing_software.Models;

namespace Billing_software.Services
{
    public interface ICustomer
    {
        public void AddCustomer(Tblcustomer custmer);

        List<Tblcustomer> GetAllCustomer();
        public void UpdateCustomer(Tblcustomer customer);

        Tblcustomer GetCustomerById(int customer_id);
        public void DeleteCustomer(int customer_id);
    }
}
