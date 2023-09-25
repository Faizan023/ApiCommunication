using loginmodel;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class dbContex : DbContext
    {
        public dbContex(DbContextOptions<dbContex> options)
            : base(options) { }

        public DbSet<Login> Users { get; set; }
    }
}
