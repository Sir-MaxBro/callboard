function getCountryList(countriesContainerId) {
    callActionAsync(null, '/Country/GetCountryEditList', countriesContainerId);
}