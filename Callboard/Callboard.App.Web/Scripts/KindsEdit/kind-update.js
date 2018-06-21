function updateKind(kindId, typeInputId) {
    let type = $("#" + typeInputId).val();
    if (kindId && type) {
        let kind = {
            KindId: kindId,
            Type: type
        };
        $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) });
    }
}