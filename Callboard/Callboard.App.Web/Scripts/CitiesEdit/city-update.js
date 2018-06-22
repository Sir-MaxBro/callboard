function updateCity(cityId, areaId, cityNameInputId) {
    let cityNameInput = $("#" + cityNameInputId);
    let cityName = cityNameInput.val();
    if (cityId && areaId && cityName) {

        cityNameInput.removeClass('invalid__field');

        let cityModel = {
            City: {
                CityId: cityId,
                Name: cityName
            },
            AreaId: areaId
        };

        $.post('/City/SaveCity', { cityViewModelData: JSON.stringify(cityModel) });
    }
    else {
        cityNameInput.addClass('invalid__field');
    }
}