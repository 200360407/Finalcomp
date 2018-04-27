namespace comp2007w2018finalA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FishTacoModel : DbContext
    {
        public FishTacoModel()
            : base("name=DefaultConnection")
        {
            //Configuration.ProxyCreationEnabled = false; //this is line to be added re: https://stackoverflow.com/questions/19467673/entity-framework-self-referencing-loop-detected#30203455
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Restaurants)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Menu)
                .IsUnicode(false);
        }
    }
}
