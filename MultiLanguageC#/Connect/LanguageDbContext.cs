namespace MultiLanguageC_.Connect
{
    using Microsoft.EntityFrameworkCore;
    using MultiLanguageC_.Models;

    public class LanguageDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Localization> Localizations { get; set; }

        public LanguageDbContext(DbContextOptions<LanguageDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;initial catalog=MultiLanguageDb;integrated Security=true;TrustServerCertificate=true;");
            }
        }
    }

}
