namespace comp2007w2018finalA.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    //[DataContract(IsReference = true)]
    //[JsonObject(IsReference = false)]
    public partial class Restaurant
    {
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int CityId { get; set; }

        [StringLength(50)]
        public string Menu { get; set; }

        public City City { get; set; } // removed "virtual" to remove circular ref: https://stackoverflow.com/questions/17718153/circular-reference-error-when-serializing-objects-in-asp-net-web-api#22185095 (disable lazy loading)
    }
}
