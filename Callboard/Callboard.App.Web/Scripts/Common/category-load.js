let selectedCategories;
let categotyUpdateTargetId;

function loadCategories(updateTargetId, selectedCategoriesData) {
    selectedCategories = selectedCategoriesData;
    categotyUpdateTargetId = updateTargetId;
    getDataAsync(null, '/Category/GetCategories', renderCategories);
}

let renderCategories = function (data) {
    let categories = JSON.parse(data.Categories);
    let categoryContainer = $("#" + categotyUpdateTargetId);
    categoryContainer.empty();
    for (let i = 0; i < categories.length; i++) {
        let option = createOption('Categories[' + i + '].CategoryId', categories[i].CategoryId, categories[i].Name);

        if (isSelected(categories[i].CategoryId)) {
            option.attr('selected', 'selected');
        }

        categoryContainer.append(option);
    }
}

let isSelected = function (categoryId) {
    if (typeof selectedCategories !== 'undefined' && selectedCategories !== null) {
        for (let i = 0; i < selectedCategories.length; i++) {
            if (selectedCategories[i].CategoryId === categoryId) {
                return true;
            }
        }
    }
    return false;
}