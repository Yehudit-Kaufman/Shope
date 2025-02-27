const cartLIst = addEventListener("load", async () => {
    drawcart()

})
let price = 0;
const drawcart = async () => {
    document.querySelector("tbody").innerHTML = ''
    price=0
    let productsId = JSON.parse(sessionStorage.getItem("basket"))
    document.getElementById("totalAmount").textContent = price + ' ₪'
    document.getElementById("itemCount").innerText = productsId.length;
    for (let i = 0; i < productsId.length; i++) {
        await showOneProductInBasket(productsId[i])
    }    
}
const showOneProductInBasket = async (product) => {
    console.log(product)
    const productInBasket1 = await fetch(`api/product/${product}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        query: {
            id: product
        }
    });

    productInBasket = await productInBasket1.json();
    
    console.log(productInBasket)
    showOneProduct(productInBasket);
}
const showOneProduct = (product) => {
    price += product.price;
    let url = `./Images/${product.image}`

    console.log(url)
    console.log(product.image)
    console.log(product)

    let tmp = document.getElementById("temp-row");
    let cloneProduct = tmp.content.cloneNode(true)

    cloneProduct.querySelector(".image").style.backgroundImage = `url(${url})`
    //cloneProduct.querySelector(".descriptionColumn").innerText = product.description
    cloneProduct.querySelector(".itemName").innerText = product.productName

    //cloneProduct.querySelector(".availabilityColumn").innerText = "true"
    cloneProduct.querySelector(".availabilityColumn").innerText = "true"

    cloneProduct.querySelector(".price").innerText = product.price + '₪'
    cloneProduct.querySelector(".expandoHeight").addEventListener('click', () => { deleteproduct(product) })
    document.getElementById("totalAmount").textContent = price + ' ₪'

    document.querySelector("tbody").appendChild(cloneProduct)

}

const Details = () => {
    let UserId = JSON.parse(sessionStorage.getItem("userId"))
    let orderItems1 = JSON.parse(sessionStorage.getItem("basket"))
    let orderItems = []
    orderItems1.map(t => {
        let obj = { productId: t, quantity:1}
        orderItems.push(obj)
    })
    let OrderSum = price
    var OrderDate = new Date()

    return ({
        OrderDate, UserId, OrderSum, orderItems
    })
}

const placeOrder = async () => {
    if (price != 0) {
        if (sessionStorage.getItem("userId")) {
            let bodyDetails = Details()

            const creatOrder = await fetch('api/Order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(bodyDetails)

            });
            productInBasket = await creatOrder.json();
            console.log(productInBasket)
            if (creatOrder.ok) {
                alert(`ההזמנה מס ${productInBasket.orderId} נוספה בהצלחה!`)
                sessionStorage.setItem("basket", JSON.stringify([]))
                window.location.href = "Products.html"
            }
            else
                alert("error")
        }
        else {
            alert("אנא הרשם")
            window.location.href = "user.html"
        }
    }
    else { 
        alert("הסל שלך ריק. אנא הוסף מוצרים")
        window.location.href = "Products.html"
    }
}
const deleteproduct = async (product) => {
    const cartString = JSON.parse(sessionStorage.getItem("basket")) || [];
    const current = cartString.indexOf(product.id)
    cartString.splice(current, 1)
    sessionStorage.setItem("basket", JSON.stringify(cartString));
    drawcart()
}


