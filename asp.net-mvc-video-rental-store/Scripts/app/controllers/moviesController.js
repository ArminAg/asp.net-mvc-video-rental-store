
var MoviesController = function (movieService) {
    var table;
    var button;
    var url = "/api/movies";

    var init = function (container, isReadonly) {
        var container = $(container);
        if (isReadonly) {
            table = container.DataTable(dataTableReadOnlySettings);
        } else {
            table = container.DataTable(dataTableSettings);
            container.on("click", ".js-delete", deleteMovie);
        }
    }

    var dataTableReadOnlySettings = {
        ajax: {
            url: "/api/movies",
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "genre.name"
            }
        ]
    };

    var dataTableSettings = {
        ajax: {
            url: url,
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, movie) {
                    return "<a href='/movies/edit/" + movie.id + "'>" + movie.name + "</a>";
                }
            },
            {
                data: "genre.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-movie-id=" + data + ">Delete</button>";
                }
            }
        ]
    };

    var deleteMovie = function (e) {
        button = $(e.target);
        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
            if (result) {
                var movieId = button.attr("data-movie-id");
                movieService.deleteMovie(url, movieId, success);
            }
        })
    }

    var success = function () {
        table.row(button.parents("tr"))
            .remove()
            .draw();
    }

    return {
        init: init
    }

}(MovieService);