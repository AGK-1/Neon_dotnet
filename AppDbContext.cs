using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SQLE_sam.Model;

namespace SQLE_sam
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Users> Userss { get; set; }    

    }
}
