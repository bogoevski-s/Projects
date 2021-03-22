let submitButton = document.getElementById("submitBtn");
let mainDiv = document.getElementById("mainDiv");
let submitDiv = document.getElementById("submitDiv");
let form = document.getElementById("formMain");

submitButton.addEventListener("click", ()=> {
    mainDiv.style.display = "none";
    submitDiv.style.display = "block";
    submitDiv.innerHTML = `<h1>successfuly submitted form</h1>`
    console.log("clicked")
})


// form.onsubmit(function(event) {
//     event.preventDefault();
//     return false
// })
