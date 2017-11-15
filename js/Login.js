function login() {
    var Email = document.getElementById('txtEmail').value;
    var Password = document.getElementById('txtPassword').value;

    if (Email != '' && Password != '') {
        var data = '{ "email":"'+Email+'", "password":"'+Password+'" }';

        $.ajax({
            type: "POST",
            url: "Login.aspx/login",
            contentType: "application/json; charset=utf-8",
            datatype: "jason",
            data: data,
            success: function (result) {
                var respuesta = result.d;
                if (respuesta > 0) {
                    console.log("Funciono");
                }
                else {
                    console.log("No")
                }
            },
            error: function (result) {
                console.log("Error");
                var respuesta = result.d;
                console.log(respuesta);
            }
        });
    }
    else {
        alert("Faltan campos por completar");
    }
}