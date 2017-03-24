
var CustomerService = function () {

    var deleteCustomer = function (url, customerId, success) {
        $.ajax({
            url: url + "/" + customerId,
            method: "DELETE",
            success: success
        });
    }

    return {
        deleteCustomer: deleteCustomer
    }
}();