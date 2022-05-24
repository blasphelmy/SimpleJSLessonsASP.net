var targetElement;
var labID = function () {
    try {
        var number = Number((window.location.href).split('?')[1].split('=')[1]);
    } catch (error) {
        return 268945738906855;
    }
    return number;
};
window.onmessage = function (e) {
    console.log("top level window");
    console.log(e.data);
    var newPost = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            hashcode: e.data.URL+"",
            type: e.data.type,
            title: e.data.title,
            data: e.data.data
        })
    }
    fetch("/home/postData", newPost).then((response) => response.json()).then(function (data) {
        console.log(data);
    });
 };
var currentLabID = labID();
window.onload = function () {
    targetElement = document.getElementById("iFrameMain");
    console.log(targetElement);
    var offSet = document.getElementById("navBar").offsetHeight;
    var offSet = document.getElementById("navBar").offsetHeight + document.getElementById("footer").offsetHeight;
    fillVerticalHeight(targetElement, offSet);
    targetElement.src = `https://blasphelmy.github.io/SimpleJSLessons/Interactive-JS-Lessons/?key=${currentLabID}`;
    document.getElementById("searchButton").addEventListener("click", function () {
        var newLabID = document.getElementById("searchField").value;
        if (window.location.href.match("simplejsclasses")) {
            window.location.href = "?key=" + newLabID;
        } else {
            window.location.href = "?key=" + newLabID;
        }
    });
}
window.onresize = function () {
    var targetElement = document.getElementById("iFrameMain");
    var offSet = document.getElementById("navBar").offsetHeight + document.getElementById("footer").offsetHeight;
    console.log(offSet);
    fillVerticalHeight(targetElement, offSet);
}
function fillVerticalHeight(targetElement, offsetHeight) {
    if (targetElement.length > 0) {
        for (var i = 0; i < targetElement.length; i++) {
            targetElement[i].style.height = (window.innerHeight - offsetHeight) + "px";
        }
    } else {
        targetElement.style.height = (window.innerHeight - offsetHeight) + "px";
    }
}