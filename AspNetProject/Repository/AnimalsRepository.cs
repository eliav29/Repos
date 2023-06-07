using AspNetProject.Data;
using AspNetProject.Models;
using System.Drawing;

namespace AspNetProject.Repository
{
    public class AnimalsRepository : IRepository
    {
        private PetContext _context;
        public AnimalsRepository(PetContext context)
        {
            _context = context;
        }
        public void InsertPets(Animal pets)
        {
            _context.Animals!.Add(pets);
            _context.SaveChanges();
        }
        public IEnumerable<Animal> GetAllAnimals()
        {
            foreach (var pet in _context.Animals!)
            {
                int i = 0;
            }
            return _context.Animals!.ToList();
        }
        public IEnumerable<Animal> GetMostPopular2()
        {
            var popular = GetAllAnimals()
                .OrderByDescending(pet => pet.Comments?.Count() ?? 0)
                .Take(2)
                .ToList();

            return popular;
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals!.FirstOrDefault(m => m.Id == id)!;
        }
        public void UpdatePets(int id, Animal pets)
        {
            var petInDb = _context.Animals!.FirstOrDefault(m => m.Id == id);
            if (petInDb != null)
            {
                petInDb.Name = pets.Name;
                petInDb.Age = pets.Age;
                petInDb.PictureName = pets.PictureName;
                petInDb.Description = pets.Description;
                petInDb.Category = pets.Category;
            }
            _context.SaveChanges();
        }
        public void UpdatePet(Animal pets)
        {
            var petInDb = _context.Animals!.FirstOrDefault(m => m.Id == pets.Id);
            if (petInDb != null)
            {
                if(pets.PictureName != null)
                    petInDb.PictureName = pets.PictureName;

                petInDb.Name = pets.Name;
                petInDb.Age = pets.Age;
                petInDb.Description = pets.Description;
                petInDb.Category = pets.Category;
                petInDb.CategoryId = pets.CategoryId;
            }
            _context.SaveChanges();
        }
        public void AddCommentToAnimal(Comment comment)
        {
            if (comment != null)
            {
                _context.Comments!.Add(comment);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = _context.Categories!.ToList();
            return categories;
        }
        public void DeletePet(int id)
        {
            var pet = _context.Animals!.FirstOrDefault(m => m.Id == id);
            if (pet != null)
                _context.Animals!.Remove(pet);
            _context.SaveChanges();
        }
        public void AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                _context.Animals!.Add(animal);
                _context.SaveChanges();
            }
        }
    }
}
