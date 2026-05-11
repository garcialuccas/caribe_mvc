using caribe_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace caribe_mvc.Contexts
{
    public class CaribeDBContext : DbContext
    {
        public CaribeDBContext(DbContextOptions<CaribeDBContext> options) : base(options){}

        public DbSet<Prato> Prato { get; set; }
    }
}