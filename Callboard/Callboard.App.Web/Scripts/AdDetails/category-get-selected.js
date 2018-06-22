function getSelectedCategoryList(selectedCategories, categoryContainerId) {
    callActionAsync(null, '/Category/GetMainCategories', 'categories');
}