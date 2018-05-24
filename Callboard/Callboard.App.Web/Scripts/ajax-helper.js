function renderActionAsync(obj, url, updateTargetId) {
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(obj),
        dataType: "html",
        success: function (data) {
            $('#' + updateTargetId).html(data);
        },
        error: function () {
            $('#' + updateTargetId).html("Not found");
        }
    });
}

function getDataAsync(obj, url, successFunc, errorFunc) {
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(obj),
        dataType: "json",
        success: successFunc,
        error: errorFunc
    });
}