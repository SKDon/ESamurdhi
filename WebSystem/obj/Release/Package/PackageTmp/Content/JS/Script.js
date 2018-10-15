function validateForm() {
    var x = document.forms["NewAccountForm"]["AccNo"].value;
    if (x == "" || x == null) {
        alert("Name must be filled out");
        return false;
    }
}