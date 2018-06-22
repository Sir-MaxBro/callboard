function createOption(name, value, text) {
    let option = $('<option></option>');
    option.attr('name', name);
    option.attr('value', value);
    option.text(text);
    return option;
}

function clearContainer(containerId) {
    $("#" + containerId).empty();
}

function backPage() {
    window.history.back();
}

function refreshPage() {
    location.reload();
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

function isTextValueExist(text, textInputContainerId) {

    let isTextValueExist = false;

    $(`#${textInputContainerId}`).find('input:text').each(function () {

        if (text === $(this).val()) {
            isTextValueExist = true;
            return false;
        }

    });

    return isTextValueExist;
}