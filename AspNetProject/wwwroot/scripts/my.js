
//function filterTable() {
//    var selectedCategory = document.getElementById('categoryFilter').value;
//    var rows = document.getElementsByClassName('pets-row');

//    for (var i = 0; i < rows.length; i++) {
//        var category = rows[i].getAttribute('data-category');
//        if (selectedCategory === "" || category === selectedCategory) {
//            rows[i].style.display = 'table-row';
//        } else {
//            rows[i].style.display = 'none';
//        }
//    }
//}



//<div>
//        <h5>Please select a category to filter:</h5>
//        <select id="categoryFilter" onchange="filterTable()">
//            <option value="">Select Category</option>
//            <option value="1">Birds</option>
//            <option value="2">Reptiles</option>
//            <option value="3">Fish</option>
//            <option value="4">Mammals</option>
//        </select>
//    </div>
//    <br>
//    <div>
//        <table id="petsTable" class="table align-middle table-bordered table-striped">
//            <thead>
//                <tr>
//                    <th scope="col">Picture of the pet</th>
//                    <th scope="col">Name</th>
//                    <th scope="col">Find out more and comment</th>
//                </tr>
//            </thead>
//            <tbody>
//                @foreach (var animal in Model)
//                {
//                    <tr data-category="@animal.CategoryId" class="pets-row">
//                        <td scope="row"><img src="@Url.Content("~/Images/" + animal.PictureName)" alt="@animal.Name" style="width: 200px; height: auto" class="img-fluid"></td>
//                        <td>@animal.Name</td>
//                        <td>@Html.ActionLink("Details", "Details", new { id = animal.AnimalId })</td>
//                    </tr>
//                }
//            </tbody>
//        </table>
//    </div>








    function generatePetContainer(pets) {
    var selectedOption = document.getElementById("dropdown").value;
    //var pets = fetchPets(selectedOption);

    var petContainer = document.getElementById("petContainer");

    petContainer.innerHTML = "";

    var generatedContainer = generatePetContainerElement(pets);
    petContainer.appendChild(generatedContainer);
}



    function generatePetContainerElement(pets) {
    var container = document.createElement("div");
    container.className = "container d-flex align-items-center justify-content-center flex-wrap";

    pets.forEach(function (pet) {
        var box = document.createElement("div");
    box.className = "box";

    var body = document.createElement("div");
    body.className = "body";

    var imgContainer = document.createElement("div");
    imgContainer.className = "imgContainer";

    var img = document.createElement("img");
    img.className = "pict";
    img.src = "~/images/" + pet.PictureName;
    img.alt = pet.Name;

    imgContainer.appendChild(img);

    var content = document.createElement("div");
    content.className = "content d-flex flex-column align-items-center justify-content-center";

    var info = document.createElement("div");

    var name = document.createElement("h3");
    name.className = "text-white fs-5";
    name.textContent = pet.Name;

    var link = document.createElement("a");
    //link.href = "Details?id=" + pet.Id;
    link.href = "Animal/Details" + pet.Id;
    link.textContent = "Find more and comment";

    var paragraph = document.createElement("p");
    paragraph.className = "fs-6 text-white";
    paragraph.appendChild(link);

    info.appendChild(name);
    info.appendChild(paragraph);
    content.appendChild(info);

    body.appendChild(imgContainer);
    body.appendChild(content);

    box.appendChild(body);
    container.appendChild(box);
    });

    return container;
}


//function fetchPets(option) {

//    if (option === "option1") {
//        return [
//            new Animal {Name: pet1.Name, PictureName: pet1.PictureName, Id: pet1.Id },
//            new Animal {Name: pet2.Name, PictureName: pet2.PictureName, Id: pet2.Id },
//        ];
//    } else if (option === "option2") {
//        return [
//            new Animal {Name: pet3.Name, PictureName: pet3.PictureName, Id: pet3.Id },
//            new Animal  Name: pet4.Name, PictureName: pet4.PictureName, Id: pet4.Id }
//        ];
//    } else if (option === "option3") {
//        return [
//            new Animal  Name: pet5.Name, PictureName: pet5.PictureName, Id: pet5.Id },
//            new Animal  Name: pet6.Name, PictureName: pet6.PictureName, Id: pet6.Id }
//        ];
//    } else {
//        return [];
//    }
//}






//function filterAnimals() {
//    var categoryId = document.getElementById("dropdown").value;
//    var animalContainer = document.getElementById("animalContainer");
//    var animals = animalContainer.getElementsByClassName("animal");

//    for (var i = 0; i < animals.length; i++) {
//        var animal = animals[i];
//        var categoryIdAttr = animal.getAttribute("data-category");

//        if (categoryId === "All" || categoryId === categoryIdAttr) {
//            animal.style.display = "block";
//        } else {
//            animal.style.display = "none";
//        }
//    }
//}



  // Wait for the document to load
    document.addEventListener("DOMContentLoaded", function() {
    // Get the file input element
    var fileInput = document.getElementById("addPet");
    // Get the warning message element
    var pictureValidation = document.getElementById("pictureValidation");

    // Add event listener to file input element
    fileInput.addEventListener("change", function(event) {
      var file = event.target.files[0];

    // Check if a file is selected
    if (!file) {
        // No file selected, hide the warning message
        pictureValidation.style.display = "none";
    return;
      }

    // Check if the file is a JPEG image
    if (file.type !== "image/jpeg") {
        // Invalid file selected, show the warning message
        pictureValidation.style.display = "block";
      } else {
        // Valid file selected, hide the warning message
        pictureValidation.style.display = "none";
      }
    });

    // Get the image element
    var picture = document.getElementById("picture");

    // Add event listener to image element
    picture.addEventListener("load", function() {
      // Check if the loaded image is valid
      if (picture.naturalWidth === 0 || picture.naturalHeight === 0) {
        // Invalid image loaded, show the warning message
        pictureValidation.style.display = "block";
      } else {
        // Valid image loaded, hide the warning message
        pictureValidation.style.display = "none";
      }
    });
  });
