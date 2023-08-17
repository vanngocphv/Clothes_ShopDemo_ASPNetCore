// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var lengthOrder = JSON.parse(localStorage.getItem('product'));
if (lengthOrder != null) setCartBadge(lengthOrder.length);

function decreaseQuantityOrder() {
    var price = document.getElementById("priceOneProduct").value;
    var number = document.getElementById("quantityOrder").value;
    number--;
    price = number < 1 ? price : price * number;
    document.getElementById("quantityOrder").value = number < 1 ? 1 : number;
    document.getElementById("totalProductPrice").innerHTML = price + ".00";
}
function increaseQuantityOrder() {
    var price = document.getElementById("priceOneProduct").value;
    var number = document.getElementById("quantityOrder").value;
    number++;
    price = number > 50 ? price * 50 : price * number;
    document.getElementById("quantityOrder").value = number > 50 ? 50 : number;
    document.getElementById("totalProductPrice").innerHTML = price + ".00";
}
function addToCart(id, name, image, price, isDetailPage = false) {
    var localProducts = JSON.parse(localStorage.getItem('product'));
    var quantityProduct = isDetailPage == true ? parseInt(document.getElementById("quantityOrder").value) : 1;
    var product = localProducts == null ? null : localProducts.find(x => x.key == id);
    localProducts = localProducts == null ? [] : localProducts.filter(x => x.key != id);

    if (product == null) {
        var order = {
            "key": id,
            "value": {
                "name": name,
                "image": image,
                "quantity": quantityProduct,
                "price": price,
                "totalPrice": price * quantityProduct,
            }
        };
        product = order;
    }
    else {
        product.value.quantity = parseInt(product.value.quantity) + quantityProduct;
        product.value.totalPrice = parseInt(product.value.totalPrice) + quantityProduct * price;
    }
    localProducts.push(product);
    //console.log(localProducts);
    var length = localProducts.length;
    if (length > 0) setCartBadge(length);
    localStorage.setItem('product', JSON.stringify(localProducts));
}

function setCartBadge(length) {
    document.getElementById('cart-badge').innerHTML = length;
}

function changeQuantityOrder(id, numberFunction) {
    var localStorageData = JSON.parse(localStorage.getItem('product'));
    var product = localStorageData.find(x => x.key == id);
    var currentTotalAmount = parseInt(document.getElementById('total-amount').value) - parseInt(product.value.totalPrice);
    localStorageData = localStorageData.filter(x => x.key != id);

    if (numberFunction == 1) {
        //down quantity
        product.value.quantity--;
        product.value.quantity = product.value.quantity < 1 ? 1 : product.value.quantity;
    }
    else if (numberFunction == 2) {
        //up quantity
        product.value.quantity++;
        product.value.quantity = product.value.quantity > 50 ? 50 : product.value.quantity;

    }


    product.value.totalPrice = parseInt(product.value.quantity) * parseInt(product.value.price);
    console.log(product.value.quantity + " * " + product.value.price + " = " + product.value.totalPrice);
    currentTotalAmount = parseInt(currentTotalAmount) + parseInt(product.value.totalPrice);


    document.getElementById("total-amount-products").innerHTML = "Total Amount: $" + currentTotalAmount + ".00";
    document.getElementById("total-amount").value = currentTotalAmount;
    document.getElementById("quantityOrder" + id).value = product.value.quantity;
    document.getElementById("totalPrice" + id).innerHTML = "$" + product.value.totalPrice + ".00";

    localStorageData.push(product);
    localStorage.setItem('product', JSON.stringify(localStorageData));
}

