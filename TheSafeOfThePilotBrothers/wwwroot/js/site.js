function toggleCell(cellId, row, col) {
    $.ajax({
        type: "POST",
        url: "?handler=OnPostToggleChangeColor",
        data: { row: row, col: col },
        success: function (response) {
            var backgroundColor = (response === "1") ? "green" : "red";
            document.getElementById('@cellId').style.backgroundColor = backgroundColor;
        },
    });
}
