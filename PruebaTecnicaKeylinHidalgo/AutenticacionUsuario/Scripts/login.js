$(function () {
    var form = $('#loginForm');
    form.submit(function () {
        var form = $(this);
        var comment = { sId: $('#usuarioId').val(), sPassword: $('#password').val() };
        var json = JSON.stringify(comment);

        $.ajax({
            url: '/api/login',
            cache: false,
            type: 'POST',
            data: json,
            contentType: 'application/json; charset=utf-8',
            statusCode: {
                201 /*Created*/: function (data) {
                    viewModel.comments.push(data);
                }
            }
        });

        return false;
    });
});