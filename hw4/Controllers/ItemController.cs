using hw4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw4.Controllers
{
    public class ItemController : Controller
    {
        // GET: ItemController
        public ActionResult Index()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var items = db.Items.ToList();

                ViewBag.items = items;
            }

            return View();
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
              
                Item item = new Item { Name = Name};
               
                db.Items.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [Route("Item/Delete/{id?}")]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
           using(ApplicationContext db = new ApplicationContext())
            {
                Item? b = await db.Items.FirstOrDefaultAsync(u => u.Id == id);
                if (b != null)
                {
                    db.Items.Remove(b);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
