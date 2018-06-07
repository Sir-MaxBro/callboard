var updateTargetId;

function deleteUser(id, updateId) {
    updateTargetId = updateId;
    getDataAsync({ userId: id }, '/User/DeleteUserById', userDeleted);
}

var userDeleted = function (data) {
    var isDeleted = JSON.parse(data.IsDeleted);
    console.log(updateTargetId);
    if (isDeleted) {
        $("#" + updateTargetId).remove();
    }
}