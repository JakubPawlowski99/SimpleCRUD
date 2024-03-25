using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        // GET: Product
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products.Find(p => p.Id == id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            var index = products.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                products[index] = product;
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.Find(p => p.Id == id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            products.RemoveAll(p => p.Id == id);
            return RedirectToAction("Index");
        }
    }
}
