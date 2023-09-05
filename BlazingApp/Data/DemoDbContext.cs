using BlazingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlazingApp.Data
{
    public class DemoDbContext: DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) 
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
