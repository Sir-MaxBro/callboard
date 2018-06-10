function fillAreas(countryId) {
    if (countryId === 0) {
        clearAreas();
    }
    else {
        getDataAsync({ countryId: countryId }, "/Area/GetAreasByCountryId", renderAreas);
    }
}

function clearAreas() {
    clearCities();
    let areasContainer = getAreasContainer();
    areasContainer.empty();
    let defaultOption = createOption('areaId', 0, "--- Choose area ---");
    areasContainer.append(defaultOption);
}

let renderAreas = function (data) {
    clearAreas();
    let areasContainer = getAreasContainer();
    let areas = JSON.parse(data.Areas);
    for (let i = 0; i < areas.length; i++) {
        let option = createOption('areaId', areas[i].AreaId, areas[i].Name);
        areasContainer.append(option);
    }
}

let getAreasContainer = function () {
    return $('#areas');
}