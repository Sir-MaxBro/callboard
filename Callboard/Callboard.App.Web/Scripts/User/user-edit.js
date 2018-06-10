const USER_ID_KEY = "userId";

function deleteUser(userId, updateTargetId) {
    postDataAsync(JSON.stringify({ userId: userId }), '/User/DeleteUserById');
    $("#" + updateTargetId).remove();
    $("#edit-container").empty();
}

function editUser(userId) {
    localStorage.setItem(USER_ID_KEY, userId);
    callActionAsync({ userId: userId }, '/User/EditUser', 'edit-container__user');
    getRolesForUser(userId);
}

let getRolesForUser = function (userId) {
    getDataAsync({ userId: userId }, '/Role/GetRolesForUser', renderRolesForUser);
}

let deleteUserRole = function (userId, roleId) {
    postDataAsync(JSON.stringify({ userId: userId, roleId: roleId }), '/Role/DeleteUserRole', renderRolesForUser);
}

let saveUserRole = function (userId, roleId) {
    postDataAsync(JSON.stringify({ userId: userId, roleId: roleId }), '/Role/SetRoleForUser', renderRolesForUser);
}

let getAllRoles = function () {
    getDataAsync(null, '/Role/GetRoles', renderRoles);
}

let renderRolesForUser = function (data) {
    let userId = localStorage.getItem(USER_ID_KEY);
    let rolesContainer = $('#edit-container__roles');
    rolesContainer.empty();

    let role = $('<div></div>');
    let addLink = renderLink('add role', function () {
        getAllRoles();
    });
    role.append(addLink);
    rolesContainer.append(role);

    let roles = JSON.parse(data.Roles);
    for (let i = 0; i < roles.length; i++) {
        let role = $('<div></div>');
        let deleteLink = renderLink('delete role', function () {
            deleteUserRole(userId, roles[i].RoleId);
        });
        role.append(roles[i].Name);
        role.append(deleteLink);
        rolesContainer.append(role);
    }
}

let renderRoles = function (data) {
    let userId = localStorage.getItem(USER_ID_KEY);
    let rolesContainer = $('#edit-container__roles');
    let roles = JSON.parse(data.Roles);
    let rolesSelect = $('<select></select>');
    rolesSelect.attr('id', 'roles');
    for (let i = 0; i < roles.length; i++) {
        let option = createOption('roleId', roles[i].RoleId, roles[i].Name);
        rolesSelect.append(option);
    }

    let role = $('<div></div>');
    let saveLink = renderLink('save role', function () {
        let roleId = $("#roles").find(":selected").val();
        saveUserRole(userId, roleId);
    });
    role.append(rolesSelect);
    role.append(saveLink);
    rolesContainer.append(role);
}

let renderLink = function (text, click) {
    let link = $('<a></a>');
    link.attr('href', '#');
    link.text(text);
    link.on('click', function () {
        click.call();
    });
    return link;
}