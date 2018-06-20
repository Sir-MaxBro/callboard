function getCityList(areaId, citiesContainerId) {
    callActionAsync({ areaId: areaId }, '/City/GetCityEditListByAreaId', citiesContainerId);
}