function deleteCity(cityId, cityContainerId) {
    if (cityId) {
        $.post('/City/DeleteCity', { cityId: cityId });
    }
    $("#" + cityContainerId).remove();
}