function loadSubcategories(link, categoryId, updateTargetId) {

    if (categoryId !== 0) {

        let subcategoriesLoaded = function () {
            $(link)[0].onclick = null;
            $(link).click(function () {
                $("#" + updateTargetId).slideToggle();
            });
            $(link).click();
        }

        callActionAsync({ categoryId: categoryId }, '/Category/GetEditSubcategories', updateTargetId, subcategoriesLoaded);
    }
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

function createCategory(updateTargetId) {
    $.ajax({
        url: '/Category/CreateSubcategory',
        type: 'GET',
        contentType: 'application/json',
        data: { parentId: 0 },
        dataType: "html",
        success: function (data) {
            $('#' + updateTargetId).append(data);
        }
    });
}

function createSubcategory(parentId, updateTargetId) {
    if (parentId !== 0) {
        $.ajax({
            url: '/Category/CreateSubcategory',
            type: 'GET',
            contentType: 'application/json',
            data: { parentId: parentId },
            dataType: "html",
            success: function (data) {
                $('#' + updateTargetId).append(data);
                $('#' + updateTargetId).slideDown();
            }
        });
    }
}

function deleteCategory(categoryId, updateTargetId) {
    if (categoryId !== 0) {
        $.post('/Category/DeleteCategory', { categoryId: categoryId });
    }
    $("#" + updateTargetId).remove();
}