using AgroFuturo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroFuturo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaInsumo> CategoriaInsumo { get; set; } = default!;
        public DbSet<ConsumoInsumo> ConsumoInsumo { get; set; } = default!;
        public DbSet<Equipamento> Equipamento { get; set; } = default!;
        public DbSet<Fazenda> Fazenda { get; set; } = default!;

    }
}
