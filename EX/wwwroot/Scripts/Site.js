function GetCities() {
    $.ajax({
        url: "https://localhost:7137/City",
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
        $("#esito").html("Fatto!");
    })
}

function GetCity() {
    $.ajax({
        url: "https://localhost:7137/City",
        method: "GET"
    }).done(function (result) {
        var s = document.getElementById("cityname").value;
        result.forEach(x => {
            if (x.name == s)
            {
                $("#CityTable").html(`<tr>
                <td>${x.name} </td>
                <td>${x.province}</td>
                <td>${x.country}</td>
                <td>${x.postalCode}</td>
              </tr>`);
            }
        })  
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Fatto!");
    })
}

    function GetPeople() {
        $.ajax({
            url: "https://localhost:7137/Person",
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
    }
