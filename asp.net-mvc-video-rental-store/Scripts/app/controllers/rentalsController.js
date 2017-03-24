
var RentalsController = function (rentalService) {
    var customersUrl = "/api/customers";
    var moviesUrl = "/api/movies";
    var rentalsUrl = "/api/rentals";
    var validator;

    var vm = {
        movieIds: []
    };

    var init = function () {
        typeaheadSetup('#customer', 'customers', 'name', customersUrl, selectCustomer);
        typeaheadSetup('#movie', 'movies', 'name', moviesUrl, selectMovie);

        $.validator.addMethod("validCustomer", validCustomer, "Please select a valid customer.");
        $.validator.addMethod("atLeastOneMovie", atLeastOneMovie, "Please select at least one Movie.");

        validator = $("#newRental").validate({ submitHandler: submitHandler });
    };

    // Form Handling
    var submitHandler = function () {
        rentalService.saveData(rentalsUrl, done, fail, vm);
        return false;
    }

    var done = function () {
        toastr.success("Rentals successfully recorded.");
        $("#customer").typeahead("val", "");
        $("#movie").typeahead("val", "");
        $("#movies").empty();

        vm = { movieIds: [] };

        validator.resetForm();
    };

    var fail = function () {
        toastr.error("Something unexpected happened.");
    };

    // Typeahead
    var typeaheadSetup = function (selector, objectName, displayAttribute, url, selectFunction) {
        $(selector).typeahead({
            minLength: 3,
            highlight: true
        }, {
            name: objectName,
            display: displayAttribute,
            source: getSource(url)
        }).on("typeahead:select", selectFunction);
    };

    var getSource = function (url) {
        return new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            remote: {
                url: url + '?query=%QUERY',
                wildcard: '%QUERY'
            }
        });
    };

    var selectCustomer = function (e, customer) {
        vm.customerId = customer.id;
    };

    var selectMovie = function (e, movie) {
        $("#movies").append("<li class='list-group-item'>" + movie.name + "</li>");
        $("#movie").typeahead("val", "");
        vm.movieIds.push(movie.id);
    };

    // Validation
    var validCustomer = function () {
        return vm.customerId && vm.customerId != 0;
    };

    var atLeastOneMovie = function () {
        return vm.movieIds.length > 0;
    };

    return {
        init: init
    }
}(RentalService);