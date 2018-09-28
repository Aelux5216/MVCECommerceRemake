// Write your JavaScript code.
function selectionChanged(eProd) {

    var e = document.getElementById(eProd); //Get Id and newly selected quantity.
    var eQuant = e.options[e.selectedIndex].value;

    var xhttp = new XMLHttpRequest(); //Create result function.
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === XMLHttpRequest.DONE) {
            if (xhttp.status !== 200) {
                alert('There was an error changing the quantity, please try again.');
            }
        }
    };

    xhttp.open('POST', '/Baskets/Edit', true); //Setup and send ajax request.
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(JSON.stringify({ "ProductId": e.id, "ProductQuantity": eQuant }));
}