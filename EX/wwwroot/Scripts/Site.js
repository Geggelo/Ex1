//Funziona tutto, stampa tutte le città ed i dati
//bottone con puntini mostra tutti i cittadini della città
//bottone con cestino elimina la città e cittadini
function GetCities() {
    $.ajax({
        url: "https://localhost:7137/City",
        method: "GET"
    }).done(function (result) {
        if (result)
            $("#citiesTable").html(result.map(item => `<tr>
                <td>${item.name}</td>
                <td>${item.province}</td>
                <td>${item.country}</td>
                <td>${item.postalCode}</td>
                <td><button type="button" class="btn btn-secondary" onclick="GetCityPeople('${item.id}')"
                <i class="bi bi-three-dots"></i>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-three-dots" viewBox="0 0 16 16">
                <path d="M3 9.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3zm5 0a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z"/>
                </svg></button>

                <button type="button" class="btn btn-success" onclick="CityPopUp()">
                <i class="bi bi-plus-circle"></i>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle" viewBox="0 0 16 16">
                <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/><path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                </svg></button>

                <button type="button" class="btn btn-danger" onclick="DeleteCity('${item.id}')"
                <i class="bi bi-trash3"></i>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
                <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
                </svg></button>
                
                </td>
                </tr>`));
                $("#cities").show();
                $("#people").hide();
    }).fail(function () {
        alert("ERRORE!");
    })
}

//viene chiamato con il bottone con tre puntini
//bottone con freccia fa tornare indietro
//bottone con cestino elimina la persona
function GetCityPeople(id) {
    $.ajax({
        url: "https://localhost:7137/City/" + id,
        method: "GET"
    }).done(function (result) {
        if (result)
        {
            $("#peopleTable").html(result.people.map(x => `<tr>
            <td>${x.firstName} </td>
            <td>${x.lastName}</td>
            <td>${x.age}</td>
            <td>${x.address}</td>

            <td><button type="button" class="btn btn-secondary" onclick="Return()"
            <i class="bi bi-arrow-90deg-left"></i>
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-90deg-left" viewBox="0 0 16 16">
            <path fill-rule="evenodd" d="M1.146 4.854a.5.5 0 0 1 0-.708l4-4a.5.5 0 1 1 .708.708L2.707 4H12.5A2.5 2.5 0 0 1 15 6.5v8a.5.5 0 0 1-1 0v-8A1.5 1.5 0 0 0 12.5 5H2.707l3.147 3.146a.5.5 0 1 1-.708.708l-4-4z"/>
            </svg></button>

            <button type="button" class="btn btn-danger" onclick="DeletePerson('${x.id}')"
            <i class="bi bi-trash3"></i>
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
            <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
            </svg></button></td>
            </tr>`));
            $("#people").show();
            $("#cities").hide();
        };
    }).fail(function () {
        alert("ERRORE!");
    })
}

//restituisce tutte le persone
//bottone con cestino elimina la persona
function GetPeople() {
    $.ajax({
        url: "https://localhost:7137/Person",
        method: "GET"
    }).done(function (result) {
        if (result)
            $("#peopleTable").html(result.map(item => `<tr>
            <td>${item.firstName} </td>
            <td>${item.lastName}</td>
            <td>${item.age}</td>
            <td>${item.address}</td>

            <td><button type="button" class="btn btn-danger" onclick="DeletePersonV2('${item.id}')"
            <i class="bi bi-trash3"></i>
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
            <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
            </svg></button></td>
            </tr>`));
        $("#people").show();
        $("#cities").hide();
    }).fail(function () {
        alert("ERRORE!");
    })
}

//funziona
//elimina una città e ricarica la tabella
function DeleteCity(id) {
    $.ajax({
        url: "https://localhost:7137/City/" + id,
        method: "DELETE"
    }).done(function (result) {
        if (result) {
            alert("Delition complete");
            GetCities();
        };
    }).fail(function () {
        alert("ERRORE!");
    })
}

//funziona
//elimina una persona e ricarica la tabella
function DeletePerson(id) {
    $.ajax({
        url: "https://localhost:7137/Person/" + id,
        method: "DELETE"
    }).done(function (result) {
        if (result) {
            GetCityPeople(result.id);
        };
    }).fail(function () {
        alert("ERRORE!");
    })
}

//funziona
//elimina una persona e ricarica la tabella (PER LA LISTA DI SOLO CITTADINI)
function DeletePersonV2(id) {
    $.ajax({
        url: "https://localhost:7137/Person/" + id,
        method: "DELETE"
    }).done(function (result) {
        if (result) {
            GetPeople();
        };
    }).fail(function () {
        alert("ERRORE!");
    })
}

//Riporta alla lista di città
function Return() {
    GetCities();
}

//Fa correttamente la post, dobbiamo metterci la validation ed è a posto
//bisogna aggiornare con il nuovo form
function DioCaroSeNonFunzioni() {
    var person = {
        id: "00000000-0000-0000-0000-000000000000",
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        age: $("#age").val(),
        address: $("#address").val(),
        cityId: "" //bisogna settarlo dopo aver creato il menu a tendina
    };

    $.ajax({
        method: "POST",
        url: "https://localhost:7137/Person",
        data: JSON.stringify(person),
        contentType: "application/json"
    }).done(function (result) {
        GetPeople();
    }).fail(function () {
        alert("Fallito");
    }).always(function () {
        alert("Chiamato");
    });
}

//Metodo per creare una persona dalla lista di città, bisogna aggiornare con il nuovo form
function CreatePersonFromCity(id) {
    var person = {
        id: "00000000-0000-0000-0000-000000000000",
        firstName: $("#firstName").val(),
        lastName: $("#lastName").val(),
        age: $("#age").val(),
        address: $("#address").val(),
        cityId: `${id}`
    };

    $.ajax({
        method: "POST",
        url: "https://localhost:7137/Person",
        data: JSON.stringify(person),
        contentType: "application/json"
    }).done(function (result) {
        Return();
    }).fail(function () {
        alert("Fallito");
    }).always(function () {
        alert("Chiamato");
    });
}

//metodo per fare apparire il pop up con il form
function PeoplePopUp() {

}

//metodo per fare apparire il pop up con il form
function CityPopUp() {

}

//per ora è inutile
function ClearForms() {
    $("form").removeClass('was-validated');
    $(".form-control").val("");
}


