
TestApi() {
    $.ajax({
        url: "Api/Course",
        method: "GET"
    }).done(function (result) {
        if (result)
            $("#contenuto").html(result.map(item => `<tr>
                <td>${item.id} </td>
                <td>${item.title}</td>
                <td>${item.duration}</td>
                <td>${new Date(item.startDate).toLocaleDateString()}</td>
                <td>${new Date(item.endDate).toLocaleDateString()}</td>
              </tr>`));
    }).fail(function () {
        alert("ERRORE!");
    }).always(function () {
        $("#esito").html("Tasto schiacciato");
    })
