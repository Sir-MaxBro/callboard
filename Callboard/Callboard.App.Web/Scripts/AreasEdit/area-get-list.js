function getAreaList(countryId, areasContainerId) {
    callActionAsync({ countryId: countryId }, '/Area/GetAreaEditListByCountryId', areasContainerId);
}