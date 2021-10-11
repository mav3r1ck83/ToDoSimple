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

function onEdit(e) {
    $('[name="Id"]').attr("readonly", true);
    $('[name="Created_By"]').attr("readonly", true);
}

function onGridEdit(e) {
    e.sender.one("dataBound", function (e) {
        e.sender.dataSource.read();
    });
}