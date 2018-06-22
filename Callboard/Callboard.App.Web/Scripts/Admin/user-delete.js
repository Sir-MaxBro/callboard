function deleteUser(userId, updateTargetId) {
    postDataAsync(JSON.stringify({ userId: userId }), '/User/DeleteUserById');
    $("#" + updateTargetId).remove();
    $("#edit-container__user").empty();
    $("#edit-container__roles").empty();
}