function deleteCountry(countryId, countryContainerId) {
    if (countryId) {
        $.post('/Country/DeleteCountry', { countryId: countryId });
    }
    $("#" + countryContainerId).remove();
}