// Get the modal
var createModal = document.getElementById("createModal");
var editModal = document.getElementById("editModal");

// Get the button that opens the modal
var addButton = document.querySelector(".add-button");
var editButton = document.querySelector(".edit-button");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal
addButton.onclick = function () {
    createModal.style.display = "flex";
}

// When the user clicks the button, open the modal
editButton.onclick = function () {
    editModal.style.display = "flex";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    createModal.style.display = "none";
}

// When the user clicks anywhere outside the modal, close it
window.onclick = function (event) {
    if (event.target == createModal) {
        createModal.style.display = "none";
    }
}