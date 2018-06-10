function kindsLoad() {
    getDataAsync(null, "/Kind/GetKinds", renderKinds);
}

let renderKinds = function (data) {
    let kindsContainer = getKindsContainer();
    kindsContainer.empty();
    let kinds = JSON.parse(data.Kinds);
    for (let i = 0; i < kinds.length; i++) {
        let option = createOption('kind', kinds[i].Type, kinds[i].Type);
        kindsContainer.append(option);
    }
}

let getKindsContainer = function () {
    return $('#kinds');
}