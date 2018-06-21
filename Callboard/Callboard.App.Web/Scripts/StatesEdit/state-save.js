function saveState(conditionInputId, statesContanerId) {

    let condition = $("#" + conditionInputId).val();

    if (condition) {

        let state = {
            StateId: 0,
            Condition: condition
        };

        $.post('/State/SaveState', { stateData: JSON.stringify(state) }, function () { getStateList(statesContanerId); });
    }
}