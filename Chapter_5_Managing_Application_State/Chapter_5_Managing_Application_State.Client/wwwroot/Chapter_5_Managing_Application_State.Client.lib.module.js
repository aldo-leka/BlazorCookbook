window.browserStorage = {
    set: function (type, key, value) {
        if (type === 'sessionStorage') {
            sessionStorage.setItem(key, value);
        }
        if (type === 'localStorage') {
            localStorage.setItem(key, value);
        }
    }
};