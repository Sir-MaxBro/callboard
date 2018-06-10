let updateTargetId;

function deleteUser(id, updateId) {
    updateTargetId = updateId;
    postDataAsync(JSON.stringify({ userId: id }), '/User/DeleteUserById', userDeleted);
}

let userDeleted = function (data) {
    let isDeleted = JSON.parse(data.IsDeleted);
    if (isDeleted) {
        $("#" + updateTargetId).remove();
    }
}