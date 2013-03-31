$(function () {
    // We're using a Knockout model. This clears out the existing comments.
    viewModel.comments([]);

    var url = "/api/perfil?$token=1";

    $.getJSON('/api/comments', function (data) {
        // Update the Knockout model (and thus the UI) with the comments received back 
        // from the Web API call.
        viewModel.comments(data);
    });
});
