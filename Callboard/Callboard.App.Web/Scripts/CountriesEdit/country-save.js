function saveCountry(countryNameInputId, countriesContainerId) {

    let countryNameInput = $("#" + countryNameInputId);
    let countryName = countryNameInput.val();

    if (countryName && !isTextValueExist(countryName, countriesContainerId)) {
        let country = {
            CountryId: 0,
            Name: countryName
        };

        $.post('/Country/SaveCountry', { countryData: JSON.stringify(country) }, function () { getCountryList(countriesContainerId); });

        countryNameInput.removeClass('invalid__field');
    }
    else {
        countryNameInput.addClass('invalid__field');
    }
}