function saveCity(areaInputId, cityNameInputId, citiesContainerId) {
    let cityNameInput = $("#" + cityNameInputId);
    let cityName = cityNameInput.val();

    let areaId = $("#" + areaInputId).val();

    if (areaId && cityName && !isTextValueExist(cityName, citiesContainerId)) {

        let cityModel = {
            City: {
                CityId: 0,
                Name: cityName
            },
            AreaId: areaId
        };

        $.post('/City/SaveCity', { cityViewModelData: JSON.stringify(cityModel) }, function () { getCityList(areaId, citiesContainerId); });

        cityNameInput.removeClass('invalid__field');
    }
    else {
        cityNameInput.addClass('invalid__field');
    }
}