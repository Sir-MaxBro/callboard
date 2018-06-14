function setViewSection(id, name, mainContainer, saveOnClick, deleteOnClick) {
    let container = getMainContainer();
    let nameContainer = getNameContainer().text(name);

    let editLink = getEditLink(id, name, mainContainer);
    editLink.on('click', function () {
        setEditSection(id, name, mainContainer, saveOnClick);
        container.remove();
    });
    let deleteLink = getDeleteLink(id, mainContainer);
    deleteLink.on('click', function () {
        deleteOnClick(id, mainContainer);
    });

    container.append(nameContainer);
    container.append(editLink);
    container.append(deleteLink);

    mainContainer.append(container);
}

let setEditSection = function (id, name, mainContainer, saveOnClick) {
    let container = getMainContainer();
    let nameInput = getNameInput();
    nameInput.val(name);

    let saveLink = getSaveLink();
    saveLink.on('click', function () {
        let newName = nameInput.val();
        saveOnClick.call(this, id, newName);
        setViewSection(id, newName, mainContainer);
        container.remove();
    });

    container.append(nameInput);
    container.append(saveLink);

    mainContainer.append(container);
}

function getEditLink() {
    let link = $("<a></a>");
    link.addClass('btn btn-small waves-effect waves-light green col s4');
    link.append('<i class="material-icons left">edit</i>edit');
    return link;
}

function getDeleteLink() {
    let deleteLink = $("<a></a>");
    deleteLink.addClass('btn btn-small waves-effect waves-light red col s4');
    deleteLink.append('<i class="material-icons left">delete</i>Delete');
    return deleteLink;
}

function getSaveLink() {
    let saveLink = $("<a></a>");
    saveLink.addClass('btn btn-small waves-effect waves-light green col s4');
    saveLink.append('<i class="material-icons left">save</i>Save');
    return saveLink;
}

function getAddLink() {
    let addLink = $("<a></a>");
    addLink.addClass('btn btn-small waves-effect waves-light green col s4');
    addLink.append('<i class="material-icons left">add</i>Add');
    return addLink;
}

function getNameContainer() {
    let nameContainer = $('<div></div>');
    nameContainer.addClass('center col s4');
    return nameContainer;
}

function getMainContainer() {
    let mainDiv = $("<div></div>");
    mainDiv.addClass('center row valign-wrapper');
    return mainDiv;
}

function getSubcontainer() {
    let mainDiv = $("<div></div>");
    mainDiv.addClass('card');
    return mainDiv;
}

function getNameInput() {
    let input = $("<input />");
    input.attr('type', 'text');
    input.addClass('col s8');
    return input;
}