using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using comp2007w2018finalA.Models;

namespace comp2007w2018finalA.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using comp2007w2018finalA.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Restaurant>("Restaurants");
    builder.EntitySet<City>("Cities"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RestaurantsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Restaurants
        [EnableQuery]
        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        // GET: odata/Restaurants(5)
        [EnableQuery]
        public SingleResult<Restaurant> GetRestaurant([FromODataUri] int key)
        {
            return SingleResult.Create(db.Restaurants.Where(restaurant => restaurant.RestaurantId == key));
        }

        // PUT: odata/Restaurants(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Restaurant> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant restaurant = db.Restaurants.Find(key);
            if (restaurant == null)
            {
                return NotFound();
            }

            patch.Put(restaurant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(restaurant);
        }

        // POST: odata/Restaurants
        public IHttpActionResult Post(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return Created(restaurant);
        }

        // PATCH: odata/Restaurants(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Restaurant> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant restaurant = db.Restaurants.Find(key);
            if (restaurant == null)
            {
                return NotFound();
            }

            patch.Patch(restaurant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(restaurant);
        }

        // DELETE: odata/Restaurants(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Restaurant restaurant = db.Restaurants.Find(key);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Restaurants(5)/City
        [EnableQuery]
        public SingleResult<City> GetCity([FromODataUri] int key)
        {
            return SingleResult.Create(db.Restaurants.Where(m => m.RestaurantId == key).Select(m => m.City));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int key)
        {
            return db.Restaurants.Count(e => e.RestaurantId == key) > 0;
        }
    }
}
