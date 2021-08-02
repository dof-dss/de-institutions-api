using de_institutions_api_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace de_institutions_infrastructure.Data
{
    public class InstituitonContext : DbContext
    {
        public InstituitonContext(DbContextOptions<InstituitonContext> options)
       : base(options)
        {
        }

        public DbSet<Institution> Institution { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}