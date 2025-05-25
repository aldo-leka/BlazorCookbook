window.browserStorage = {
    get: function (type, key) {
        if (type === 'sessionStorage') {
            return sessionStorage.getItem(key);
        }
        if (type === 'localStorage') {
            return localStorage.getItem(key);
        }
        return '';
    },
    set: function (type, key, value) {
        if (type === 'sessionStorage') {
            sessionStorage.setItem(key, value);
        }
        if (type === 'localStorage') {
            localStorage.setItem(key, value);
        }
    }
};