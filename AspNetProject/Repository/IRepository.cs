using AspNetProject.Models;

namespace AspNetProject.Repository
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAllAnimals();
        IEnumerable<Animal> GetMostPopular2();
        Animal GetAnimalById(int id);
        void InsertPets(Animal pets);
        void UpdatePets(int id, Animal pets);
        void UpdatePet(Animal pets);

        void AddCommentToAnimal(Comment comment);
        IEnumerable<Category> GetAllCategories();
        void DeletePet(int id);
        void AddAnimal(Animal animal);
    }
}
