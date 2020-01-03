using CatalogueDNApp.Models;
using System;
namespace CatalogueDNApp.Services{
    public static class DbInit{
        public static void initData(CatalogueDbRepository catalogueDb){
            Console.WriteLine("Data Initialization...");
            catalogueDb.Categories.Add(new Category{Name="Ordinateurs"});
            catalogueDb.Categories.Add(new Category{Name="Imprimantes"});
            catalogueDb.Products.Add(new Product{Name="Dell XPS",Price=12000, CategoryID=1});
            catalogueDb.Products.Add(new Product{Name="Mac Book Pro",Price=22000, CategoryID=1});
            catalogueDb.Products.Add(new Product{Name="HP Pavillon",Price=8000, CategoryID=1});
            catalogueDb.Products.Add(new Product{Name="Imprimante Canon",Price=2000, CategoryID=2});
            catalogueDb.SaveChanges();
        }
    }
}