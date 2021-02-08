//Function sends an array to the Contoller and returns a new array with an additional property (Pretending to make a DB call)
function GetStudents(container)
{
    var sp = $(container).find("select.students-select");
    var flag = $(sp).selectpicker('val');

    $.ajax({
        url: '/Student/GetStudents',
        type: 'POST',
        dataType: 'json',
        data: {
            flagString: flag,
        },
        success: function (retData) {
            console.log(retData);

            var targetTable = $(container).find(".students-table");
            var targetTableData = {
                "cols": retData.cols,
                "data": retData.data,
                "HiddenFields": ""
            };

            //Destroy table with old data
            $(targetTable).bootstrapTable('destroy');

            //Load a new table with new data
            BootstrapTable_SetColumnsAndData(targetTable, targetTableData);
        },
        error: function (retData) {
            console.log(retData);  
        }
    });
};

$(document).on('changed.bs.select', 'select.students-select', function () {
    var container = $(this).closest(".container");
    GetStudents(container);
});