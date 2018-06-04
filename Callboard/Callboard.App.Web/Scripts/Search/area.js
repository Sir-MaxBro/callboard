function fillAreas(countryId) {
    getDataAsync({ countryId: countryId }, "/Area/GetAreasByCountryId", renderAreas);
}

var renderAreas = function (data) {
    var areasContainer = $('#areas');
    areasContainer.empty();
    var defaultOption = renderDefaultOption('area');
    areasContainer.append(defaultOption);
    var areas = JSON.parse(data.Areas);
    for (var i = 0; i < areas.length; i++) {
        var option = createOption('areaId', areas[i].AreaId, areas[i].Name);
        areasContainer.append(option);
    }
}