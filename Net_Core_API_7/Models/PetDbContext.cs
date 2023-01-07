using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Net_Core_API_7.Models
{
    public class PetDbContext : DbContext
         
    {
       
        public PetDbContext(DbContextOptions<PetDbContext> options ) : base(options) 
        {
           
        }
      
      
        public DbSet<Pet> Pets { set; get; }
    }
}
