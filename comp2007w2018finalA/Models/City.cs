namespace comp2007w2018finalA.Models
{
    using Microsoft.Owin.BuilderProperties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public City()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required]
        [StringLength(60)]
        public string CityAddress { get; set; }

        [Required]
        [StringLength(60)]
        public string CityRestaurants { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }

}
