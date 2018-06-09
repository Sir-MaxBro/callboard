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
    $.ajax({
        url: url,
        type: 'GET',
        contentType: 'application/json',
        data: obj,
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });
}