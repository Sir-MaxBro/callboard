function deleteUserRole(userId, roleId, userRoleContainerId) {
    if (userId && roleId) {
        let deleteRoleView = function () {
            $("#" + userRoleContainerId).remove();
        }
        $.post('/Role/DeleteUserRole', { userId: userId, roleId: roleId }, deleteRoleView);
    }
}