// Get the modal
var createModal = document.getElementById("eventCreateModal");
var editModal = document.getElementById("eventEditModal");

// Get the button that opens the modal
var addButton = document.querySelector(".add-button");
var editButtons = document.querySelectorAll(".edit-button");

// Get the <span> element that closes the modal
var spans = document.querySelectorAll(".close");

// When the user clicks the button, open the modal
addButton.onclick = function () {
    createModal.style.display = "flex";
}

// When the user clicks the button, open the modal
editButtons.forEach(function (editButton) {
    editButton.onclick = function () {
        editModal.style.display = "flex";
    }
});

// when the user clicks on <span> (x), close the modal
spans.forEach(function (span) {
    span.onclick = function () {
        createModal.style.display = "none";
        editModal.style.display = "none";
    }
});

// When the user clicks anywhere outside the modal, close it
window.onclick = function (event) {
    if (event.target == createModal) {
        createModal.style.display = "none";
    }
    if (event.target == editModal) {
        editModal.style.display = "none";
    }
}