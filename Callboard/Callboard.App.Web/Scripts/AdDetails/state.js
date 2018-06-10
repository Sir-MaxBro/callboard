function statesLoad() {
    getDataAsync(null, "/State/GetStates", renderStates);
}

let renderStates = function (data) {
    let stateContainer = getStatesContainer();
    stateContainer.empty();
    let states = JSON.parse(data.States);
    for (let i = 0; i < states.length; i++) {
        let option = createOption('state', states[i].Condition, states[i].Condition);
        stateContainer.append(option);
    }
}

let getStatesContainer = function () {
    return $('#states');
}