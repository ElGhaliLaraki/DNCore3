

using System.Collections.Generic;
using System.Linq;
using CatalogueDNApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogueDNApp.Controllers{

    public class ProductController:Controller{
        public CatalogueDbRepository catalogueRepository {get;set;}
        public ProductController(CatalogueDbRepository repository){
            this.catalogueRepository=repository;
        }
        public IActionResult Products(){
            IEnumerable <Product> prods=catalogueRepository.Products.Include(p=>p.Category);
            return View(prods);   
        }

        public IActionResult FormProduct(){
            Product product = new Product();
            return View(product);

        }

        public IActionResult Save(Product product){    
            if(ModelState.IsValid){
                catalogueRepository.Products.Add(product);
                catalogueRepository.SaveChanges();
                return RedirectToAction("Products",product);
            }
            return View("FormProduct",product);
        }

         public IActionResult search(string kw){
            if(kw==null){
                ModelState.AddModelError("kw","ne doit pas etre nul");
            }
            if(ModelState.IsValid){
            IEnumerable <Product> product=catalogueRepository.Products.Include(p=>p.Category)
            .Where(p=>p.Name.Contains(kw));
            return View("Products",product);
            }
            IEnumerable <Product> allProds=catalogueRepository.Products.Include(p=>p.Category);
            return View("Products",allProds);
        }

        public IActionResult Edit(int Id){
            Product p=catalogueRepository.Products
            .Include(p=>p.Category).FirstOrDefault(p=>p.ProductID==Id);
            return View(p);
        }
        public IActionResult UpDate(Product product, int Id){
            if(ModelState.IsValid){
            catalogueRepository.Products.Update(product);
            catalogueRepository.SaveChanges();
            return RedirectToAction("Products");
            }
            return View("Edit",product);
        }
        
        public IActionResult Delete(int Id){
            Product product=catalogueRepository.Products.FirstOrDefault(p=>p.ProductID==Id);
            catalogueRepository.Remove(product);
            catalogueRepository.SaveChanges();
            return RedirectToAction("Products");
        }
        

    }
}