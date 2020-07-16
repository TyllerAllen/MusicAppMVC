var Genres = [];

$.post("/genres", null, function (data) {
    Genres = data;
});

var AlbumArtPaths = [],
    FileNames = [],
    Titles = [],
    Artists = [],
    dataTable = $('#DT_load').DataTable({
        "columns": [
            {
                "searchable": false,
                "width": "5%"
            },
            {
                "orderable": false,
                "searchable": false,
                "className": "albumArtPath",
                "width": "15%"
            },
            {
                "className": "fileName",
                "width": "20%"
            },
            {
                "className": "title",
                "width": "20%"
            },
            {
                "className": "artist",
                "width": "20%"
            },
            {
                "className": "genre",
                "width": "20"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });

function changeText(event) {
    if (!$('#DT_load').hasClass("editing")) {
        $('#DT_load').addClass("editing");
        var thisCell = dataTable.cell(this);
        thisCell.data($("<input></input>", {
            "class": event.data.className,
            "type": "text",
            "value": thisCell.data(),
        }).prop("outerHTML"));
    }
}

function saveText(event) {
    // ENTER key code === 13
    if (event.which === 13 || event.type === "mouseleave") {
        dataTable.cell($(event.data.className).parents('td')).data($(event.data.className).val().trim());
        $('#DT_load').removeClass("editing");
    }
}

$('.fileName')
    .click({ className: "changeFileName" }, changeText)
    .keydown({className: ".changeFileName"}, saveText)
    .mouseleave({className: ".changeFileName"}, saveText);
$('.title')
    .click({ className: "changeTitle" }, changeText)
    .keydown({ className: ".changeTitle" }, saveText)
    .mouseleave({ className: ".changeTitle" }, saveText);;
$('.artist')
    .click({ className: "changeArtist" }, changeText)
    .keydown({ className: ".changeArtist" }, saveText)
    .mouseleave({ className: ".changeArtist" }, saveText);;

$('#DT_load tbody').on('click', '.genre', function () {
    if (!$('#DT_load').hasClass("editing")) {
        $('#DT_load').addClass("editing");
        var thisCell = dataTable.cell(this);
        thisCell.data($("<select></select>", {
            "class": "changeGenre"
        }).append(Genres.map(value => $("<option></option>", {
            "text": value,
            "value": value,
            "selected": (value === thisCell.data())
        }))).prop("outerHTML"));
    }
});

$('#DT_load tbody').on('mouseleave', '.genre', () => {
    dataTable.cell($(".changeGenre").parents('td')).data($(".changeGenre").val());
    $('#DT_load').removeClass("editing");
});