let kindUpdateTargetId;

function loadKinds(updateTargetId) {
    kindUpdateTargetId = updateTargetId;
    getDataAsync(null, "/Kind/GetKinds", renderKinds);
}

function addKind(updateTargetId) {
    let kindsContainer = $("#" + updateTargetId);
    let mainKindContainer = $("<div></div>");
    setViewSection(0, 'New kind', mainKindContainer, saveKind);
    kindsContainer.append(mainKindContainer);
}

let renderKinds = function (data) {
    let kinds = JSON.parse(data.Kinds);
    let kindsContainer = $("#" + kindUpdateTargetId);
    for (let i = 0; i < kinds.length; i++) {
        let mainKindContainer = $("<div></div>");
        setViewSection(kinds[i].KindId, kinds[i].Type, mainKindContainer, saveKind, deleteKind);

        kindsContainer.append(mainKindContainer);
    }
}

let saveKind = function (kindId, kindName) {
    let kind = {
        KindId: kindId,
        Type: kindName
    };
    $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) });
}

let deleteKind = function (kindId, mainContainer) {
    $.post('/Kind/DeleteKind', { kindId: kindId });
    mainContainer.remove();
}