using BlazingApp.Data;
using BlazingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingApp.Services
{
    // Service responsbile for DB access of Customer table
    public class CustomerService
    {
        private IDbContextFactory<DemoDbContext> _dbContextFactory;

        public CustomerService(IDbContextFactory<DemoDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        // Insert Customer
        public void AddCustomer(Customer customer)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        // Get Customer by Name
        public Customer GetCustomerByName(string name)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var customer = context.Customers.SingleOrDefault(x => x.Name == name);
                return customer;
            }
        }

        // Update Customer by Name
        public void UpdateCustomerByName(string name, int age)
        {
            var customer = GetCustomerByName(name);
            if (customer == null)
            {
                throw new Exception("Customer does not exist, cannot update.");
            }
            else
            {
                customer.Age = age;
                using(var context = _dbContextFactory.CreateDbContext())
                {
                    context.Update(customer);
                    context.SaveChanges();
                }
            }
        }
    }
}
