function createOption(name, value, text) {
    let option = $('<option></option>');
    option.attr('name', name);
    option.attr('value', value);
    option.text(text);
    return option;
}

function renderLink(text, click) {
    let link = $('<a></a>');
    link.attr('href', '#');
    link.text(text);
    link.on('click', function () {
        click.call();
    });
    return link;
}

function convertByteToBase64(byteArray) {
    var base64String = btoa(String.fromCharCode.apply(null, new Uint8Array(byteArray)));
    return base64String;
}

function convertBase64ToByte(base64) {
    var binaryString = window.atob(base64);
    var length = binaryString.length;
    var bytes = new Uint8Array(length);
    for (var i = 0; i < length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    let byteArray = [].slice.call(bytes);
    return byteArray;
}