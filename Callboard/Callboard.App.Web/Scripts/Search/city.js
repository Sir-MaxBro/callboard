function fillCities(areaId) {
    getDataAsync({ areaId: areaId }, "/City/GetCitiesByAreaId", renderCities);
}

var renderCities = function (data) {
    var citiesContainer = $('#cities');
    citiesContainer.empty();
    var defaultOption = renderDefaultOption('city');
    citiesContainer.append(defaultOption);
    var cities = JSON.parse(data.Cities);
    for (var i = 0; i < cities.length; i++) {
        var option = createOption('cityId', cities[i].CityId, cities[i].Name);
        citiesContainer.append(option);
    }
}