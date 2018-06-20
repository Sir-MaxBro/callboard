function saveCountry(countryNameInputId, countriesContainerId) {
    let countryNameInput = $("#" + countryNameInputId);
    let countryName = countryNameInput.val();

    if (countryName) {

        countryNameInput.removeClass('invalid__field');

        let country = {
            CountryId: 0,
            Name: countryName
        };

        $.post('/Country/SaveCountry', { countryData: JSON.stringify(country) }, function () { getCountryList(countriesContainerId); });
    }
    else {
        countryNameInput.addClass('invalid__field');
    }
}