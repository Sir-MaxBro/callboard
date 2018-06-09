let updateTargetId;

function deleteUser(id, updateId) {
    updateTargetId = updateId;
    getDataAsync({ userId: id }, '/User/DeleteUserById', userDeleted);
}

let userDeleted = function (data) {
    let isDeleted = JSON.parse(data.IsDeleted);
    console.log(updateTargetId);
    if (isDeleted) {
        $("#" + updateTargetId).remove();
    }
}