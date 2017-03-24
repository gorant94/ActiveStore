using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveStore.Domain.Abstract;
using ActiveStore.WebUI.Models;
using ActiveStore.Domain.Entities;


namespace ActiveStore.WebUI.Controllers
{
    public class ProductPageController:Controller
    {
        private IProductRepository repository;
        public int pageSize = 4;
        public ProductPageController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult ProductPage(int productId, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => productId == 0 || p.ProductId == productId)
                    .OrderBy(p=> p.Name)
            };
            return View(model);
        }   
    }
}