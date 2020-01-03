using CatalogueDNApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogueDNApp
{
    public class CatalogueDbRepository : DbContext
    {
        public DbSet <Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
        public CatalogueDbRepository(DbContextOptions options):base(options){

        }


    }
}