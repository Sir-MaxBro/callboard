﻿function getSelectedCategoryList(selectedCategories, categoryContainerId) {
    loadMainCategories(categoryContainerId);
    let categoryDictionary = getCategoryDictionary(selectedCategories);

    for (parentId in categoryDictionary) {
        if (+parentId === 0) {
            selectCategories(categoryDictionary[parentId], categoryContainerId);
        }
        loadCategories(+parentId, categoryDictionary[parentId], categoryContainerId);
    }
}

let loadMainCategories = function (categoryContainerId) {
    callAction(null, '/Category/GetMainCategories', categoryContainerId);
}

let getCategoryDictionary = function (selectedCategories) {
    let categoryDictionary = [];

    $(selectedCategories).each(function () {

        let parentId = $(this)[0].ParentId;
        let categoryId = $(this)[0].CategoryId;

        if (typeof categoryDictionary[parentId] === 'undefined') {
            categoryDictionary[parentId] = new Array();
        }

        categoryDictionary[parentId].push(categoryId);
    });
    return categoryDictionary;
}

let selectCategories = function (categories, categoriesContainerId) {
    $("#" + categoriesContainerId).find("input:checkbox").each(function () {

        let categoryId = $(this).data('categoryId');

        if (categories.includes(categoryId)) {
            $(this).prop('checked', true);
        }
    });
}

let loadCategories = function (parentId, selectedCategories, categoryContainerId) {
    if (parentId) {

        let subcategoryContainerId = "subcategories-" + parentId;

        callAction({ categoryId: parentId }, '/Category/GetSubcategories', subcategoryContainerId, function () {
            selectCategories(selectedCategories, subcategoryContainerId);

            let loadSubcategoriesLink = $("#load-subcategories-" + parentId);
            if (typeof $(loadSubcategoriesLink)[0] !== 'undefined') {

                $(loadSubcategoriesLink)[0].onclick = null;
                $(loadSubcategoriesLink).click(function () {
                    $("#" + subcategoryContainerId).slideToggle();
                });
            }

            $("#" + subcategoryContainerId).slideDown();
        });
    }
}