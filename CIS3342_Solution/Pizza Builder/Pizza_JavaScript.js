
function submitForm() {
    var name = document.getElementById("username").value;
    var phone = document.getElementById("phoneNumber").value;
    var address = document.getElementById("address").value;

    var selectedSize = document.getElementById("selectedSize").selected;
    var selectedCrust = document.getElementById("selectedCrust").selected;
    var selectedSauce = document.getElementById("selectedSauce").selected;

    var familyMealYes = document.getElementById("familyMealYes").checked;
    var soda = document.getElementById("selectedSoda").selected;
    var sides = document.getElementById("selectedSides").selected;

    if (name == "" || phone == "" || address == "" || selectedSize == true || selectedCrust == true || selectedSauce == true) {
        alert("Please fill out the whole form");
    }
    else if (familyMealYes == true && (soda == true || sides == true)) {
        alert("Please select your soda and side");
    }
    else {
        document.getElementById("pizzaForm").submit();
    }
}