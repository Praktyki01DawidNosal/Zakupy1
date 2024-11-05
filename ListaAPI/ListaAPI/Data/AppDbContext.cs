using ListaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
        }


        public DbSet<ZakupyToDo> zakupyToDos => Set<ZakupyToDo>();

    }
}
