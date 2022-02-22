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

//function CreatePerson() {
//    var firstName = $("#firstname").value;
//    var lastName = $("#lastname").value;
//    var age = $("#age").value;
//    var address = $("#address").value;
//    var cityName = $("#city").value;
//    $.ajax({
//        url: "https://localhost:7137/" + "Person?firstName=" + firstName + "&lastName=" + lastName + "&age=" + age + "&address=" + address "&cityName=" + cityName,
//        method: "POST"
//    }).done(function () {
//        alert("dsafas");
//    });
//}

//function CreatePerson() {
//    var fn = document.getElementById("firstname").value;
//    var ln = document.getElementById("lastname").value;
//    var a = document.getElementById("age").value;
//    var ass = document.getElementById("address").value;
//    var c = document.getElementById("city").value;
//    $.post("https://localhost:7137/Person",
//        { firstName: "${fn}", lastName: "${ln}", age: "${a}", address: "${ass}", cityName: "${c}" }).done(function (response) {
//        alert("success");
//    });
//}


