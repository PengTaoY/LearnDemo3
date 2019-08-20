using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }
        public DbSet<Address> Address { get; set; }
    }
}
