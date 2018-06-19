function addRoleForUser(userId) {
    let select = $("#roles-select");
    let roleId = select.find(':selected').val();
    if (roleId) {
        $.post('/Role/SetRoleForUser', { userId: userId, roleId: roleId }, function () { fillRolesForUser(userId); });
    }
}