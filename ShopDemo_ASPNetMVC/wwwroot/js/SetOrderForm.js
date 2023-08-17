var localData = JSON.parse(localStorage.getItem('product'));
if (localData != null) {
    document.getElementById("order-products").value = JSON.stringify(localData);
}

var totalAmount = 0;
localData.forEach(loopEachData);
document.getElementById("total-amount").value = totalAmount;

function loopEachData(item){
    totalAmount += parseInt(item.value.totalPrice);
}