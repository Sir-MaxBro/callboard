function deleteState(stateId, stateContainerId) {
    if (stateId) {
        $.post('/State/DeleteState', { stateId: stateId });
    }
    $("#" + stateContainerId).remove();
}