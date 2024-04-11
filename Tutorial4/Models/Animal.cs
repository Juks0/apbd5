using System;

namespace Tutorial4.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Species { get; set; } // Adding the Species property
        public string Breed { get; set; }
        public int Age { get; set; }
    }

    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Animal Animal { get; set; }
    }
}