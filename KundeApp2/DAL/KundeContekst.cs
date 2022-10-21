using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundeApp2.Model
{
    public class Kunder
    {
        public int Id { get; set; }  
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
      
    }
    

    public class KundeContext : DbContext
    {
            public KundeContext (DbContextOptions<KundeContext> options)
                    : base(options)
            {
                // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
                // dette er uavhenig av initiering av databasen (seeding)
                // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
                Database.EnsureCreated();
        }

        public DbSet<Kunder> Kunder { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
