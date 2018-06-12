function saveUser() {
    let user = getUser();
    console.log(user);
    $.post('/User/SaveUser', { userData: JSON.stringify(user) }, saveResult);
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

let saveResult = function (data) {
    console.log(data);
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
    return getInput();
}

let getMailInput = function () {
    return getInput();
}

let getInput = function () {
    let input = $("<input />");
    input.attr('type', 'text');
    return input;
}