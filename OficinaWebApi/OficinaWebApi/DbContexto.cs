using Microsoft.EntityFrameworkCore;

namespace OficinaWebApi
{
    public class DbContexto : DbContext 
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("User ID=webapioficina;Password=j9tqiqNMRxcWuMpb7bJ6rUxKohSoZMZi;Host=dpg-cvd0a7pc1ekc73aspdq0-a.oregon-postgres.render.com;Port=5432;Database=webapioficina;Pooling=true;");        
        }
    }
}
