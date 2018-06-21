function getKindList(kindsContainerId) {
    callActionAsync(null, '/Kind/GetKindEditList', kindsContainerId);
}