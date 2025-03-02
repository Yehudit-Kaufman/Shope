const cartLIst = addEventListener("load", async () => {
    if (sessionStorage.getItem("userId")) {
        const responsePut = await fetch(`api/user/${sessionStorage.getItem('userId')}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
          
        });

        const dataPost = await responsePut.json();
        document.getElementById("username").value = dataPost.userName
        document.getElementById("firstname").value = dataPost.firstName
        document.getElementById("lastname").value = dataPost.lastName
}

})


const getAllDetailsFromFormForRegister = () => {
    const UserName = document.getElementById("username").value;
    const Password = document.querySelector("#password").value;
    const FirstName = document.querySelector("#firstname").value;
    const LastName = document.querySelector("#lastname").value;

    // Check if all fields are filled
    if (!UserName || !Password || !FirstName || !LastName) {
        alert("All fields are required");
        return;
    }

    // Validate UserName (Email Address)
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(UserName)) {
        alert("Invalid email address");
        return;
    }

    // Validate FirstName
    if (FirstName.length < 2 || FirstName.length > 20) {
        alert("FirstName can be between 2 to 20 letters");
        return;
    }

    // Validate LastName
    if (LastName.length < 2 || LastName.length > 20) {
        alert("LastName can be between 2 to 20 letters");
        return;
    }

    // No specific validation for Password in the DTO, but you can add your own if needed
    if (Password.length < 6) {
        alert("Password must be at least 6 characters long");
        return;
    }

    return {
        UserName,
        Password,
        FirstName,
        LastName
    };
}
const register = async () => {
    const newUser = getAllDetailsFromFormForRegister();
    const responsePost = await fetch('api/user', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });

    if (responsePost.ok) {
        const dataPost = await responsePost.json();
        console.log('POST Data:', dataPost);
        alert(`hello ${dataPost.firstName}`);
    }

    //else {
        

            //const errorResponse = await responsePost.json();
            //for (const key in errorResponse.errors) {
            //    if (errorResponse.errors.hasOwnProperty(key)) {
            //        const errors = errorResponse.errors[key];
            //        errors.forEach(error => {
            //            alert(error); // הצג כל שגיאה
            //        });
            //    }
            //}
        
    //}
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
const updateUser = async () => {
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




   
   

