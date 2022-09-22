using Microsoft.EntityFrameworkCore;
using UsersDot.Models;

namespace UsersDot.Data
{
    public class DataContext: DbContext
    {
         public DataContext(DbContextOptions<DataContext> options):base (options)
        {
            
        }

        //Pluralisar nombre de entidad
        public DbSet<User> Users{get;set;}
    }
}