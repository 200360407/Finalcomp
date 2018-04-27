using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comp2007w2018finalA.Models
{
    public class EFCityRepository : IMockCityRepository
    {
        private FishTacoModel db = new FishTacoModel();


        public IQueryable<City> Cities
        {
            get { return db.Cities; }

        }
        public City Save(City city)
        {
            if (city.CityId == null)
            {
                db.Cities.Add(city);
            }
            else
            {
              
                db.Entry(city).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return city;
        }

        public City Save(object city)
        {
            throw new NotImplementedException();
        }
    }
}