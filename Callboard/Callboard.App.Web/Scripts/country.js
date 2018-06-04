function countriesLoad() {
    getDataAsync(null, "/Country/GetCountries", renderCountries);
}

function fillAreas(countryId) {
    getDataAsync({ countryId: countryId }, "/Area/GetAreasByCountryId", renderAreas);
}

function fillCities(areaId) {
    getDataAsync({ areaId: areaId }, "/City/GetCitiesByAreaId", renderCities);
}

var renderCountries = function (data) {
    var countriesContainer = $('#countries');
    var countries = JSON.parse(data.Countries);
    for (var i = 0; i < countries.length; i++) {
        var option = createOption('countryId', countries[i].CountryId, countries[i].Name);
        countriesContainer.append(option);
    }
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

var renderDefaultOption = function (name) {
    var option = $('<option></option>');
    option.attr('selected', 'selected');
    option.text('--- Choose ' + name + ' ---');
    return option;
}

var createOption = function (name, value, text) {
    var option = $('<option></option>');
    option.attr('name', name);
    option.attr('value', value);
    option.text(text);
    return option;
}

window.addEventListener("load", function () {
    countriesLoad();
})