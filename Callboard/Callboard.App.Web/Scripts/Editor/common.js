function setViewSection(id, name, mainContainer, saveOnClick) {
    let container = $("<div></div>");
    let nameContainer = $("<div></div>").text(name);

    let changeLink = renderLink('change', function () {
        setEditSection(id, name, mainContainer, saveOnClick);
        container.remove();
    });

    container.append(nameContainer);
    container.append(changeLink);

    mainContainer.append(container);
}

let setEditSection = function (id, name, mainContainer, saveOnClick) {
    let container = $("<div></div>");

    let input = $("<input />").attr('type', 'text');
    input.val(name);

    let saveLink = renderLink('save', function () {
        let newName = input.val();
        saveOnClick.call(this, id, newName);
        setViewSection(id, newName, mainContainer);
        container.remove();
    });

    container.append(input);
    container.append(saveLink);

    mainContainer.append(container);
}