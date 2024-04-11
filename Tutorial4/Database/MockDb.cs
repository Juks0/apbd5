using System;
using System.Collections.Generic;
using Tutorial4.Models;

namespace Tutorial4.Database
{
    public class MockDb
    {
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Visit> Visits { get; set; } = new List<Visit>();
        public int NextAnimalId { get; set; } = 1;
        public int NextVisitId { get; set; } = 1;

        public MockDb()
        {
            // Dodaj przykładowe dane
            Animals.Add(new Animal { Id = NextAnimalId++, FirstName = "Reks" });
            Animals.Add(new Animal { Id = NextAnimalId++, FirstName = "Azor" });

            Visits.Add(new Visit { Id = NextVisitId++, Date = DateTime.Now, Description = "Wizyta kontrolna", Price = 50.00m, Animal = Animals[0] });
            Visits.Add(new Visit { Id = NextVisitId++, Date = DateTime.Now.AddDays(7), Description = "Szczepienie", Price = 30.00m, Animal = Animals[1] });
        }
    }
}