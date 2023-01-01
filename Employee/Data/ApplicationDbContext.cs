using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Employee.Models;

namespace Employee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee.Models.Emp> Emp { get; set; }
        public DbSet<Employee.Models.tblEmployee> tblEmployee { get; set; }
    }
}