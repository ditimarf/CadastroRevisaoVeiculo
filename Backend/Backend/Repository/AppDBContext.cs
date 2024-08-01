using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class AppDBContext : DbContext
	{
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Revisao> Revisao { get; set; }

        private readonly IConfiguration _configuration;
        public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DataBaseConnectionString"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>()
                .HasOne(x => x.Veiculo)
                .WithOne(x => x.Carro)
                .HasForeignKey<Carro>(x => x.CodigoVeiculo);

            modelBuilder.Entity<Caminhao>()
                .HasOne(x => x.Veiculo)
                .WithOne(x => x.Caminhao)
                .HasForeignKey<Caminhao>(x => x.CodigoVeiculo);

            modelBuilder.Entity<Revisao>()
                .HasOne(x => x.Veiculo)
                .WithMany(x => x.Revisoes)
                .HasForeignKey(x => x.CodigoVeiculo)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

