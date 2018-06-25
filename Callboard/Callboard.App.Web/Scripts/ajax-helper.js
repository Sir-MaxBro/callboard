function callActionAsync(obj, url, updateTargetId, complete) {
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
        },
        complete: complete
    });
}

function getDataAsync(obj, url, successFunc, errorFunc) {
    execActionAsync(obj, url, 'GET', successFunc, errorFunc);
}

function postDataAsync(obj, url, successFunc, errorFunc) {
    execActionAsync(obj, url, 'POST', successFunc, errorFunc);
}

function execActionAsync(obj, url, type, successFunc, errorFunc) {
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

function callAction(obj, url, updateTargetId, complete) {
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        data: obj,
        dataType: "html",
        async: false,
        success: function (data) {
            $('#' + updateTargetId).html(data);
        },
        error: function () {
            $('#' + updateTargetId).html("Sorry:( Nothing found");
        },
        complete: complete
    });
}