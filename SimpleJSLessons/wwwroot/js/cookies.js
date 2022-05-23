function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}
function setCookie(key, value) {
    document.cookie = key + "=" + (value || "") + ";" + "expires=Fri, 31 Dec 9999 23:59:59 GMT" + "path=/";
}