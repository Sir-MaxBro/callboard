function loadAreas(countryId, areasContainerId) {
    callActionAsync({ countryId: countryId }, '/Area/GetAreaEditListByCountryId', areasContainerId);
    $("#country-id").val(countryId);
    $("#city-edit-list").empty();
}