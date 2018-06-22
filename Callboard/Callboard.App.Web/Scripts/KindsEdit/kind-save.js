function saveKind(typeInputId, kindsContainerId) {

    let typeInput = $("#" + typeInputId);
    let type = typeInput.val();

    if (type && !isTextValueExist(type, kindsContainerId)) {

        let kind = {
            KindId: 0,
            Type: type
        };

        $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) }, function () { getKindList(kindsContainerId); });

        typeInput.removeClass('invalid__field');
    }
    else {
        typeInput.addClass('invalid__field');
    }
}