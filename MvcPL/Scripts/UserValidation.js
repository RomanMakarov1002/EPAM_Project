$('#txtid').keyup(loginCheck);
$('#txtEmail').keyup(emailCheck);

var loginOk = false;
var emailOk = false;

function loginCheck() {
    var login = document.getElementById('txtid').value;
    $.ajax({
        type: "POST",
        url: "/User/SearchNickName",
        data: { NickName: login },
        dataType: "json",
        success: IsLoginOk
    });
}

function IsLoginOk(exist) {
    if (exist)
        document.getElementById('mesforNickname').innerHTML = "";
    else {
        document.getElementById('mesforNickname').innerHTML = "This NickName already exist";
    }
    loginOk = exist;
}

function emailCheck() {
    var email = document.getElementById('txtEmail').value;
    $.ajax({
        type: "POST",
        url: "/User/SearchEmail",
        data: { Email: email },
        dataType: "json",
        success: IsEmailOk
    });
}
function IsEmailOk(exist) {
    if (exist)
        document.getElementById('mesforEmail').innerHTML = "";
    else {
        document.getElementById('mesforEmail').innerHTML = "This email already exist";
    }
    emailOk = exist;
}

function LoadPicture() {
    var previw = document.getElementById('PictureImg');
    var file = document.getElementById('PictureInput').files[0];
    var reader = new FileReader();

    reader.onloadend = function() {
        previw.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        previw.src = "";
    }
}

