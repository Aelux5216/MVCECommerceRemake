// Write your JavaScript code.
function selectionChanged(eProd) {

    var e = document.getElementById(eProd); //Get Id and newly selected quantity.
    var eQuant = e.options[e.selectedIndex].value;

    var xhttp = new XMLHttpRequest(); //Create result function.
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === XMLHttpRequest.DONE) {
            if (xhttp.status === 200) {

                $("#navbar").load("/Baskets/Index #navbar"); //Update basket counter, appending selector means script blocks will not execute.
            }

            else {
                alert('Updating quantity failed.');
            }
        }
    };

    xhttp.open('POST', '/Baskets/Edit', true); //Setup and send ajax request.
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(JSON.stringify({ "ProductId": e.id, "ProductQuantity": eQuant }));
}