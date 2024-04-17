using Microsoft.EntityFrameworkCore;
using DemoGenerateursEtValidation.Models;

namespace DemoGenerateursEtValidation.Models
{
    public class CatalogueAutoDbContext: DbContext
    {
        public CatalogueAutoDbContext(DbContextOptions<CatalogueAutoDbContext> options) : base(options)
        {

        }

        public DbSet<Auto> Autos { get; set; }
    }
}
