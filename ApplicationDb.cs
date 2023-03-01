using Estacionamiento_WebApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Estacionamiento_WebApi
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Estacionamiento> Estacionamiento { get; set; }
    }
}