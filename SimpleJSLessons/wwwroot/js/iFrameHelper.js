var targetElement;
var urlParameters = new Map();
window.onload = function () {
    extractURLParems();
    targetElement = document.getElementById("iFrameMain");
    currentLabID = urlParameters.get("key");
    var offSet = document.getElementById("navBar").offsetHeight;
    //var offSet = document.getElementById("navBar").offsetHeight + document.getElementById("footer").offsetHeight;
    fillVerticalHeight(targetElement, offSet);
    targetElement.src = `https://blasphelmy.github.io/SimpleJSLessons/Interactive-JS-Lessons/?key=${currentLabID}&server=asp`;
    //targetElement.src = `http://127.0.0.1:5502/?key=${currentLabID}&server=asp`;
}
window.onresize = function () {
    var targetElement = document.getElementById("iFrameMain");
    var offSet = document.getElementById("navBar").offsetHeight;
    console.log(offSet);
    fillVerticalHeight(targetElement, offSet);
}
window.onmessage = function (e) {
    var newPost = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            hashcode: e.data.URL + "",
            type: e.data.type,
            title: e.data.title,
            data: e.data.data,
            imageData: e.data.imageData,
        })
    }
    fetch("/home/postData", newPost).then((response) => response.json()).then(function (data) {
        console.log(data);
    });
};
function fillVerticalHeight(targetElement, offsetHeight) {
    if (targetElement.length > 0) {
        for (var i = 0; i < targetElement.length; i++) {
            targetElement[i].style.height = (window.innerHeight - offsetHeight) + "px";
        }
    } else {
        targetElement.style.height = (window.innerHeight - offsetHeight) + "px";
    }
}
function extractURLParems() {
    try {
        let parameters = window.location.href.split("?")[1].split("&");
        for (parameter of parameters) {
            let keyValue = parameter.split("=");
            urlParameters.set(keyValue[0], keyValue[1]);
        }
    } catch (error) {
        console.log(error);
    }
}