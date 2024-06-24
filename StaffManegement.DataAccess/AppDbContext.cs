using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;

namespace StaffManegement.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Staff> Staffs { get; set; }

    }
}
