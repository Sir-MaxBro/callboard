function saveArea(countryInputId, areaNameInputId, areasContainerId) {
    let areaNameInput = $("#" + areaNameInputId);
    let areaName = areaNameInput.val();

    let countryId = $("#" + countryInputId).val();

    if (countryId && areaName) {

        areaNameInput.removeClass('invalid__field');

        let areaModel = {
            Area: {
                AreaId: 0,
                Name: areaName
            },
            CountryId: countryId
        };
        $.post('/Area/SaveArea', { areaViewModelData: JSON.stringify(areaModel) }, function () { getAreaList(countryId, areasContainerId); });
    }
    else {
        areaNameInput.addClass('invalid__field');
    }
}