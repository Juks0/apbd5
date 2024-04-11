using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly MockDb _db;

        public AnimalsController(MockDb db)
        {
            _db = db;
        }

        // GET: /animals
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_db.Animals);
        }

        // GET: /animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _db.Animals.Find(a => a.Id == id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        // POST: /animals
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            _db.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        // PUT: /animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            var existingAnimal = _db.Animals.Find(a => a.Id == id);
            if (existingAnimal == null)
                return NotFound();

            existingAnimal.FirstName = animal.FirstName; // Update other properties as needed

            return NoContent();
        }

        // DELETE: /animals/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var existingAnimal = _db.Animals.Find(a => a.Id == id);
            if (existingAnimal == null)
                return NotFound();

            _db.Animals.Remove(existingAnimal);

            return NoContent();
        }
    }
}