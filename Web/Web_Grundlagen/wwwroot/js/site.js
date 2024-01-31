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
        alert("Muss ein '@' enthalten");
        return false;
    }
    else {
        return true;
    }
}

function validatePassword() {
    var pw = document.getElementById("Pwd").value;

    if (pw.length < 3) {
        alert("Passwort muss mindestens 4 Zeichen lang sein.");
        return false;
    }
    var specialCharacterRegex = /[!@#$%^&*(),.?":{}|<>]/;
    if (!specialCharacterRegex.test(pw)) {
        
        alert("Das Passwort muss mindestens ein Sonderzeichen enthalten.");
        return false;
    }
    else {
        return true;
    }
}

function validatePasswordRetype() {
    var pw = document.getElementById("Pwd").value; 
    var pwRetype = document.getElementById("PwdRetype").value;

    if (pwRetype.indexOf(pw)) {
        alert("Stimmt mit Password nicht überein!");
        return false;
    }
    else {
        return true;
    }
}
function validateBD() {
    var bd = document.getElementById("Birthdate").value;
    if (bd > Date.now()) {
        alert("Geben Sie ein richtiges Geburtsdatum ein!");
        return false;
    } else {
        return true;
    }
}
function submit() {
    if (validateName && validateEmail && validatePassword && validatePasswordRetype && validateBD) {
        document.getElementById("registrationForm").submit();
    }
}

//AJAX

/*
function showUser(selectedValue) {
    if (selectedValue === 'all') {
        $.ajax({
            url: '/api/user/ShowAllUser',
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                var tableHtml = '<thead><tr><th>Name</th><th>Email</th><th>Birthdate</th><th>Role</th><th>Action</th></tr></thead><tbody>';
                data.forEach(function (user) {
                    tableHtml += '<tr><td>' + user.name + '</td><td>' + user.email + '</td><td>' + user.birthdate + '</td><td>' + user.role + '</td><td><a href="/User/EditUser/' + user.email + '" class="btn btn-primary">Edit</a></td></tr>';
                });
                tableHtml += '</tbody>';
                $('#userTable').html(tableHtml);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
                console.log('Status: ' + textStatus);
                console.log('Error: ' + errorThrown);
                console.log('Response: ' + xhr.responseText);
            }
        });
    }
    if (selectedValue == 'registeredUser') {
        $.ajax({
            url: '/api/user/showRegisteredUser',
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                var tableHtml = '<thead><tr><th>Name</th><th>Email</th><th>Birthdate</th><th>Role</th><th>Action</th></tr></thead><tbody>';
                data.forEach(function (user) {
                    tableHtml += '<tr><td>' + user.name + '</td><td>' + user.email + '</td><td>' + user.birthdate + '</td><td>' + user.role + '</td><td><a href="/User/EditUser/' + user.email + '" class="btn btn-primary">Edit</a></td></tr>';
                });
                tableHtml += '</tbody>';
                $('#userTable').html(tableHtml);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
                console.log('Status: ' + textStatus);
                console.log('Error: ' + errorThrown);
                console.log('Response: ' + xhr.responseText);
            }
        });
    }
    if (selectedValue == 'Admin') {
        $.ajax({
            url: '/api/user/showAdminUsers',
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                var tableHtml = '<thead><tr><th>Name</th><th>Email</th><th>Birthdate</th><th>Role</th><th>Action</th></tr></thead><tbody>';
                data.forEach(function (user) {
                    tableHtml += '<tr><td>' + user.name + '</td><td>' + user.email + '</td><td>' + user.birthdate + '</td><td>' + user.role + '</td><td><a href="/User/EditUser/' + user.email + '" class="btn btn-primary">Edit</a></td></tr>';
                });
                tableHtml += '</tbody>';
                $('#userTable').html(tableHtml);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
                console.log('Status: ' + textStatus);
                console.log('Error: ' + errorThrown);
                console.log('Response: ' + xhr.responseText);
            }
        });
    }
    
}
*/
function showUser() {
    
        $.ajax({
            url: '/api/user/ShowAllUser',
            type: 'GET',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                var dropDownHtml = '<select id="roleDropdown" onchange="showUser(this.value)" class="form-control">';
                data.forEach(function (user) {
                    dropDownHtml += 'option value="' + user.role + '"> <' + user.role + '</option>';
                  
                });
                dropDownHtml += '</tbody>';
                $('#dropDown').html(dropDownHtml);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
                console.log('Status: ' + textStatus);
                console.log('Error: ' + errorThrown);
                console.log('Response: ' + xhr.responseText);
            }
        });
}
