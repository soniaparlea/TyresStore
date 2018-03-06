function displayTires(tyresHtml) {
    $(".vehicle-table").addClass("new-size");
   // $("right.icon").addClass("visible");

    
    

    $(".tyre-table .table-content").html("");
    var htmlContent = tyresHtml;

    if (tyresHtml.length > 0)
        $(".tyre-table .table-content").append(htmlContent);
    else
        $(".tyre-table .table-content").append("<span class='no-data-message'> No tyres available </span>");

}

window.onload = function () {
    mainModel = new MainModel();
}