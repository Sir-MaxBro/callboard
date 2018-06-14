function loadSubcategories(categoryId, updateTargetId) {
    callActionAsync({ categoryId: categoryId }, '/Category/GetEditSubcategories', updateTargetId);
}

function saveCategory(categoryId, nameTargetId, parentId) {
    let nameContainer = $("#" + nameTargetId);
    let newName = nameContainer.val();
    let category = {
        CategoryId: categoryId,
        Name: newName,
        ParentId: parentId
    };
    $.post('/Category/SaveCategory', { categoryData: JSON.stringify(category) }, function () { location.reload(); });
}

function createSubcategory(parentId, updateTargetId) {
    $.ajax({
        url: '/Category/CreateSubcategory',
        type: 'GET',
        contentType: 'application/json',
        data: { parentId: parentId },
        dataType: "html",
        success: function (data) {
            $('#' + updateTargetId).append(data);
        }
    });
}

function deleteCategory(categoryId, updateTargetId) {
    $.post('/Category/DeleteCategory', { categoryId: categoryId });
    $("#" + updateTargetId).remove();
}