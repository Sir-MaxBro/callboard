function statesLoad() {
    getDataAsync(null, "/State/GetStates", renderStates);
}

var renderStates = function (data) {
    var stateContainer = $('#states');
    var states = JSON.parse(data.States);
    for (var i = 0; i < states.length; i++) {
        var option = createOption('stateId', states[i].StateId, states[i].Condition);
        stateContainer.append(option);
    }
}