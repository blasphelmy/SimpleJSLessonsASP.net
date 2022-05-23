document.getElementById("loginBtn").addEventListener("click", function (e) {
    e.preventDefault();
    post();
});
function post() {
    var newPost = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username : document.getElementById("username").value,
            password : document.getElementById("password").value,
        })
    }
    fetch("/home/login", newPost).then((response) => response.json()).then(function (data) {
        console.log(data);
        if (data === 0) {
            document.getElementById("loginwarning").innerHTML = "Incorrect username or password";
        } else {
            window.location.href = "/";
        }
        //if(data.errorType){
        //    if(data.errorType === 3){
        //        document.getElementById("usernameWarning").innerHTML = data.errorMessage;
        //    }
        //}else if(data.token){
        //    console.log(data.token);
        //    setCookie("sessionid", data.token);
        //    window.location.href = "/";
        //}
    });
}