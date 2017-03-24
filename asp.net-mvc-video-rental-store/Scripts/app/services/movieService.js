
var MovieService = function () {

    var deleteMovie = function (url, movieId, success) {
        $.ajax({
            url: url + "/" + movieId,
            method: "DELETE",
            success: success
        });
    }

    return {
        deleteMovie: deleteMovie
    }
}();