$(function () {
    var form = $('#loginForm');

    form.submit(function () {
        var form = $(this);

        //Credenciales del usuario
        var usuarioId = $('#usuarioId').val();
        var password = $('#password').val();

        //Si no ingresa correctamente las credenciales
        if (usuarioId == "" || password == "")
        {
            $(function () {
                $("#dialogError").html("<span> Favor ingresar los datos solicitados. </span>");
                $("#dialogError").dialog();
            });

            return false;
        }

        //Se crea el json con los credenciales
        var credentialsPost = { sId: usuarioId, sPassword: password };
        var jsonPost = JSON.stringify(credentialsPost);
        jQuery.support.cors = true;

        //Llamado al método de login
        $.ajax({
            url: '/api/login',
            type: 'POST',
            data: jsonPost,
            datatype: "json",
            processData: false,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                //Resultado, ya sea el mensaje de error o el token
                var resultadoPost = result.resultado;

                //Si la transacción se realizó correctamente
                if (result.correcto) {
                    //Se asigna el token a un campo hidden para la utilización en el logout
                    $('#sessionToken').val(resultadoPost);

                    //Se llama al método para obtener los datos del perfil
                    $.ajax({
                        url: "api/perfil?token=" + resultadoPost,
                        type: 'GET',
                        dataType: 'json',
                        processData: false,
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {

                            //Si la transacción se realizó correctamente
                            if (data.correcto) {
                                //Se obtienen los datos del perfil
                                var perfil = data.perfil;
                                
                                //Se llena la tabla html con la información
                                var strTablaPerfil = "<table border=\"1\";><tr style=\"font-style:italic; font-weight: bold; border-bottom: 2px solid #707070;\"><td>Nombre</td><td>Apellidos</td><td>Email</td><td>Dirección</td><td>Teléfono</td>";
                                strTablaPerfil += "<tr><td>" + perfil.sNombre + "</td><td> " + perfil.sApellidos + "</td><td>" + perfil.sEmail + "</td><td>" + perfil.sDireccion + "</td><td>" + perfil.sTelefono + "</tr>";
                                strTablaPerfil += "</table>";
                                $("#divPerfil").html(strTablaPerfil);

                                //Se reinician las credenciales del usuario
                                $('#usuarioId').val("");
                                $('#password').val("");

                                //Manejo de los div
                                $('#divAutenticacion').fadeOut('slow');
                                $('#divLogout').delay(500).fadeIn('slow');
                                $('#divDatosUsuario').delay(500).fadeIn('slow');
                            }
                            else {
                                //Mensaje de error
                                $(function () {
                                    $("#dialogError").html("<span>" + data.resultado + "</span>");
                                    $("#dialogError").dialog();
                                });
                            }
                        },
                        error: function (x, y, z) {
                            alert(x + '\n' + y + '\n' + z);
                        }
                    });
                }
                else {
                    //Mensaje de error
                    $(function () {
                        $("#dialogError").html("<span>" + resultadoPost + "</span>");
                        $("#dialogError").dialog();
                    });
                }
            }
        });

        return false;
    });
});