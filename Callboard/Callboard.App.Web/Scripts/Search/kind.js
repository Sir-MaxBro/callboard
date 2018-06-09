function kindsLoad() {
    getDataAsync(null, "/Kind/GetKinds", renderKinds);
}

let renderKinds = function (data) {
    clearKinds();
    let kindsContainer = getKindsContainer();
    let kinds = JSON.parse(data.Kinds);
    for (let i = 0; i < kinds.length; i++) {
        let option = createOption('kind', kinds[i].Type, kinds[i].Type);
        kindsContainer.append(option);
    }
}

let clearKinds = function () {
    let kindsContainer = getKindsContainer();
    kindsContainer.empty();
    let defaultOption = createOption('kind', '', "--- Choose kind ---");
    kindsContainer.append(defaultOption);
}

let getKindsContainer = function () {
    return $('#kinds');
}