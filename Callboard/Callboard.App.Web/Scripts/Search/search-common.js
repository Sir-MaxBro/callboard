function renderDefaultOption(name) {
    var option = $('<option></option>');
    option.attr('selected', 'selected');
    option.text('--- Choose ' + name + ' ---');
    return option;
}

function createOption(name, value, text) {
    var option = $('<option></option>');
    option.attr('name', name);
    option.attr('value', value);
    option.text(text);
    return option;
}