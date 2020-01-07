using CatalogueDNApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueDNApp.Controllers{
    [Route("/api/products")]
    public class ProductRestController:Controller{
        
        public CatalogueDbRepository catalogueRepository {get;set;}
        public ProductRestController(CatalogueDbRepository repository){
            this.catalogueRepository=repository;
        }
        
        [HttpGet]
        public IEnumerable <Product> findAll(){
            return catalogueRepository.Products.Include(p=>p.Category);
        }

        [HttpGet("paginate")]
        public IEnumerable <Product> page(int page=0,int size=2){
            int skipValue=(page-1)*size;
            return catalogueRepository.Products.Include(p=>p.Category)
            .Skip(skipValue)
            .Take(size);
        }

         [HttpGet("search")]
        public IEnumerable <Product> search(string kw){
            return catalogueRepository.Products.Include(p=>p.Category)
            .Where(p=>p.Name.Contains(kw));
        }

        [HttpGet("{Id}")]
        public Product getOne(int Id){
            return catalogueRepository.Products
            .Include(p=>p.Category).FirstOrDefault(p=>p.ProductID==Id);
        }
        [HttpPost]
        public Product Save([FromBody]Product product){
            catalogueRepository.Products.Add(product);
            catalogueRepository.SaveChanges();
            return product;
        }
        [HttpPut("{Id}")]
        public Product UpDate([FromBody]Product product, int Id){
            product.ProductID=Id;
            catalogueRepository.Products.Update(product);
            catalogueRepository.SaveChanges();
            return product;
        }
         [HttpDelete("{Id}")]
        public void Delete(int Id){
            Product product=catalogueRepository.Products.FirstOrDefault(p=>p.ProductID==Id);
            catalogueRepository.Remove(product);
            catalogueRepository.SaveChanges();
        }
    }
}