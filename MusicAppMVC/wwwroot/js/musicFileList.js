var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/musicfiles/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "isChecked",
                "render": function (data) {
                    return `<input type="checkbox" ` + (data ? "checked" : "") + `/>`;
                }, "width": "5%"
            },
            {
                "data": "albumArtPath",
                "render": function (data) {
                    return `<img src="../images/` + (data === null ? "noimage.webp" : data) + `" asp-append-version="true" height="50" width="50" />`;
                }, "width": "15%"
            },
            { "data": "fileName", "width": "20%" },
            { "data": "title", "width": "20%" },
            { "data": "artist", "width": "20%" },
            { "data": "genre", "width": "20" }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}