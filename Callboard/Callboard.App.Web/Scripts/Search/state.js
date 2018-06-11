function loadStates() {
    getDataAsync(null, "/State/GetStates", renderStates);
}

let renderStates = function (data) {
    clearStates();
    let stateContainer = getStatesContainer();
    let states = JSON.parse(data.States);
    for (let i = 0; i < states.length; i++) {
        let option = createOption('state', states[i].Condition, states[i].Condition);
        stateContainer.append(option);
    }
}

let clearStates = function () {
    let stateContainer = getStatesContainer();
    stateContainer.empty();
    let defaultOption = createOption('state', '', "--- Choose state ---");
    stateContainer.append(defaultOption);
}

let getStatesContainer = function () {
    return $('#states');
}