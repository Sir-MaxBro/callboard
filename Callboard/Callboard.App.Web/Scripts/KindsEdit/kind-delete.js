function deleteKind(kindId, kindContainerId) {
    if (kindId) {
        $.post('/Kind/DeleteKind', { kindId: kindId });
    }
    $("#" + kindContainerId).remove();
}