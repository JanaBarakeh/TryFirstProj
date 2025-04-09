using Microsoft.AspNetCore.Mvc;
using TryFirstProj.Models;
using TryFirstProj.Repositry.Base;

namespace TryFirstProj.Controllers
{
    public class CatogreyController : Controller
    {
        public CatogreyController(IRepositry<Catogrey> catogreyRepositry)
        {
            this._catogreyRepositry = catogreyRepositry;

        }
        private IRepositry<Catogrey> _catogreyRepositry;
        /*  public IActionResult Index()
          {
              return View(_catogreyRepositry.GetAll());
          }*/
        public async Task<IActionResult> Index()
        {
            //var oneCat = _catogreyRepositry.SelectOne(x => x.Name == "Computers");
           // var allcat =_catogreyRepositry.FindAllAsync("Items");
            return View(await _catogreyRepositry.GetAllAsync());
        }
    }

}
