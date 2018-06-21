function getSubcategoryList(link, categoryId, subcategoryContainerId) {

    if (categoryId) {

        let subcategoriesLoaded = function () {
            if (link) {
                $(link)[0].onclick = null;
                $(link).click(function () {
                    $("#" + subcategoryContainerId).slideToggle();
                });
            }
            $("#" + subcategoryContainerId).slideDown();
        }

        callActionAsync({ categoryId: categoryId }, '/Category/GetSubcategoryEditList', subcategoryContainerId, subcategoriesLoaded);
    }
}