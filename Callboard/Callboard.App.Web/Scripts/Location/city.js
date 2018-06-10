function fillCities(areaId) {
    getDataAsync({ areaId: areaId }, "/City/GetCitiesByAreaId", renderCities);
}

function clearCities() {
    let citiesContainer = getCitiesContainer();
    citiesContainer.empty();
    let defaultOption = createOption('cityId', 0, "--- Choose city ---");
    citiesContainer.append(defaultOption);
}

let renderCities = function (data) {
    clearCities();
    let citiesContainer = getCitiesContainer();
    let cities = JSON.parse(data.Cities);
    for (let i = 0; i < cities.length; i++) {
        let option = createOption('cityId', cities[i].CityId, cities[i].Name);
        citiesContainer.append(option);
    }
}

let getCitiesContainer = function () {
    return $('#cities');
}