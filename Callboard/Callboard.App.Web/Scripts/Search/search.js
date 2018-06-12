function searchByParams() {
    let searchConfiguration = getSearchConfiguration();
    callActionAsync({ searchConfigurationData: JSON.stringify(searchConfiguration) }, "/Search/SearchAds", "search-result");
}

let getSearchConfiguration = function () {
    let name = $("#name").val();
    let countryId = $("#countries").find(":selected").val();
    let areaId = $("#areas").find(":selected").val();
    let cityId = $("#cities").find(":selected").val();
    let kind = $("#kinds").find(":selected").val();
    let state = $("#states").find(":selected").val();
    let minPrice = $("#min-price").val();
    let maxPrice = $("#max-price").val();
    let categories = getSearchCategories();
    let searchConfiguration = {
        Name: name,
        CountryId: countryId,
        AreaId: areaId,
        CityId: cityId,
        Kind: kind,
        State: state,
        MinPrice: minPrice,
        MaxPrice: maxPrice,
        Categories: categories
    };
    return searchConfiguration;
}

let getSearchCategories = function () {
    let categories = [];
    $("#categories").find(":selected").each(function () {
        let category = {
            CategoryId: $(this).val()
        };
        categories.push(category);
    });
    return categories;
}