function getStateList(statesContainerId) {
    callActionAsync(null, '/State/GetStateEditList', statesContainerId);
}