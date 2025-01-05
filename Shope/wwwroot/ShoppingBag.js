const cartLIst = addEventListener("load", async () => {
    drawcart()

})
const drawcart = async () => {
    let productsId = JSON.parse(sessionStorage.getItem("basket"))
    console.log(productsId)
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
    let url = `./Images/${product.image}`

    console.log(url)
    console.log(product.image)
    console.log(product)

    let tmp = document.getElementById("temp-row");
    let cloneProduct = tmp.content.cloneNode(true)

    cloneProduct.querySelector(".image").style.backgroundImage = `url(${url})`
    cloneProduct.querySelector(".descriptionColumn").innerText = product.description
    cloneProduct.querySelector(".availabilityColumn").innerText = "true"

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
    let OrderSum = 100
    var OrderDate = new Date()

    return ({
        OrderDate, UserId, OrderSum, orderItems
    })
}

const placeOrder = async () => {
    let bodyDetails = Details()
  
    const creatOrder = await fetch('api/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bodyDetails)

    });
    productInBasket = await creatOrder.json();
    if (creatOrder.ok)
        alert("ההזמנה נוספה בהצלחה!")
    else
        alert("error")


}
