using doacaoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace doacaoApi.Context
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> opts):base(opts)
        {

        }

        public DbSet<Item> items { get; set; }
    }
}
