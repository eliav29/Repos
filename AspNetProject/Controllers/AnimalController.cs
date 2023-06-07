using AspNetProject.Models;
using AspNetProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProject.Controllers
{
    public class AnimalController : Controller
    {
        IRepository _repository;
        public AnimalController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetMostPopular2());
        }
        public IActionResult Catalog(string category)
        {
            return View(_repository.GetAllCategories());
        }
        //public IActionResult Details(int id, string textComm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.AddCommentToAnimal(id, textComm);
        //        return View(_repository.GetAnimalById(id));

        //    }
        //    if (textComm != null)
        //    {
        //    }
        //}

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Animal = _repository.GetAnimalById(id);

            //if (textComm != null)
            //{
            //    _repository.AddCommentToAnimal(id, textComm);
            //}
            //return View(_repository.GetAnimalById(id));
            return View();
        }
        [HttpPost]
        public IActionResult Details(Comment comment)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _repository.AddCommentToAnimal(comment);
            }
            ViewBag.Animal = _repository.GetAnimalById(comment.AnimalId);
            return View();
        }
        public IActionResult Manage()
        {
            return View(_repository.GetAllCategories());
        }
        public IActionResult Delete(int id)
        {
            _repository.DeletePet(id);

            return RedirectToAction("Manage");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var list = _repository.GetAllCategories();
            ViewBag.Categories = list;
            //TempData["categories"] = list;
            return View(_repository.GetAnimalById(id));
        }
        [HttpPost]
        public IActionResult Edit(Animal animal, IFormFile? PictureName)
        {
            ModelState.Remove("PictureName");

            if (ModelState.IsValid)
            {
                if (PictureName != null)
                {
                    if (PictureName.ContentType != "image/jpeg")
                    {
                        ViewBag.Categories = _repository.GetAllCategories();
                        ModelState.AddModelError("PictureName", "Only JPEG images are allowed.");
                        return View("Edit", animal);
                    }

                    try
                    {
                        string fileName = Path.GetFileName(PictureName.FileName);
                        animal.PictureName = fileName;

                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using var stream = new FileStream(uploadPath, FileMode.Create);
                        PictureName.CopyTo(stream);

                        animal.PictureName = PictureName?.FileName;
                    }
                    catch { }
                }
                _repository.UpdatePet(animal);
                return RedirectToAction("Manage");
            }
            ViewBag.Categories = _repository.GetAllCategories();
            return View("Edit");
        }

        [HttpGet]
        public IActionResult CreateAnimal()
        {
            ViewBag.Categories = _repository.GetAllCategories();
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnimal(Animal animal, IFormFile PictureName)
        {
            ModelState.Remove("Id");
            ModelState.Remove("PictureName");
           

            try
            {
                if (PictureName != null && PictureName.ContentType == "image/jpeg")
                {
                    string fileName = Path.GetFileName(PictureName.FileName);
                    animal.PictureName = fileName;

                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using var stream = new FileStream(uploadPath, FileMode.Create);
                    PictureName.CopyTo(stream);
                }
                else 
                    ModelState.AddModelError("PictureName", "Only JPEG images are allowed.");
            }
            catch { }

            if (ModelState.IsValid && PictureName != null)
            { 
                animal.PictureName = PictureName!.FileName;

                _repository.AddAnimal(animal);
                return RedirectToAction("Manage");
            }
             ViewBag.Categories = _repository.GetAllCategories();


            
            //foreach (var modelStateEntry in ModelState.Values)
            //{
            //    foreach (var error in modelStateEntry.Errors)
            //    {
            //        int i = 5;
            //        i++;
            //    }
            //}


            return View();
        }
    }
}
