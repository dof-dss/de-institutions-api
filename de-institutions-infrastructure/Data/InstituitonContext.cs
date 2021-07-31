using de_institutions_api_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace de_institutions_infrastructure.Data
{
    public class InstituitonContext : DbContext
    {
        public DbSet<Institution> Institution { get; set; }
    }
}