function saveKind(typeInputId, kindsContainerId) {

    let type = $("#" + typeInputId).val();

    if (type) {

        let kind = {
            KindId: 0,
            Type: type
        };

        $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) }, function () { getKindList(kindsContainerId); });
    }
}