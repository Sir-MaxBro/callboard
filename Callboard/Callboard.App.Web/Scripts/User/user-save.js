function saveUser() {
    let user = getUser();
    console.log(user);
    $.post('/User/SaveUser', { userData: JSON.stringify(user) }, showUserSaveResult);
}

function addPhone() {
    let phoneContainer = $("#phones");
    let input = getPhoneInput();
    phoneContainer.append(input);
}

function addMail() {
    let mailContainer = $("#emails");
    let input = getMailInput();
    mailContainer.append(input);
}

function fillPhoto(evt) {
    let tgt = evt.target || window.event.srcElement;
    let files = tgt.files;

    if (FileReader && files && files.length) {
        var fileReader = new FileReader();
        fileReader.onload = function () {
            let img = $("#photo");
            img.attr('src', fileReader.result);
        }
        fileReader.readAsDataURL(files[0]);
    }
}

let showUserSaveResult = function (data) {
    let isSaved = JSON.parse(data.IsSaved);
    if (isSaved === true) {
        let saveResultContainer = $("#save-result");
        saveResultContainer.empty();
        saveResultContainer.append('success');
    }
}

let getUser = function () {
    let userId = $("#userId").val();
    let name = $("#name").val();
    let phones = getPhones();
    let mails = getMails();
    let photo = getPhoto();

    return {
        UserId: userId,
        Name: name,
        PhotoData: photo.photoData,
        PhotoExtension: photo.extension,
        Phones: phones,
        Mails: mails
    };
}

let getPhoto = function () {
    let photoData = $("#photo").attr('src').split(";");
    let extension = photoData[0].split(":")[1].split("/")[1];
    let photoBase64 = photoData[1].split(",")[1];

    return {
        extension: extension,
        photoData: convertBase64ToByte(photoBase64)
    };
}

let getPhones = function () {
    let phones = [];
    $("#phones").find("input:text").each(function () {
        let phoneId = $(this).data('phoneId');
        if (typeof phoneId === 'undefined') {
            phoneId = 0;
        }

        let phone = {
            PhoneId: phoneId,
            Number: $(this).val()
        };
        phones.push(phone);
    });
    return phones;
}

let getMails = function () {
    let mails = [];
    $("#emails").find("input:text").each(function () {
        let mailId = $(this).data('mailId');
        if (typeof mailId === 'undefined') {
            mailId = 0;
        }

        let mail = {
            MailId: mailId,
            Email: $(this).val()
        };
        mails.push(mail);
    });
    return mails;
}

let getPhoneInput = function () {
    let div = $("<div></div>");
    div.addClass('input-field');

    let i = $("<i></i>");
    i.addClass('material-icons prefix');
    i.text('phone');

    let input = $("<input />");
    input.attr('type', 'text');
    input.addClass('validate');

    let label = $("<label></label>");
    label.attr('for', 'icon_prefix');
    label.text('Phone Number');

    div.append(i);
    div.append(input);
    div.append(label);

    return div;
}

let getMailInput = function () {
    return getInput();
}

let getInput = function () {
    let input = $("<input />");
    input.attr('type', 'text');
    input.addClass('field');
    return input;
}