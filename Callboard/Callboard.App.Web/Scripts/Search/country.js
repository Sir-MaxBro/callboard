function countriesLoad() {
    getDataAsync(null, "/Country/GetCountries", renderCountries);
}

var renderCountries = function (data) {
    var countriesContainer = $('#countries');
    var countries = JSON.parse(data.Countries);
    for (var i = 0; i < countries.length; i++) {
        var option = createOption('countryId', countries[i].CountryId, countries[i].Name);
        countriesContainer.append(option);
    }
}