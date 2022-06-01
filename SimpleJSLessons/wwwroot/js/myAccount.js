var imageData = "null";
var reader = new FileReader();

function encodeImageFileAsURL(element) {
    var file = element.files[0];
    reader.readAsDataURL(file);
}
window.onresize = function () {
    let elements = document.getElementsByClassName("democard");
    for (let element of elements) {
        let contentElement = document.getElementById(element.id + "content");
        let btnGroup = document.getElementById(element.id + "btnGroups");
        let height = contentElement.offsetHeight;
        btnGroup.style.setProperty("height", `${height}px`);
    }
}
window.onload = function () {
    var elements = document.getElementsByClassName("democard");
    var elementEditImgBtns = document.getElementsByClassName("editImageBtnGroup");
    var elementPrivacyBtns = document.getElementsByClassName("setPrivacyBtnGroup");
    var elementsSwitches = new Map();
    function cardClick(element) {
        switch (elementsSwitches.get(element.id)) {
            case 0:
                (() => {
                    refreshelements();
                    element.classList.remove("scale");
                    element.classList.add("clicked");
                    setTimeout(() => {
                        let contentElement = document.getElementById(element.id + "content");
                        let btnGroup = document.getElementById(element.id + "btnGroups");
                        btnGroup.classList.remove("hide");
                    }, 50);
                })();
                elementsSwitches.set(element.id, 1);
                break;
            case 1:
                (() => {
                    element.classList.add("scale");
                    element.classList.remove("clicked");
                    setTimeout(() => {
                        let contentElement = document.getElementById(element.id + "content");
                        let btnGroup = document.getElementById(element.id + "btnGroups");
                        btnGroup.classList.add("hide");
                    }, 50);
                })()
                elementsSwitches.set(element.id, 0);
                break;
        }
    }
    function refreshelements() {
        for (let element of elements) {
            if (elementsSwitches.get(element.id)) {
                element.classList.add("scale");
                element.classList.remove("clicked");
                setTimeout(() => {
                    let contentElement = document.getElementById(element.id + "content");
                    let btnGroup = document.getElementById(element.id + "btnGroups");
                    contentElement.classList.remove("hide");
                    btnGroup.classList.add("hide");
                }, 50);
                elementsSwitches.set(element.id, 0);
            }
        }
    }
    function editImgBtn(element) {
        let demoHash = element.id.split("_")[1];
        document.getElementById("uploadImgLink").click();
        reader.onloadend = function () {
            imageData = reader.result;
            let newPost = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    operation: 2,
                    hash: demoHash,
                    data: imageData
            })
            }
            fetch("/home/updateInformation", newPost).then((response) => response.json()).then(function (data) {
                window.location.href = "/home/myAccount"
            });
        }
    }
    function EditPrivacyBtn(element) {
        let demoHash = element.id.split("_")[1];
        let newPost = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                operation: 1,
                hash: demoHash,
                data: function () {
                    if (confirm("Make this demo available to publically search?")) {
                        return 1+"";
                    } else {
                        return 0+"";
                    }
                }()
            })
        }
        fetch("/home/updateInformation", newPost).then((response) => response.json()).then(function (data) {
            console.log(data);
        });
    }
    for (let element of elements) {
        elementsSwitches.set(element.id, 0);
        let contentElement = document.getElementById(element.id + "content");
        let btnGroup = document.getElementById(element.id + "btnGroups");
        let height = contentElement.offsetHeight;
        btnGroup.style.setProperty("height", `${height}px`);
        element.addEventListener("click", () => {
            cardClick(element);
        });
    }
    for (let element of elementEditImgBtns) {
        element.addEventListener("click", (e) => {
            e.stopPropagation();
            editImgBtn(element);
        });
    }
    for (let element of elementPrivacyBtns) {
        element.addEventListener("click", (e) => {
            e.stopPropagation();
            EditPrivacyBtn(element);
        });
    }
}