function saveSubcategory(nameInputId, parentId, subcategoryContainerId) {

    let nameInput = $("#" + nameInputId);
    let categoryName = nameInput.val();

    if (categoryName && parentId) {

        let category = {
            CategoryId: 0,
            Name: categoryName,
            ParentId: parentId
        };

        $.post('/Category/SaveCategory', { categoryData: JSON.stringify(category) }, function () { getSubcategoryList(null, parentId, subcategoryContainerId); });
    }
}