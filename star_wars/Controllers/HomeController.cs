using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using star_wars.DAL;
using star_wars.Models;

namespace star_wars.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StarWarsCharacterDAL dal = new StarWarsCharacterDAL();
            List<StarWarsCharacter> model = dal.GetCharacters();

            return View(model);
        }
    }
}