function saveArea(countryInputId, areaNameInputId, areasContainerId) {

    let areaNameInput = $("#" + areaNameInputId);
    let areaName = areaNameInput.val();
    let countryId = $("#" + countryInputId).val();

    if (countryId && areaName && !isTextValueExist(areaName, areasContainerId)) {

        let areaModel = {
            Area: {
                AreaId: 0,
                Name: areaName
            },
            CountryId: countryId
        };

        $.post('/Area/SaveArea', { areaViewModelData: JSON.stringify(areaModel) }, function () { getAreaList(countryId, areasContainerId); });

        areaNameInput.removeClass('invalid__field');
    }
    else {
        areaNameInput.addClass('invalid__field');
    }
}