$(function() {
    $(document).ready(function () {
        $('#logout').click(function () {

            //Llamado al método logout
            $.ajax({
                url: "api/logout?token=" + $('#sessionToken').val(),
                type: 'DELETE',
                dataType: 'json',
                processData: false,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    //Si la transacción se realizó correctamente
                    if (data.correcto) {

                        //Se presenta la parte de autenticación
                        $('#divLogout').fadeOut('slow');
                        $('#divDatosUsuario').fadeOut('slow');
                        $('#divAutenticacion').delay(500).fadeIn('slow');

                        //Se borran los datos de la tabla
                        var strTablaPerfil = "<table><tr><td></td></tr></table>";
                        $("#divPerfil").html(strTablaPerfil);

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

        return false;
        });
    });
});
