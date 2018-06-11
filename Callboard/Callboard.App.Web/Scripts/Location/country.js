function loadCountries() {
    getDataAsync(null, "/Country/GetCountries", renderCountries);
}

let renderCountries = function (data) {
    clearCountries();
    let countriesContainer = getCountriesContainer();
    let countries = JSON.parse(data.Countries);
    for (let i = 0; i < countries.length; i++) {
        let option = createOption('countryId', countries[i].CountryId, countries[i].Name);
        countriesContainer.append(option);
    }
}

let clearCountries = function () {
    clearAreas();
    let countriesContainer = getCountriesContainer();
    countriesContainer.empty();
    let defaultOption = createOption('countryId', 0, "--- Choose country ---");
    countriesContainer.append(defaultOption);
}

let getCountriesContainer = function () {
    return $('#countries');
}