$(function(){
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("kunde/hentAlle", function (kunder) {
        formaterKunder(kunder);
    });
}

function formaterKunder(kunder) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Symbol</th><th>Open</th><th>High</th><th>Low</th><th>Price</th><th>Volume</th><th></th><th></th>" +
        "</tr>";
    for (let kunde of kunder) {
        ut += "<tr>" +
            "<td>" + kunde.symbol + "</td>" +
            "<td>" + kunde.open + "</td>" +
            "<td>" + kunde.high + "</td>" +
            "<td>" + kunde.low + "</td>" +
            "<td>" + kunde.price + "</td>" +
            "<td>" + kunde.volume + "</td>" +
            "<td> <a class='btn btn-primary' href='endre.html?id="+kunde.id+"'>Endre</a></td>"+
            "<td> <button class='btn btn-danger' onclick='slettKunde("+kunde.id+")'>Slett</button></td>"+
            "</tr>";
    }
    ut += "</table>";
    $("#kundene").html(ut);
}

function slettKunde(id) {
    const url = "Kunde/Slett?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }

    });
}