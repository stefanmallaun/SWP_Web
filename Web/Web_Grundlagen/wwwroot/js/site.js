
function validateNameAndSubmit() {
    // Formulardaten abrufen
    var name = document.getElementById("Name").value;
    var email = document.getElementById("Email").value;
    var pwd = document.getElementById("Pwd").value;
    var pwdRetype = document.getElementById("PwdRetype").value;
    var birthdate = document.getElementById("Birthdate").value;

    
    var isValid = true;

    
    if (name.trim() === "" || email.trim() === "" || pwd.trim() === "" || pwdRetype.trim() === "" || birthdate.trim() === "") {
        isValid = false;
        alert("Bitte füllen Sie alle Pflichtfelder aus.");
    }

    // Überprüfung, ob die E-Mail ein '@' enthält
    if (email.indexOf('@') === -1) {
        isValid = false;
        alert("Die E-Mail-Adresse muss ein '@' enthalten.");
    }

    
    var specialCharacterRegex = /[!@#$%^&*(),.?":{}|<>]/;
    if (!specialCharacterRegex.test(pwd)) {
        isValid = false;
        alert("Das Passwort muss mindestens ein Sonderzeichen enthalten.");
    }

    if (isValid) {
        document.getElementById("registrationForm").submit();
    }
}

function validateName() {
    var name = document.getElementById("Name").value;

    if (name === "") {
        alert("Bitte füllen Sie das Pflichtfeld aus.");
        return false;
    }
    else {
        return true;
    }
}
function validateEmail() {
    var email = document.getElementById("Email").value;

    if (email.indexOf('@') === -1) {
        alert("Bitte füllen Sie das Pflichtfeld aus.");
        return false;
    }
    else {
        return true;
    }
}
function submit() {
    if (validateEmail && validateName) {
        document.getElementById("registrationForm").submit();
    }
}

//AJAX

