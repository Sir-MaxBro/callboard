let categoryUpdateTargetId;
let _parentCategoryContainer;

function renderCategoryEditSections(updateTargetId) {
    categoryUpdateTargetId = updateTargetId;
    getDataAsync(null, '/Category/GetMainCategories', renderMainCategories);
}

function addCategory(updateTargetId) {
    let mainContainer = $("#" + updateTargetId);
    addSubcategory(0, mainContainer, saveCategory);
}

let renderSubcategoriesEditSection = function (categoryId, parentCategoryContainer) {
    _parentCategoryContainer = parentCategoryContainer;
    getDataAsync({ categoryId: categoryId }, '/Category/GetSubcategories', renderSubcategories);
}

let renderSubcategories = function (data) {
    let categoriesContainer = _parentCategoryContainer;
    let categories = JSON.parse(data.Categories);

    for (let i = 0; i < categories.length; i++) {
        let mainCategoryContainer = $("<div></div>");
        mainCategoryContainer.attr('style', 'padding: 5px');

        let categoryObj = {
            categoryId: categories[i].CategoryId,
            name: categories[i].Name,
            parentId: categories[i].ParentId
        };

        setCategoryViewSection(categoryObj, mainCategoryContainer, saveCategory);
        categoriesContainer.append(mainCategoryContainer);
    }
}

let renderMainCategories = function (data) {
    let categoriesContainer = $("#" + categoryUpdateTargetId);
    let categories = JSON.parse(data.Categories);

    for (let i = 0; i < categories.length; i++) {
        let mainCategoryContainer = $("<div></div>");
        mainCategoryContainer.attr('style', 'padding: 5px');

        let categoryObj = {
            categoryId: categories[i].CategoryId,
            name: categories[i].Name,
            parentId: categories[i].ParentId
        };

        setCategoryViewSection(categoryObj, mainCategoryContainer, saveCategory);
        categoriesContainer.append(mainCategoryContainer);
    }
}

let saveCategory = function (categoryObj) {
    let category = {
        CategoryId: categoryObj.categoryId,
        Name: categoryObj.name,
        ParentId: categoryObj.parentId
    };
    $.post('/Category/SaveCategory', { categoryData: JSON.stringify(category) });
}

let setAddCategoryLink = function (parentId, mainContainer, saveOnClick) {
    let link = renderLink('add', function () {
        addSubcategory(parentId, mainContainer, saveOnClick);
    });
    mainContainer.append(link);
}

let addSubcategory = function (parentId, mainContainer, saveOnClick) {
    let mainCategoryContainer = $("<div></div>");
    let categoryObj = {
        categoryId: 0,
        name: 'New category',
        parentId: parentId,
        isSaved: false
    };
    console.log(categoryObj);
    setCategoryViewSection(categoryObj, mainCategoryContainer, saveCategory);
    mainContainer.append(mainCategoryContainer);
}

let setGetSubcategoriesLink = function (parentId, parentCategoryContainer) {
    let link = renderLink('load subcategories', function () {
        renderSubcategoriesEditSection(parentId, parentCategoryContainer);
    });
    parentCategoryContainer.append(link);
}

let setCategoryViewSection = function (categoryObj, mainContainer, saveOnClick) {
    let container = $("<div></div>");
    let nameContainer = $("<div></div>").text(categoryObj.name);

    if (categoryObj.categoryId !== 0 || !categoryObj.isSaved) {
        let changeLink = renderLink('change', function () {
            setCategoryEditSection(categoryObj, mainContainer, saveOnClick);
            container.remove();
        });

        setAddCategoryLink(categoryObj.categoryId, mainContainer, saveCategory);
        setGetSubcategoriesLink(categoryObj.categoryId, mainContainer, saveCategory);
        container.append(changeLink);
    }

    container.append(nameContainer);
    mainContainer.append(container);
}

let setCategoryEditSection = function (categoryObj, mainContainer, saveOnClick) {
    let container = $("<div></div>");

    let input = $("<input />").attr('type', 'text');
    input.val(categoryObj.name);

    let saveLink = renderLink('save', function () {
        let newName = input.val();
        categoryObj.name = newName;
        categoryObj.isSaved = true;
        saveOnClick.call(this, categoryObj);
        setCategoryViewSection(categoryObj, mainContainer, saveOnClick);
        container.remove();
    });

    container.append(saveLink);
    container.append(input);
    mainContainer.append(container);
}