function lagreKunde() {
    const kunde = {
        symbol: $("#symbol").val(),
        open: $("#open").val(),
        high: $("#high").val(),
        low: $("#low").val(),
        price: $("#price").val(),
        volume: $("#volume").val()
    }
    const url = "Kunde/Lagre";
    $.post(url, kunde, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
};