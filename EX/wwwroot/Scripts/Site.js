
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


GetPeople() {
        $.ajax({
            url: "Api/Person",
            method: "GET"
        }).done(function (result) {
            if (result)
                $("#PersonTable").html(result.map(item => `<tr>
                <td>${item.FirstName} </td>
                <td>${item.LastName}</td>
                <td>${item.age}</td>
                <td>${item.address.street}</td>
                <td>${item.address.number}</td>

              </tr>`));
        }).fail(function () {
            alert("ERRORE!");
        }).always(function () {
            $("#esito").html("Tasto schiacciato");
        })


        