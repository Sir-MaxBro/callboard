function saveState(conditionInputId, statesContanerId) {

    let conditionInput = $("#" + conditionInputId);
    let condition = conditionInput.val();

    if (condition && !isTextValueExist(condition, statesContanerId)) {

        let state = {
            StateId: 0,
            Condition: condition
        };

        $.post('/State/SaveState', { stateData: JSON.stringify(state) }, function () { getStateList(statesContanerId); });

        conditionInput.remove('invalid__field');
    }
    else {
        conditionInput.addClass('invalid__field');
    }
}