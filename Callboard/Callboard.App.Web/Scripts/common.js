function createOption(name, value, text) {
    let option = $('<option></option>');
    option.attr('name', name);
    option.attr('value', value);
    option.text(text);
    return option;
}

function renderLink(text, click) {
    let link = $('<a></a>');
    link.attr('href', '#');
    link.text(text);
    link.on('click', function () {
        click.call();
    });
    return link;
}