//$(document).ready(function () {
//    $('#magia').mouseenter(function () {
//        $('#divAutenticacion').fadeOut();
//        $('#Div1').fadeIn();

//    });

//});


$(function () {
    var form = $('#loginForm');


    form.submit(function () {
        var form = $(this);
        var credentialsPost = { sId: $('#usuarioId').val(), sPassword: $('#password').val() };
        var jsonPost = JSON.stringify(credentialsPost);
        jQuery.support.cors = true;

        $.ajax({
            url: '/api/login',
            type: 'POST',
            data: jsonPost,
            datatype: "json",
            processData: false,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                var resultadoPost = result.resultado;
                if (result.correcto) {
                    //var credentialsGet = { token: resultadoPost };
                    //var jsonGet = JSON.stringify(credentialsGet);

                    //debugger;
                    $.ajax({
                        url: "api/perfil?token=" + resultadoPost,
                        type: 'GET',
                        //data: jsonGet,
                        dataType: 'json',
                        processData: false,
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            //debugger;

                            if (data.correcto) {
                                var perfil = data.perfil;
                                
                                var strTablaPerfil = "<table border=\"1\";><tr><td colspan=\"5\">Información del usuario</td></tr><tr style=\"font-style:italic;\"><td>Nombre</td><td>Apellidos</td><td>Email</td><td>Dirección</td><td>Teléfono</td>";
                                strTablaPerfil += "<tr><td>" + perfil.sNombre + "</td><td> " + perfil.sApellidos + "</td><td>" + perfil.sEmail + "</td><td>" + perfil.sDireccion + "</td><td>" + perfil.sTelefono + "</tr>";
                                strTablaPerfil += "</table>";
                                $("#divPerfil").html(strTablaPerfil);
                            }
                            else {
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

                    //$.getJSON("api/perfil?token=" + resultadoPost,
                    //    function (data) {
                    //        if (data.correcto) {
                    //            debugger;

                    //            var perfil = data.resultado;
                    //            alert(perfil);
                    //            var strTablaPerfil = "<table><tr><td>Nombre</td><td>Apellidos</td><td>Email</td><td>Dirección</td><td>Teléfono</td>";
                    //            strTablaPerfil += "<tr><td>" + perfil.sNombre + "</td><td> " + perfil.sApellidos + "</td><td>" + perfil.sEmail + "</td><td>" + perfil.sDireccion + "</td><td>" + perfil.sTelefono + "</tr>";
                    //            strTablaPerfil += "</table>";
                    //            $("#divPerfil").html(strTablaPerfil);
                    //        }
                    //    })
                    //     // Handle a fail 
                    //    .fail(
                    //        function (jqXHR, textStatus, err) {
                    //            $('#info').html('Error: ' + err);
                    //        });
                }
                else {
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