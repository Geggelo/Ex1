
GetCities() {
    $.ajax({
        url: "Api/City",
        method: "GET"
    }).done(function (result) {
        if (result)
            $("#CityTable").html(result.map(item => `<tr>
                <td>${item.name} </td>
                <td>${item.province}</td>
                <td>${item.country}</td>
                <td>${item.postalcode}</td>
              </tr>`));
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Tasto schiacciato");
    })
