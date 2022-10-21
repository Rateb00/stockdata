$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet

    const id = window.location.search.substring(1);
    const url = "Kunde/HentEn?" + id;
    $.get(url, function (kunde) {
        $("#id").val(kunde.id); // må ha med id inn skjemaet, hidden i html
        $("#symbol").val(kunde.symbol);
        $("#open").val(kunde.open);
        $("#high").val(kunde.high);
        $("#low").val(kunde.low);
        $("#price").val(kunde.price);
        $("#volume").val(kunde.volume);
    }); 
});

function endreKunde() {
    const kunde = {
        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        symbol: $("#symbol").val(),
        open: $("#open").val(),
        high: $("#high").val(),
        low: $("#low").val(),
        price: $("#price").val(),
        volume: $("#volume").val()
    };
    $.post("Kunde/Endre", kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}