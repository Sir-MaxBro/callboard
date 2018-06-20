function updateArea(areaId, countryId, areaNameInputId) {
    let areaNameInput = $("#" + areaNameInputId);
    let areaName = areaNameInput.val();
    if (areaId && countryId && areaName) {

        areaNameInput.removeClass('invalid__field');

        let areaModel = {
            Area: {
                AreaId: areaId,
                Name: areaName
            },
            CountryId: countryId
        };

        $.post('/Area/SaveArea', { areaViewModelData: JSON.stringify(areaModel) });
    }
    else {
        areaNameInput.addClass('invalid__field');
    }
}