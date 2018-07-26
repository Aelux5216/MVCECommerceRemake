// Write your JavaScript code.
function selectionChanged(eProd) {

    var e = document.getElementById(eProd);
    var eQuant = e.options[e.selectedIndex].value;

    $.post('@Url.Action("Edit","Baskets")', { ProdID: eProd.value, Quantity: eQuant});
}