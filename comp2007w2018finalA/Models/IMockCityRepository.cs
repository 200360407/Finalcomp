using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp2007w2018finalA.Models
{
    public interface IMockCityRepository
    {
        IQueryable<City> Cities { get; }

        City Save(object city);
       
    }
}
