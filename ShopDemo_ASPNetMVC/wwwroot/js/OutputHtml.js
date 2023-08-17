const outputElement = document.getElementById('output-html');
var localData = JSON.parse(localStorage.getItem('product'));
var totalAmount = 0;
if (localData == null) {
    outputElement.innerHTML = "No item in your Cart";
}
else {
    //output all item in local storage
    outputElement.innerHTML = "";
    localData.forEach(loopThroughArray);
}

document.getElementById("total-amount-products").innerHTML = "Total Amount: $" + totalAmount + ".00";
document.getElementById("total-amount").value = totalAmount;

function loopThroughArray(item, index, array) {
    totalAmount += parseInt(item.value.totalPrice);
    let outputHtml = "";
    outputHtml += '<div class="row cart-item">';
    outputHtml += '<div class="col-md-3">';
    outputHtml += '<img class="cart-image" src="'+ item.value.image +'" />';
    outputHtml += '</div>';
    outputHtml += '<div class="col-md-3"><span>' + item.value.name + '</span ></div>';
    outputHtml += '<div class="col-md-3"><div class="quantity buttons_added">';
    outputHtml += '<input type="button" value="-" class="minus" onclick="changeQuantityOrder(' + item.key + ', 1)"><input type="number" id="quantityOrder' + item.key + '" step="1" min="1" max="" name="quantity" value="' +
                    item.value.quantity + '" title="Qty" class="input-text qty text" size="4" pattern="" inputmode=""><input type="button" value="+" class="plus" onclick="changeQuantityOrder(' + item.key + ', 2)">';
    outputHtml += '</div></div><div class="col-md-3"><p id="totalPrice'+ item.key +'">$' + item.value.totalPrice + '.00</p></div></div>';
    outputElement.innerHTML += outputHtml;
}