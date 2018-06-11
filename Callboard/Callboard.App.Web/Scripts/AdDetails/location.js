function getCityById(cityId) {
    getDataAsync({ cityId: cityId }, '/City/GetCityById', renderLocation);
}

let renderLocation = function (data) {
    let locationContainer = $("#location");
    let city = JSON.parse(data.City);
    locationContainer.append(city.Name);
    let changeLink = renderLink('Change location', changeLocation);
}

let changeLocation = function () {

}