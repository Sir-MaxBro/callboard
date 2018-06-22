function updateState(stateId, conditionInputId) {

    let condition = $("#" + conditionInputId).val();

    if (stateId && condition) {

        let state = {
            StateId: stateId,
            Condition: condition
        };

        $.post('/State/SaveState', { stateData: JSON.stringify(state) });
    }
}