function updateCountry(countryId, countryNameInputId, countryContainerId) {
    let countryNameInput = $("#" + countryNameInputId);

    let countryName = countryNameInput.val();

    if (countryId && countryName) {

        countryNameInput.removeClass('invalid__field');

        let country = {
            CountryId: countryId,
            Name: countryName
        };

        $.post('/Country/SaveCountry', { countryData: JSON.stringify(country) });
    }
    else {
        countryNameInput.addClass('invalid__field');
    }
}