$(document).ready(function () {
    GetUserRole();
});


function AddProductAnonym(el) {


    /// <summary>
    /// Adds the product for unknown user.
    /// </summary>
    /// <param name="el">The produtc id.</param>

    var id = $(el).attr('data-item');

    var cart = {
        Owner: $('#name').val(),
        Phone: $('#phone').val()
    };

    $.ajax({
        url: '/api/ShoppingCartAPI/AddProductAnonym/' + id,
        type: 'PUT',
        data: JSON.stringify(cart),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            HideForm();
            ShowSuccess();
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function AddProductUser(el) {

    /// <summary>
    /// Adds the product for identified user..
    /// </summary>
    /// <param name="el">The buyer name.</param>

    var id = $(el).attr('data-item');
    var userLogin = $(el).attr('data-user');

    $.ajax({
        url: '/api/ShoppingCartAPI/AddProductUser/' + id,
        type: 'PUT',
        data: JSON.stringify(userLogin),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            ShowSuccess();
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function ShowForm() {
    /// <summary>
    /// Shows the form.
    /// </summary>

    $("#addToCartForm").show("slow");
}

function HideForm() {
    /// <summary>
    /// Hides the form.
    /// </summary>

    $("#addToCartForm").hide("slow");
}

function ShowSuccess() {
    /// <summary>
    /// Shows the success block.
    /// </summary>

    $("#succes").show("slow");
    setTimeout(function () {
        $("#succes").hide("slow");
    }, 3000);
}

function PurchaseProduct() {
    /// <summary>
    /// Purchases the product.
    /// </summary>

    $.ajax({
        url: '/api/ShoppingCartAPI/PurchaseProducts/',
        type: 'PUT',
        success: function (data) {
            $("#shoppingCart").hide("fast");
            $("#tyForPurchase").show("slow");
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function DeleteProduct(el) {
    /// <summary>
    /// Deletes the product.
    /// </summary>
    /// <param name="el">The product id.</param>

    id = $(el).attr('data-item');

    $.ajax({
        url: '/api/ShoppingCartAPI/DeleteProduct/' + id,
        type: 'DELETE',
        success: function (data) {
            window.location.href = "/ShoppingCart/ShowCart";
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function DisableSearch() {
    /// <summary>
    /// Disables the search if string is empty.
    /// </summary>

    $('input[type="submit"]').prop('disabled', true);
    $('input[type="text"]').keyup(function () {
        if ($(this).val() != '' && $(this).val() != ' ') {
            $('input[type="submit"]').prop('disabled', false);
        }
    });
}

function GetUserRole() {
    /// <summary>
    /// Gets the user role.
    /// </summary>

    $.ajax({
        url: '/api/ShoppingCartAPI/GetUserRole/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data != "Admin") {
                $("#options").css('display', 'none');
            }
            else {
                $("#options").css('display', 'block');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function GetProductInfo(el) {

    /// <summary>
    /// Gets the product information.
    /// </summary>
    /// <param name="el">The product id.</param>
    /// <returns></returns>

    var id = $(el).attr("data-item");

    $.ajax({
        url: '/api/ProductAPI/GetProductInfo/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowProductInfo(data);
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function ShowProductInfo(data) {

    /// <summary>
    /// Shows the product information.
    /// </summary>
    /// <param name="data">The product object.</param>

    if (data != null) {
        $("#productName").text(data.Name);
        $("#productImage").attr("src", data.Characteristics['Image'])
        $("#producPrice").text(data.Characteristics['Price']);
        $("#productType").text(data.ProductType);
    }
    else {
        alert("Error");
    }

}

