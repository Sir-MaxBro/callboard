function editUser(userId) {
    callActionAsync({ userId: userId }, '/User/EditUser', 'edit-container__user');
    fillRolesForUser(userId);
}

let fillRolesForUser = function (userId) {
    callActionAsync({ userId: userId }, '/Role/GetRolesEditList', "edit-container__roles");
}