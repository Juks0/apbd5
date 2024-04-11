using Tutorial4.Models;
using System.Collections.Generic;

namespace Tutorial4.Database
{
    public class StaticData
    {
        public static List<Animal> animals = new List<Animal>()
        {
            new Animal { Id = 1, FirstName = "Fluffy", Species = "Cat", Breed = "Persian", Age = 3 },
            new Animal { Id = 2, FirstName = "Buddy", Species = "Dog", Breed = "Golden Retriever", Age = 2 },
            new Animal { Id = 3, FirstName = "Whiskers", Species = "Cat", Breed = "Siamese", Age = 4 },
            new Animal { Id = 4, FirstName = "Max", Species = "Dog", Breed = "German Shepherd", Age = 5 },
            new Animal { Id = 5, FirstName = "Oreo", Species = "Cat", Breed = "Maine Coon", Age = 1 },
        };
    }
}