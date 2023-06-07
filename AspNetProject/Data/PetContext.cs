using AspNetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetProject.Data
{
    public class PetContext : DbContext
    {
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }
        public PetContext(DbContextOptions<PetContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mammals" },
                new Category { Id = 2, Name = "Reptiles" },
                new Category { Id = 3, Name = "Poultry" }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Lizard", Age = 4, PictureName = "Lizard.jpeg", Description = " Lizards are a group of reptiles characterized by their scaly bodies, four legs, and long tails. They come in various sizes and colors, and they are found in different habitats around the world. Lizards are known for their ability to regrow lost tails and their remarkable climbing and camouflage abilities.", CategoryId = 2 },
                new Animal { Id = 2, Name = "Cat", Age = 3, PictureName = "Cat.jpeg", Description = "Cats are small, carnivorous mammals known for their agility, grace, and independent nature. They are domesticated pets that have been companions to humans for thousands of years. Cats are highly skilled hunters and have sharp retractable claws, excellent night vision, and a keen sense of balance. They communicate through vocalizations, such as meowing and purring, and display a wide range of behaviors and personalities. Cats are popular pets due to their playful nature, ability to form strong bonds with their owners, and their beautiful and diverse coat patterns and colors.", CategoryId = 1 },
                new Animal { Id = 3, Name = "Dog", Age = 5, PictureName = "Dog.jpeg", Description = "Dogs are domesticated mammals and are often referred to as \"man's best friend.\" They come in a wide range of breeds, sizes, and personalities. Dogs are known for their loyalty, intelligence, and social nature. They are often kept as pets and are valued for their companionship, working abilities (such as herding or assisting people with disabilities), and their roles in various tasks like search and rescue, therapy, and law enforcement.", CategoryId = 1 },
                new Animal { Id = 4, Name = "Snake", Age = 2, PictureName = "Snake.jpeg", Description = "Snakes are elongated, legless reptiles that are found in diverse habitats worldwide. They have scaly skin, forked tongues, and are known for their unique method of movement through the environment. Snakes can be venomous or non-venomous, and they come in different sizes and colors. They play important ecological roles and are fascinating creatures in terms of their adaptations and behavior.", CategoryId = 2 },
                new Animal { Id = 5, Name = "Parrot", Age = 1, PictureName = "Parrot.jpg", Description = "Parrots are colorful, intelligent birds known for their ability to mimic human speech and sounds. They have strong beaks, vibrant feathers, and zygodactyl feet (with two toes pointing forward and two toes pointing backward). Parrots are highly social creatures and are often kept as pets due to their engaging personalities and their capability to form strong bonds with their owners.", CategoryId = 3 },
                new Animal { Id = 6, Name = "Hamster", Age = 2, PictureName = "Hamster.jpg", Description = "Hamsters are small rodents that are commonly kept as pets. They have stout bodies, short tails, and prominent cheek pouches used for storing food. Hamsters are nocturnal animals and are known for their burrowing behavior. They come in various species and colors, and they make popular pets due to their compact size, low maintenance requirements, and entertaining habits.", CategoryId = 1 },
                new Animal { Id = 7, Name = "Chicken", Age = 1, PictureName = "Chicken.jpeg", Description = "Chickens are domesticated birds that are widely raised for their meat and eggs. They have feathers, beaks, and wings, but they are flightless in most breeds. Chickens are social animals and are often found in flocks. They come in different breeds and colors, and their eggs and meat are significant food sources for humans worldwide.", CategoryId = 3 }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, AnimalId = 1, AcComment = "This is the first Lizard" },
                new Comment { Id = 2, AnimalId = 2, AcComment = "This is the first Cat" },
                new Comment { Id = 3, AnimalId = 3, AcComment = "This is the first Dog" },
                new Comment { Id = 4, AnimalId = 4, AcComment = "This is the first Snake" },
                new Comment { Id = 5, AnimalId = 5, AcComment = "This is the first Parrot" },
                new Comment { Id = 6, AnimalId = 6, AcComment = "This is the first Hamster" },
                new Comment { Id = 7, AnimalId = 7, AcComment = "This is the first Chicken" },
                new Comment { Id = 8, AnimalId = 1, AcComment = "This is another comment for Lizard" },
                new Comment { Id = 9, AnimalId = 2, AcComment = "This is another comment for Cat" },
                new Comment { Id = 10, AnimalId = 3, AcComment = "This is another comment for Dog" },
                new Comment { Id = 11, AnimalId = 4, AcComment = "grate snake 1" },
                new Comment { Id = 13, AnimalId = 3, AcComment = "grate dog 1" },
                new Comment { Id = 14, AnimalId = 3, AcComment = "grate dog 2" },
                new Comment { Id = 12, AnimalId = 4, AcComment = "greate snake 2" }
            );
        }
    }
}
