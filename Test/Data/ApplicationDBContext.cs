using Microsoft.EntityFrameworkCore;
using Test.Models.entity;

namespace Test.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
    }
}
