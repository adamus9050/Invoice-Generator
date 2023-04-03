using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Entities;

namespace Invoice_Generator.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IDataBaseService _dataBaseService;
        public HomeController(IDataBaseService dataService)
        {
            _dataBaseService = dataService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("PolitykaPrywatnosci")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMaterials()
        {
            return View();
        }
        //Add materials to database
        [HttpPost]
        public async Task<IActionResult> AddMaterials(Material material)
        {
            //if (!this.GetType().Equals(material.Name.GetType()))
            //{
            //    return View("Errors/ErrorM");
            //}
            //else 
            //{
            if (!ModelState.IsValid)
            {
                return View("AddMaterials");
            }

            var mat = _dataBaseService.SaveMaterials(material);
            TempData["Materials"] = mat;
            return RedirectToAction("AddMaterials");
        }

        [HttpGet]
        public IActionResult List()
        {
            var listMaterial = _dataBaseService.GetAllMaterials();
            return View(listMaterial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMaterials(int id)
        {
            _dataBaseService.DeleteMaterial(id);
            ViewBag.Message = "Record Delete Succesfully";
            return RedirectToAction("List");
        }
        public async Task<IActionResult> SearchMaterials(string searchMaterial)
        {
            if (_dataBaseService.Search == null)
            {
                return Problem("Material isn't at the database");
            }
            var material = await _dataBaseService.Search(searchMaterial);
            return View(material);
        }

    }
}