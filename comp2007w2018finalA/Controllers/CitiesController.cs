using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp2007w2018finalA.Models;

namespace comp2007w2018finalA.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
       // private FishTacoModel db = new FishTacoModel();
        private IMockCityRepository db;
        private object city;

        // default constructor - use EF
        public CitiesController()
        {
            this.db = new EFCityRepository();
        }

        // unit testing constructor - use mock
        public CitiesController(IMockCityRepository mockRepo)
        {
            this.db = mockRepo;
        }

         
        // GET: Cities
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }

    
        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //City city = db.Cities.Find(id);
            City city = db.Cities.SingleOrDefault(o => o.CityId == id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        
    }
}
