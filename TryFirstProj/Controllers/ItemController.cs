using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TryFirstProj.Data;
using TryFirstProj.Models;

namespace TryFirstProj.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;
        public ItemController(AppDbContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {
            IEnumerable<Item> ItemList = _db.Items.Include(c => c.catogrey).ToList();
            return View(ItemList);
        }

        //Get 
        public IActionResult New()
        {
            createSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.name == "100")
            {
                ModelState.AddModelError("name", "Name cannot be 100");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["SuccessData"] = "Add New Item Succsefly";
                return RedirectToAction("Index");
            }
            else
                return View(item);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.catogreyId);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.name == "100")
            {
                ModelState.AddModelError("name", "Name cannot be 100");
            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["SuccessData"] = "Edit Item Succsefly";
                return RedirectToAction("Index");
            }
            else
                return View(item);
        }

        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.catogreyId);
            return View(item);
        }

        /*   [HttpPost]
           [ValidateAntiForgeryToken]
           public IActionResult Delete(Item item)
           {
                   _db.Items.Remove(item);
                   _db.SaveChanges();
                   return RedirectToAction("Index");
           }*/

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteId(int? id)
        {
            var Item = _db.Items.Find(id);
            if (Item == null)
            {
                return NotFound();
            }
            _db.Remove(Item);
            _db.SaveChanges();
            TempData["SuccessData"] = "Delete Item Succsefly";
            return RedirectToAction("Index");
        }

        public void createSelectList(int selectId=1)
        {
            List<Catogrey> catogreyList =_db.Categories.ToList();
            SelectList listcatogry = new SelectList(catogreyList, "Id", "Name", selectId);
            ViewBag.catogreyList = listcatogry;
        }

    }
}
