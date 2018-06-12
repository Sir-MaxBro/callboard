const CATEGORY_KEY = "categoryId";

window.onload = function () {
    let categories = JSON.parse(localStorage.getItem(CATEGORY_KEY));
    if (categories !== null) {
        let categoryId = categories.pop();
        renderCategories(categoryId);
    }
}

window.onbeforeunload = function () {
    localStorage.removeItem(CATEGORY_KEY);
}

function getSubcategories(parentId, categoryId) {
    let categories = JSON.parse(localStorage.getItem(CATEGORY_KEY));
    if (categories === null) {
        categories = new Array();
    }
    categories.push(parentId);
    localStorage.setItem(CATEGORY_KEY, JSON.stringify(categories));
    renderCategories(categoryId);
}

function getPreviousCategories() {
    let categories = JSON.parse(localStorage.getItem(CATEGORY_KEY));
    if (categories !== null) {
        let categoryId = categories.pop();
        localStorage.setItem(CATEGORY_KEY, JSON.stringify(categories));
        renderCategories(categoryId);
    }
}

let renderCategories = function (categoryId) {
    if (categoryId === 0 || typeof categoryId === 'undefined') {
        takeCategories();
    }
    else {
        takeSubcategories(categoryId);
    }
}

let takeSubcategories = function (categoryId) {
    callActionAsync({ categoryId: categoryId }, '/Category/GetSubcategories', 'category-container');
}

let takeCategories = function () {
    callActionAsync(null, '/Category/GetCategories', 'category-container');
}