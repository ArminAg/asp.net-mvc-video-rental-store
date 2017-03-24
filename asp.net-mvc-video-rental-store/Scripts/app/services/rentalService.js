

var RentalService = function () {
    var saveData = function (url, done, fail, vm) {
        $.ajax({
            url: url,
            method: "post",
            data: vm
        })
        .done(done)
        .fail(fail);
    }

    return {
        saveData: saveData
    }
}();