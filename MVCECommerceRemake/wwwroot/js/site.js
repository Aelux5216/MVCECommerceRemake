// Write your JavaScript code.
function selectionChanged(eProd) {

    var e = document.getElementById(eProd); //Get Id and newly selected quantity.
    var eQuant = e.options[e.selectedIndex].value;

    var xhttp = new XMLHttpRequest(); //Create result function.
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState === XMLHttpRequest.DONE) {
            if (xhttp.status === 200) {
                //Start next request.
                xhttp.open('POST', '/Baskets/Edit', true); //Setup and send ajax request to update database.
                xhttp.setRequestHeader("Content-type", "application/json");
                xhttp.send(JSON.stringify({ "ProductId": e.id, "ProductQuantity": eQuant }));

                if (xhttp.readyState === XMLHttpRequest.DONE) {
                    if (xhttp.status === 200) {

                        $("#navbar").load("/Baskets/Index #navbar"); //Update basket counter, appending selector means script blocks will not execute.
                        $("#A" + e.id).remove();
                    }

                    else {
                        alert('Connection failed please try again.');
                    }
                }
            }
        }
        else {
            $("#A" + e.id).html('<div class="alert alert-danger fade in"></a><strong>Not enough stock</strong><br />There is not enough stock to add this many of this item.</div>');
        }
    };

    xhttp.open('POST', '/Baskets/CheckStock', true); //Setup and send ajax request for checking avaliable stock.
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(JSON.stringify({ "ProductId": e.id, "ProductQuantity": eQuant }));

    
}