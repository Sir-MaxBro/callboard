const USER_ID_KEY = "userId";

function deleteUser(userId, updateTargetId) {
    postDataAsync(JSON.stringify({ userId: userId }), '/User/DeleteUserById');
    $("#" + updateTargetId).remove();
    $("#edit-container__user").empty();
    $("#edit-container__roles").empty();
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

    let role = getRoleRecordContainer();
    let addLink = getAddRoleLink();

    role.append(addLink);
    rolesContainer.append(role);

    let roles = JSON.parse(data.Roles);
    for (let i = 0; i < roles.length; i++) {

        let role = getRoleRecordContainer();
        let deleteLink = getDeleteRoleLink(userId, roles[i].RoleId);
        let roleNameContainer = getRoleNameContainer(roles[i].Name);

        role.append(roleNameContainer);
        role.append(deleteLink);

        rolesContainer.append(role);
    }
}

let renderRoles = function (data) {
    let userId = localStorage.getItem(USER_ID_KEY);
    let rolesContainer = $('#edit-container__roles');
    let roles = JSON.parse(data.Roles);
    let rolesSelect = getSelectForRoles();
    for (let i = 0; i < roles.length; i++) {
        let option = createOption('roleId', roles[i].RoleId, roles[i].Name);
        rolesSelect.append(option);
    }

    let role = getRoleRecordContainer();
    let saveLink = getSaveRoleLink(userId);

    role.append(rolesSelect);
    role.append(saveLink);

    rolesContainer.append(role);
}

let getRoleNameContainer = function (roleName) {
    let roleNameContainer = $("<div></div>");
    roleNameContainer.addClass('col s6')
    roleNameContainer.append(roleName);
    return roleNameContainer;
}

let getRoleRecordContainer = function () {
    let roleRecord = $('<div></div>');
    roleRecord.addClass('center row valign-wrapper');
    return roleRecord;
}

let getSaveRoleLink = function (userId) {
    let link = $("<a></a>");
    link.addClass('btn waves-effect waves-light green col s6');
    link.append('<i class="material-icons left">save</i>Save role');
    link.on('click', function () {
        let roleId = $("#roles").find(":selected").val();
        saveUserRole(userId, roleId);
    });
    return link;
}

let getAddRoleLink = function () {
    let link = $("<a></a>");
    link.addClass('btn waves-effect waves-light green center-auto');
    link.append('<i class="material-icons left">add</i>Add role');
    link.on('click', function () {
        getAllRoles();
    });
    return link;
}

let getDeleteRoleLink = function (userId, roleId) {
    let link = $("<a></a>");
    link.addClass('btn btn-small waves-effect waves-light red col s6');
    link.append('<i class="material-icons left">delete</i>Delete role');
    link.on('click', function () {
        deleteUserRole(userId, roleId);
    });
    return link;
}

let getSelectForRoles = function () {
    let rolesSelect = $('<select></select>');
    rolesSelect.attr('id', 'roles');
    rolesSelect.addClass('block col s6');
    return rolesSelect;
}