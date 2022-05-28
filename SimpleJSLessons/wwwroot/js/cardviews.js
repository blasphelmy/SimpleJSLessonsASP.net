(() => {
    var elements = document.getElementsByClassName("democard");
    var elementsSwitches = new Map();
    function cardClick(element) {
        switch (elementsSwitches.get(element.id)){
            case 0:
                (() => {
                    refreshelements();
                    element.classList.remove("scale");
                    element.classList.add("clicked");
                    setTimeout(() => {
                        let contentElement = document.getElementById(element.id + "content");
                        let btnGroup = document.getElementById(element.id + "btnGroups");
                        contentElement.classList.add("hide");
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
                        contentElement.classList.remove("hide");
                        btnGroup.classList.add("hide");
                    }, 50);
                })()
                elementsSwitches.set(element.id, 0);
                break;
        }
    }
    function refreshelements() {
        for (let element of elements) {
            let contentElement = document.getElementById(element.id + "content");
            let btnGroup = document.getElementById(element.id + "btnGroups");
            btnGroup.style.setProperty("height", `${contentElement.offsetHeight}px`)
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
    for (let element of elements) {
        elementsSwitches.set(element.id, 0);
        element.addEventListener("click", () => {
            cardClick(element);
        });
    }
})()