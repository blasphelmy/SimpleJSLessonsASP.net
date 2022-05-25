var targetElement;
window.onload = function () {
    extractURLParems();
    targetElement = document.getElementById("iFrameMain");
    currentLabID = urlParameters.get("key");
    var offSet = document.getElementById("navBar").offsetHeight;
    var offSet = document.getElementById("navBar").offsetHeight + document.getElementById("footer").offsetHeight;
    fillVerticalHeight(targetElement, offSet);
    //targetElement.src = `https://blasphelmy.github.io/SimpleJSLessons/Interactive-JS-Lessons/?key=${currentLabID}&server=asp`;
    targetElement.src = `http://127.0.0.1:5502/?key=${currentLabID}&server=asp`;
}
window.onresize = function () {
    var targetElement = document.getElementById("iFrameMain");
    var offSet = document.getElementById("navBar").offsetHeight + document.getElementById("footer").offsetHeight;
    console.log(offSet);
    fillVerticalHeight(targetElement, offSet);
}
window.onmessage = function (e) {
    console.log("top level window");
    console.log(e.data);
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