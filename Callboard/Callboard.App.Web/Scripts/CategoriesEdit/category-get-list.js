function getCategoryList(categoryContainerId) {
    callActionAsync(null, '/Category/GetCategoryEditList', categoryContainerId);
}