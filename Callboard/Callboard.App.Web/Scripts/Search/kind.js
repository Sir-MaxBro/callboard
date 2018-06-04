function kindsLoad() {
    getDataAsync(null, "/Kind/GetKinds", renderKinds);
}

var renderKinds = function (data) {
    var kindsContainer = $('#kinds');
    var kinds = JSON.parse(data.Kinds);
    for (var i = 0; i < kinds.length; i++) {
        var option = createOption('kindId', kinds[i].KindId, kinds[i].Type);
        kindsContainer.append(option);
    }
}