function loadRolesOptions() {
    getDataAsync(null, '/Role/GetRoles', fillRoles);
}

let fillRoles = function (data) {
    let select = $("#roles-select");
    let roles = JSON.parse(data.Roles);
    for (let i = 0; i < roles.length; i++) {
        let option = createOption('', roles[i].RoleId, roles[i].Name);
        select.append(option);
    }
}