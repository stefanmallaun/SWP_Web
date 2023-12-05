
function validateAndSubmit() {
    // Formulardaten abrufen
    var name = document.getElementById("Name").value;
    var email = document.getElementById("Email").value;
    var pwd = document.getElementById("Pwd").value;
    var pwdRetype = document.getElementById("PwdRetype").value;
    var birthdate = document.getElementById("Birthdate").value;

    // Hier füge deine Überprüfungen entsprechend den Serverkriterien hinzu
    var isValid = true;

    // Beispiel: Einfache Überprüfung, dass alle Felder ausgefüllt sind
    if (name.trim() === "" || email.trim() === "" || pwd.trim() === "" || pwdRetype.trim() === "" || birthdate.trim() === "") {
        isValid = false;
        alert("Bitte füllen Sie alle Pflichtfelder aus.");
    }

    // Überprüfung, ob die E-Mail ein '@' enthält
    if (email.indexOf('@') === -1) {
        isValid = false;
        alert("Die E-Mail-Adresse muss ein '@' enthalten.");
    }

    // Überprüfung, ob das Passwort mindestens ein Sonderzeichen enthält
    var specialCharacterRegex = /[!@#$%^&*(),.?":{}|<>]/;
    if (!specialCharacterRegex.test(pwd)) {
        isValid = false;
        alert("Das Passwort muss mindestens ein Sonderzeichen enthalten.");
    }

    // Weitere Überprüfungen können hier hinzugefügt werden

    // Wenn alles in Ordnung ist, das Formular an den Server senden
    if (isValid) {
        document.getElementById("registrationForm").submit();
    }
}
