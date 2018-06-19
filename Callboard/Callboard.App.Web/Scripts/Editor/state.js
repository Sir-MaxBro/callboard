function addState(updateTargetId) {
    $.ajax({
        url: '/State/CreateState',
        dataType: 'html',
        success: function (data) {
            $("#" + updateTargetId).append(data);
        }
    });
}

function saveState(stateId, conditionInputId) {
    let condition = $("#" + conditionInputId).val();
    if (condition) {
        let state = {
            StateId: stateId,
            Condition: condition
        };
        $.post('/State/SaveState', { stateData: JSON.stringify(state) }, function () { refreshPage(); });
    }
}

function deleteState(stateId, stateContainerId) {
    if (stateId) {
        $.post('/State/DeleteState', { stateId: stateId });
    }
    $("#" + stateContainerId).remove();
}