const getAllDetailsFromFormForRegister = () => {
    const UserName = document.getElementById("username").value
    const Password = document.querySelector("#password").value
    const FirstName = document.querySelector("#firstname").value
    const LastName = document.querySelector("#lastname").value
    if (!UserName || !Password || !FirstName || !LastName) {

        alert("all filed is requred")
    }
    else {
        return ({
            UserName, Password, FirstName, LastName
        })
    }
}
const register = async() => {
    newUser = getAllDetailsFromFormForRegister()
        const responsePost = await fetch('api/user', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });
    if (responsePost.ok) { 
        const dataPost = await responsePost.json();
        console.log('POST Data:', dataPost)
        alert(`hello ${dataPost.firstName}`)
    }
    else
    alert("bed req")
}
const checkPassword = async () => {
    const password = document.querySelector("#password")
    const progress = document.querySelector("#progress")

    const responsePost = await fetch(`api/user/password/?password=${password.value}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        query: {
            password:password.value
        }
    });
    const dataPost = await responsePost.json();
    console.log(dataPost);
    progress.value = dataPost;

}
const getDetailsFromFormForLogIn = () => {
    const UserName = document.getElementById("username2").value
    const Password = document.querySelector("#password2").value

    if (!UserName || !Password ) {

        alert("all filed is requred")
    }
    else {
        return ({
            UserName, Password
        })
    }
}

const login = async () => {
    newUser = getDetailsFromFormForLogIn()
    try
    {
        const responsePost = await fetch(`api/user/login/?UserName=${newUser.UserName}&Password=${newUser.Password}`, {
            method: 'POST',

            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                UserName: newUser.UserName,
                Password: newUser.Password
            }
        });
        if (!responsePost.ok)
            throw new Error(` HTTP error status: ${responsePost.status}`)

        if (!responsePost.ok)
            throw new Error(`http error ${responsePost.status}`)
        if (responsePost.status == 204)
            alert("user not found")
        else { 
            const dataPost = await responsePost.json();
            console.log(dataPost)
            alert(dataPost.firstName)
            sessionStorage.setItem("userId", dataPost.userId)

            window.location.href = "ShoppingBag.html"
        }
    }
    catch (Error) {
        console.log(Error)
        
    }
}
const update = async () => {
    newUser = getAllDetailsFromFormForRegister()

    const responsePut = await fetch(`api/user/${sessionStorage.getItem('userId')}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });
    if (responsePut.ok) { 

    alert("update sucsses")
    }
    else
        alert("update not sucsses")
}




   
   

