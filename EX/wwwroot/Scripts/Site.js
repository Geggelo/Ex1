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
                <td>${item.postalCode}</td>
              </tr>`));
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Fatto!");
    })
}

function GetCity() {
    var s = document.getElementById("cityname").value;
    $.ajax({
        url: "https://localhost:7137/City/" + s,
        method: "GET"
    }).done(function (result) {
        $("#CityTable").html(`<tr>
        <td>${result.name} </td>
        <td>${result.province}</td>
        <td>${result.country}</td>
        <td>${result.postalCode}</td>
        </tr>`); 
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Fatto!");
    })
}

//-------------------------------------------------------------------------------------------------------------------
function GetPeople() {
    $.ajax({
        url: "https://localhost:7137/Person",
        method: "GET"
    }).done(function (result) {
        if (result)
            $("#PersonTable").html(result.map(item => `<tr>
            <td>${item.firstName} </td>
            <td>${item.lastName}</td>
            <td>${item.age}</td>
            <td>${item.address}</td>
            </tr>`));
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Tasto schiacciato");
    })
}

function GetPerson() {
    var s = document.getElementById("personName").value;
    $.ajax({
        url: "https://localhost:7137/Person/" + s,
        method: "GET"
    }).done(function (result) {
        $("#CityTable").html(`<tr>
        <td>${result.firstName} </td>
        <td>${result.lastName}</td>
        <td>${result.age}</td>
        <td>${result.address}</td>
        </tr>`);
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Fatto!");
    })
}
