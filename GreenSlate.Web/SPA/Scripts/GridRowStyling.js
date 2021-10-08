function onDataBound() {
    var grid = $("#ToDoGrid").data("kendoGrid");
    var data = grid.dataSource.data();
    $.each(data, function (i, row) {
        if (row.Completed) {
            $('tr[data-uid="' + row.uid + '"] ').css("background-color", "darkseagreen");
        } else {
            $('tr[data-uid="' + row.uid + '"] ').css("background-color", "palevioletred");
        }
    })
}