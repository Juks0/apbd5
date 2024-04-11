using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints
{
    public static class AnimalEndpoints
    {
        public static void MapAnimalEndpoints(this WebApplication app, MockDb db)
        {
            // GET - Pobieranie listy zwierząt
            app.MapGet("/animals", () =>
            {
                return Results.Ok(db.Animals);
            });

            // GET - Pobieranie konkretnego zwierzęcia po Id
            app.MapGet("/animals/{id}", (int id) =>
            {
                var animal = db.Animals.Find(a => a.Id == id);
                if (animal == null)
                    return Results.NotFound();
                return Results.Ok(animal);
            });

            // POST - Dodawanie nowego zwierzęcia
            app.MapPost("/animals", (Animal animal) =>
            {
                animal.Id = db.NextAnimalId++;
                db.Animals.Add(animal);
                return Results.Created($"/animals/{animal.Id}", animal);
            });

            // PUT - Edycja zwierzęcia
            app.MapPut("/animals/{id}", (int id, Animal animal) =>
            {
                var index = db.Animals.FindIndex(a => a.Id == id);
                if (index == -1)
                    return Results.NotFound();

                animal.Id = id;
                db.Animals[index] = animal;
                return Results.NoContent();
            });

            // DELETE - Usuwanie zwierzęcia
            app.MapDelete("/animals/{id}", (int id) =>
            {
                var animal = db.Animals.Find(a => a.Id == id);
                if (animal == null)
                    return Results.NotFound();

                db.Animals.Remove(animal);
                return Results.NoContent();
            });
        }
    }

    public static class VisitEndpoints
    {
        public static void MapVisitEndpoints(this WebApplication app, MockDb db)
        {
            // GET - Pobieranie listy wizyt powiązanych z danym zwierzęciem
            app.MapGet("/animals/{animalId}/visits", (int animalId) =>
            {
                var visits = db.Visits.FindAll(v => v.Animal.Id == animalId);
                return Results.Ok(visits);
            });

            // POST - Dodawanie nowej wizyty
            app.MapPost("/visits", (Visit visit) =>
            {
                visit.Id = db.NextVisitId++;
                db.Visits.Add(visit);
                return Results.Created($"/visits/{visit.Id}", visit);
            });
        }
    }
}
