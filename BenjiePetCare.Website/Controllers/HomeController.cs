using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BenjiePetCare.Core.Controllers;
using BenjiePetCare.Core.Models;

namespace BenjiePetCare.Website.Controllers
{
    public class HomeController : Controller
    {
        PetController petsController = new PetController();

        public ActionResult Index()
        {
            IEnumerable<Pet> pets = this.petsController.Get();
            return View(pets);
        }

        /// <summary>
        /// For fetching data on demand
        /// </summary>
        [HttpGet]
        public JsonResult GetPets()
        {
            IEnumerable<Pet> pets = this.petsController.Get();
            return Json(pets, JsonRequestBehavior.AllowGet);
        }
    }
}