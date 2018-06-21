function getKindList(kindsContainerId) {
    callActionAsync(null, '/Kind/GetKindsEditList', kindsContainerId);
}