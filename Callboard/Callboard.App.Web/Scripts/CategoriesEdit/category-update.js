function updateCategory(nameInputId, parentId, categoryId) {

    let nameInput = $("#" + nameInputId);
    let categoryName = nameInput.val();

    if (categoryName && parentId >= 0 && categoryId) {

        let category = {
            CategoryId: categoryId,
            Name: categoryName,
            ParentId: parentId
        };

        $.post('/Category/SaveCategory', { categoryData: JSON.stringify(category) });
    }
}