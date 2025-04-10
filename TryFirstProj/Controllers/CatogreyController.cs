using Microsoft.AspNetCore.Mvc;
using TryFirstProj.Models;
using TryFirstProj.Repositry.Base;

namespace TryFirstProj.Controllers
{
    public class CatogreyController : Controller
    {
        public CatogreyController(IUnitOfWork _myUnit)
        {
           myUnit = _myUnit;
        }

        // private IRepositry<Catogrey> _catogreyRepositry;
        private readonly IUnitOfWork myUnit;

        /*  public IActionResult Index()
          {
              return View(_catogreyRepositry.GetAll());
          }*/
        public async Task<IActionResult> Index()
        {
            //var oneCat = _catogreyRepositry.SelectOne(x => x.Name == "Computers");
           // var allcat =_catogreyRepositry.FindAllAsync("Items");
            return View(await myUnit.Catogrey.GetAllAsync());
        }


        //GET
        public IActionResult New()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Catogrey category)
        {
            if (ModelState.IsValid)
            {
                if (category.clientFile != null)
                {
                    MemoryStream ms = new MemoryStream();
                    category.clientFile.CopyTo(ms);
                    category.dbImage = ms.ToArray();


                }
                myUnit.Catogrey.AddOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id==0)
            {
                return NotFound();
            }
            var category = myUnit.Catogrey.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catogrey category)
        {
            if (ModelState.IsValid)
            {
                myUnit.Catogrey.UpdateOne(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myUnit.Catogrey.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Catogrey category)
        {
            myUnit.Catogrey.DeleteOne(category);
            TempData["successData"] = "category has been deleted successfully";
            return RedirectToAction("Index");
        }
    }

}
