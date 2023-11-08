using Microsoft.EntityFrameworkCore;
using webApi_Live.Models;

namespace webApi_Live.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Defina as DbSet para suas entidades
        public DbSet<Aluno> Aluno { get; set; }
       
        // Adicione outras configurações de entidade, como chaves primárias, índices, relações, etc., no método OnModelCreating.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defina suas configurações de entidade aqui
        }
    }
}