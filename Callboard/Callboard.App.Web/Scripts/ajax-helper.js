function callActionAsync(obj, url, updateTargetId) {
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        data: obj,
        dataType: "html",
        success: function (data) {
            $('#' + updateTargetId).html(data);
        },
        error: function () {
            $('#' + updateTargetId).html("Sorry:( Nothing found");
        }
    });
}

function getDataAsync(obj, url, successFunc, errorFunc) {
    execActionAsync(obj, url, 'GET', successFunc, errorFunc);
}

function postDataAsync(obj, url, successFunc, errorFunc) {
    execActionAsync(obj, url, 'POST', successFunc, errorFunc);
}

let execActionAsync = function (obj, url, type, successFunc, errorFunc) {
    $.ajax({
        url: url,
        type: type,
        contentType: 'application/json',
        data: obj,
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });
}