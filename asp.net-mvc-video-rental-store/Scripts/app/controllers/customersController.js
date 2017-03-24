
var CustomersController = function (customerService) {
    var table;
    var button;
    var url = "/api/customers";

    var init = function (container) {
        var container = $(container);
        table = container.DataTable(dataTableSettings);
        container.on("click", ".js-delete", deleteCustomer);
    };

    var dataTableSettings = {
        ajax: {
            url: url,
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    };

    var deleteCustomer = function (e) {
        button = $(e.target);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                var customerId = button.attr("data-customer-id");
                customerService.deleteCustomer(url, customerId, success);
            }
        });
    }

    var success = function () {
        table.row(button.parents("tr"))
                    .remove()
                    .draw();
    }

    return {
        init: init
    }

}(CustomerService);