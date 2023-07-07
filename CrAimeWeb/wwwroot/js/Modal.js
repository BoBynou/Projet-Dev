// Get the modal
debugger;
var createModal = document.getElementById("createModal");
var modals = document.querySelectorAll(".modal");
var editModal = document.getElementById("editModal");

var menubar = document.querySelector(".menubar");

// Get the button that opens the modal
var addButton = document.querySelector(".add-button");
var burger = document.querySelector(".burger");

// Get the <span> element that closes the modal
var spans = document.querySelectorAll(".close");

window.onload = function () {
    modals.forEach(function (modal) {
        modal.style.display = "none";
    });
};

// add event listener for window resize
window.addEventListener("resize", function () {    if (window.innerWidth > 1024) {

    // check if the viewport is more than 1024px
        // always set it to flex
        menubar.style.display = "flex";
    }
});

// add event listener for window resize
window.addEventListener("resize", function () {
    // check if the viewport is more than 1024px
    if (window.innerWidth <= 1024) {
        menubar.style.display = "none";
    }
});

burger.onclick = // When the user clicks the button, open the modal
    function () {
        menubar.style.display = "flex";
        document.body.style.overflowY = "hidden";
    };

addButton.onclick = // When the user clicks the button, open the modal
    function () {
        createModal.style.display = "flex";
    };

// when the user clicks on <span> (x), close the modal
spans.forEach(function (span) {
    span.onclick = function () {
        document.body.style.overflowY = "auto";

        createModal.style.display = "none";
        editModal.style.display = "none";

        // Check if the viewport is less than or equal to 1024px
        if (window.matchMedia("(max-width: 1024px)").matches) {
            menubar.style.display = "none";
        }
    };
});

// When the user clicks anywhere outside the modal, close it
window.onclick = function (event) {
    if (event.target == createModal) {
        createModal.style.display = "none";
    }
    if (event.target == editModal) {
        editModal.style.display = "none";
    }
};
function setEditButtonsEventListeners() {
    var editButtons = document.querySelectorAll(".edit-button");

    // When the user clicks the button, open the modal
    editButtons.forEach(function (editButton) {
        editButton.onclick = function () {
            editModal.style.display = "flex";
        }
    });
}