function addKind(updateTargetId) {
    $.ajax({
        url: '/Kind/CreateKind',
        dataType: 'html',
        success: function (data) {
            $("#" + updateTargetId).append(data);
        }
    });
}

function saveKind(kindId, typeInputId) {
    let type = $("#" + typeInputId).val();
    if (type) {
        let kind = {
            KindId: kindId,
            Type: type
        };
        $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) }, function () { refreshPage(); });
    }
}

function deleteKind(kindId, kindContainerId) {
    if (kindId) {
        $.post('/Kind/DeleteKind', { kindId: kindId });
    }
    $("#" + kindContainerId).remove();
}