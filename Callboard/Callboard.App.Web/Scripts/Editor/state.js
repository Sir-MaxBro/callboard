let stateUpdateTargetId;

function loadStates(updateTargetId) {
    stateUpdateTargetId = updateTargetId;
    getDataAsync(null, "/State/GetStates", renderStates);
}

function addState(updateTargetId) {
    let statesContainer = $("#" + updateTargetId);
    let mainStateContainer = $("<div></div>");
    setViewSection(0, 'New state', mainStateContainer, saveState);
    statesContainer.append(mainStateContainer);
}

let renderStates = function (data) {
    let states = JSON.parse(data.States);
    let statesContainer = $("#" + stateUpdateTargetId);
    for (let i = 0; i < states.length; i++) {
        let mainStateContainer = $("<div></div>");
        setViewSection(states[i].StateId, states[i].Condition, mainStateContainer, saveState, deleteState);
        statesContainer.append(mainStateContainer);
    }
}

let saveState = function (stateId, condition) {
    let state = {
        StateId: stateId,
        Condition: condition
    };
    $.post('/State/SaveState', { stateData: JSON.stringify(state) });
}

let deleteState = function (stateId, mainContainer) {
    $.post('/State/DeleteState', { stateId: stateId });
    mainContainer.remove();
}