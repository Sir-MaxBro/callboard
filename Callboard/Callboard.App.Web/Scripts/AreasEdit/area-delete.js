function deleteArea(areaId, areaContainerId) {
    if (areaId) {
        $.post('/Area/DeleteArea', { areaId: areaId });
    }
    $("#" + areaContainerId).remove();
    $("#city-edit-list").empty();
}