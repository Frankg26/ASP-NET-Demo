//Event toggles the active page on the main navbar
$(document).on("click", ".navbar-nav .nav-link", function () {
    $('.navbar-nav .nav-link').removeClass('active');
    $(this).addClass('active');
});

//Function loads the the data and columns into the Bootstrap Table
function BootstrapTable_SetColumnsAndData(targetTable, targetTableData) {

    //Bootstrap Table requires its columns to be passed in an array
    var cols = [];
    $.each(targetTableData.cols, function (idx, val) {
        if (idx === "checkbox") {
            cols.push(
                {
                    field: idx,
                    title: "",
                    sortable: false,
                    checkbox: true
                });
        }
        else {
            cols.push(
                {
                    field: idx,
                    title: val,
                    sortable: true
                });
        }
    });

    //set Bootstrap Table Column
    $(targetTable).bootstrapTable({
        columns: cols
    });

    //Load the data into the Bootstrap Table
    $(targetTable).bootstrapTable('load', targetTableData.data);
    $(targetTable).bootstrapTable('hideLoading');
}
