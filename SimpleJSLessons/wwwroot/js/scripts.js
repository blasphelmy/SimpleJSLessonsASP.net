var urlParameters = new Map();
window.onload = function () {
    extractURLParems();
}
function search() {
    var searchTerm = document.getElementById("searchField").value;
    console.log(searchTerm);
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