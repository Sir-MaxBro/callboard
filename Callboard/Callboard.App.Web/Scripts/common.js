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
    let base64 = btoa(
        new Uint8Array(byteArray)
            .reduce((data, byte) => data + String.fromCharCode(byte), '')
    );
    return base64;
}

function convertBase64ToByte(base64) {
    let buffer = Uint8Array.from(atob(base64), c => c.charCodeAt(0));
    return buffer;

    //let uint8Array = new TextEncoder("utf-8").encode(base64);
    //return uint8Array;
}

function strToBuffer(string) {
    let arrayBuffer = new ArrayBuffer(string.length * 1);
    let newUint = new Uint8Array(arrayBuffer);
    newUint.forEach((_, i) => {
        newUint[i] = string.charCodeAt(i);
    });
    return newUint;
}