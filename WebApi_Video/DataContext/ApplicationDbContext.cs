using Microsoft.EntityFrameworkCore;
using WebApi_Video.Models;

namespace WebApi_Video.DataContext
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
