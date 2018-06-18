function getSubcategories(link, categoryId, updateTargetId) {

    let subcategoriesLoaded = function () {
        $(link)[0].onclick = null;
        $(link).click(function () {
            $("#" + updateTargetId).slideToggle();
        });
        $(link).click();
    }

    callActionAsync({ categoryId: categoryId }, '/Category/GetSubcategories', updateTargetId, subcategoriesLoaded);
}