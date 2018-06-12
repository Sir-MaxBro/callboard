﻿function fillLocation(updateTargetId) {
    let locationContainer = $("#" + updateTargetId);
    locationContainer.empty();

    let countrySelect = getCountrySelect();
    let areaSelect = getAreaSelect();
    let citySelect = getCitySelect();

    locationContainer.append(countrySelect);
    locationContainer.append(areaSelect);
    locationContainer.append(citySelect);

    loadCountries();
}

let getCountrySelect = function () {
    let countrySelect = $("<select></select>");
    countrySelect.attr('id', 'countries');
    countrySelect.on('change', function () {
        fillAreas(this.options[this.selectedIndex].value);
    });
    let defaultOption = createOption('', 0, '--- Choose country ---');
    defaultOption.attr('selected', 'selected');
    countrySelect.append(defaultOption);
    return countrySelect;
}

let getAreaSelect = function () {
    let areaSelect = $("<select></select>");
    areaSelect.attr('id', 'areas');
    areaSelect.on('change', function () {
        fillCities(this.options[this.selectedIndex].value);
    });
    let defaultOption = createOption('', 0, '--- Choose area ---');
    defaultOption.attr('selected', 'selected');
    areaSelect.append(defaultOption);
    return areaSelect;
}

let getCitySelect = function () {
    let citySelect = $("<select></select>");
    citySelect.attr('id', 'cities');
    let defaultOption = createOption('', 0, '--- Choose city ---');
    defaultOption.attr('selected', 'selected');
    citySelect.append(defaultOption);
    return citySelect;
}