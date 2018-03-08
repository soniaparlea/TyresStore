function displayTires(tyresHtml) {
    $(".vehicle-table").addClass("new-size");
   // $("right.icon").addClass("visible");

    
    

    $(".tyre-table .table-content").html("");
    var htmlContent = tyresHtml;

    $('.header-table-tyres').show();

    if (tyresHtml.length > 0)
        $(".tyre-table .table-content").append(htmlContent);
    else
        $(".tyre-table .table-content").append("No tyres available");

}

function updateCartCount() {
    $(".cart-button").html("(" + basketModel.basketItems.length + ")");
}

window.onload = function () {
    mainModel = new MainModel();
}