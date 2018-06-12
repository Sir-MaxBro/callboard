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
        setViewSection(kinds[i].KindId, kinds[i].Type, mainKindContainer, saveKind);

        let deleteLink = getDeleteKindLink(kinds[i].KindId, mainKindContainer);
        mainKindContainer.append(deleteLink);

        kindsContainer.append(mainKindContainer);
    }
}

let getDeleteKindLink = function (kindId, mainContainer) {
    let deleteLink = renderLink('delete kind', function () {
        $.post('/Kind/DeleteKind', { kindId: kindId });
        mainContainer.remove();
    });
    return deleteLink;
}

let saveKind = function (kindId, kindName) {
    let kind = {
        KindId: kindId,
        Type: kindName
    };
    $.post('/Kind/SaveKind', { kindData: JSON.stringify(kind) }, showKindSaveResult);
}

let showKindSaveResult = function (data) {
    let resultContainer = $("#kind-save-result");
    let isSaved = JSON.parse(data.IsSaved);
    if (isSaved === true) {
        resultContainer.empty();
        resultContainer.append('success');
    }
}