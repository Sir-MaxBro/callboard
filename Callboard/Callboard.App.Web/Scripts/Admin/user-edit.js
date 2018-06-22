function editUser(userId) {
    callActionAsync({ userId: userId }, '/User/EditUser', 'edit-container__user');
    fillRolesForUser(userId);
}

let fillRolesForUser = function (userId) {
    callActionAsync({ userId: userId }, '/Role/GetRolesEditList', "edit-container__roles");
}

function deleteUser(userId, updateTargetId) {
    postDataAsync(JSON.stringify({ userId: userId }), '/User/DeleteUserById');
    $("#" + updateTargetId).remove();
    $("#edit-container__user").empty();
    $("#edit-container__roles").empty();
}