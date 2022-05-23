document.getElementById("loginBtn").addEventListener("click", function(e){
    e.preventDefault();
    window.location.href = "/home/login";
});

function post() {
    var newPost = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username : document.getElementById("Username").value,
            password : document.getElementById("password").value,
            firstName : document.getElementById("firstName").value,
            lastName : document.getElementById("lastName").value
        })
    }
    fetch("/createAccount", newPost).then((response) => response.json()).then(function(data){
            window.location.href = "/";
    })
}
document.getElementById("registration").addEventListener("keyup", function () {
    if (document.getElementById("username").value.match(/([ ])/g)) {
        document.getElementById("usernameconfirm").innerText = "";
        document.getElementById("usernameWarning").innerText = "Invalid Username";
    } else {
        if (document.getElementById("username").value !== "") {
            fetch(`/home/usernameCheck?username=${document.getElementById("username").value}`).then((response) => response.json()).then(function (data) {
                if (data === 1) {
                    document.getElementById("usernameconfirm").innerText = "";
                    document.getElementById("usernameWarning").innerText = "Username already exists!";
                } else {
                    document.getElementById("usernameWarning").innerText = "";
                    document.getElementById("usernameconfirm").innerText = "Username Available";
                }
            });
        }
    }
});