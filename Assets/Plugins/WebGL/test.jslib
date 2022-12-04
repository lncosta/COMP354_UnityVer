mergeInto(LibraryManager.library, {
    
    setCookie: function (cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays*24*60*60*1000));
        var expires = "expires="+ d.toUTCString();
        document.cookie = UTF8ToString(cname) + "=" + UTF8ToString(cvalue) + ";" + expires + ";path=/";
        console.log('set cookie='+document.cookie);
    },

    getCookie: function (cname) {
        var ret="";
        var name = UTF8ToString(cname) + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        console.log('get cookie='+decodedCookie);
        if(decodedCookie.indexOf(name) !== -1){
            decodedCookie = decodedCookie.replace(name, '');
            ret = decodedCookie;
        }
        console.log('found cookie='+ret);
        var bufferSize = lengthBytesUTF8(ret) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(ret, buffer, bufferSize);
        return buffer;
    },

    deleteCookie: function (cname) {
        var expires = "expires=Thu, 01 Jan 1970 00:00:01 GMT";
        document.cookie = UTF8ToString(cname) + "=" + ";" + expires + ";path=/";
        console.log('delete cookie='+document.cookie);
    },
});