function saveCategory(nameInputId, categoryContainerId) {

    let nameInput = $("#" + nameInputId);
    let categoryName = nameInput.val();

    if (categoryName) {

        let category = {
            CategoryId: 0,
            Name: categoryName,
            ParentId: 0
        };

        $.post('/Category/SaveCategory', { categoryData: JSON.stringify(category) }, function () { getCategoryList(categoryContainerId); });
    }
}