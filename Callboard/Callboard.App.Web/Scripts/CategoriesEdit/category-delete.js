function deleteCategory(categoryId, updateTargetId) {
    if (categoryId) {
        $.post('/Category/DeleteCategory', { categoryId: categoryId });
    }
    $("#" + updateTargetId).remove();
}