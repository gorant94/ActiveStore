using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActiveStore.Domain.Abstract;
using ActiveStore.Domain.Entities;

namespace ActiveStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null, HttpPostedFileBase image2 = null, HttpPostedFileBase image3 = null, HttpPostedFileBase image4 = null, HttpPostedFileBase image5 = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                if (image2 != null)
                {
                    product.ImageMimeType2 = image2.ContentType;
                    product.ImageData2 = new byte[image2.ContentLength];
                    image2.InputStream.Read(product.ImageData2, 0, image2.ContentLength);
                }
                if (image3 != null)
                {
                    product.ImageMimeType3 = image3.ContentType;
                    product.ImageData3 = new byte[image3.ContentLength];
                    image3.InputStream.Read(product.ImageData3, 0, image3.ContentLength);

                }
                if (image4 != null)
                {
                    product.ImageMimeType4 = image4.ContentType;
                    product.ImageData4 = new byte[image4.ContentLength];
                    image4.InputStream.Read(product.ImageData4, 0, image4.ContentLength);
                }
                if (image5 != null)
                {
                    product.ImageMimeType5 = image5.ContentType;
                    product.ImageData5 = new byte[image5.ContentLength];
                    image5.InputStream.Read(product.ImageData5, 0, image5.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");


            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}
