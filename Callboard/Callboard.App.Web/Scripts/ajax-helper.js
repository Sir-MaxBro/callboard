function renderActionAsync(obj, url, updateTargetId) {
    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(obj),
        success: function (data) {
            $('#' + updateTargetId).html(data);
        }
    });
}