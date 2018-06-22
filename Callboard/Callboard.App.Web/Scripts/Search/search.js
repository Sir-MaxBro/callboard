function searchByParams() {
    runPreloader();
    let searchConfiguration = getSearchConfiguration();
    callActionAsync({ searchConfigurationData: JSON.stringify(searchConfiguration) }, "/Search/SearchAds", "search-result", searchComplete);
}

let getSearchConfiguration = function () {
    let name = $("#name").val();
    let countryId = $("#countries").find(":selected").val();
    let areaId = $("#areas").find(":selected").val();
    let cityId = $("#cities").find(":selected").val();
    let kind = $("#kinds").find(":selected").val();
    let state = $("#states").find(":selected").val();
    let minPrice = getMinPrice();
    let maxPrice = getMaxPrice();
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

let getMinPrice = function () {
    let minPrice = $("#min-price").val();
    if (minPrice === '') {
        minPrice = 0;
    }
    return minPrice;
}

let getMaxPrice = function () {
    let maxPrice = $("#max-price").val();
    if (maxPrice === '') {
        maxPrice = 0;
    }
    return maxPrice;
}

let getSearchCategories = function () {
    let categories = [];
    $("#categories").find(":checked").each(function () {
        let category = {
            CategoryId: $(this).data('categoryId')
        };
        categories.push(category);
    });
    return categories;
}

let searchComplete = function () {
    stopPreloader();
    $('.carousel').carousel();
}

let runPreloader = function () {
    let searchResultContainer = $("#search-result");
    searchResultContainer.empty();
    let preloader = $("#preloader");
    preloader.removeClass('none');
    preloader.addClass('active');
}

let stopPreloader = function () {
    let preloader = $("#preloader");
    preloader.removeClass('active');
    preloader.addClass('none');
}