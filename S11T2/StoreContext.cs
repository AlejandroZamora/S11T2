using Microsoft.EntityFrameworkCore;
using S11T2.Models;

namespace S11T2
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions<StoreContext>
options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
