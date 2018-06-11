function loadCategories() {
    getDataAsync(null, '/Category/GetCategories', renderCategories);
}

let renderCategories = function (data) {
    let categories = JSON.parse(data.Categories);
    let categoryContainer = $("#categories");
    categoryContainer.empty();
    for (let i = 0; i < categories.length; i++) {
        let option = createOption('Categories[' + i + '].CategoryId', categories[i].CategoryId, categories[i].Name);
        categoryContainer.append(option);
    }
}