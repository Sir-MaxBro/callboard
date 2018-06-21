function loadCities(areaId, citiesContainerId) {
    callActionAsync({ areaId: areaId }, '/City/GetCityEditListByAreaId', citiesContainerId);
    $("#area-id").val(areaId);
}