function saveUser() {
    let userModel = getUserModel();
    if (userModel.isValid) {
        $.post('/User/SaveUser', { userData: JSON.stringify(userModel.user) }, showUserSaveResult);
    }
}

let showUserSaveResult = function (data) {
    let saveResultContainer = $("#save-result");
    saveResultContainer.removeClass('none');
    setTimeout(function () {
        saveResultContainer.addClass('none');
    }, 4000);
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

let getUserModel = function () {
    let userId = $("#userId").val();
    let name = $("#name").val();
    let phonesModel = getPhonesModel();
    let mailsModel = getMailsModel();
    let photo = getPhoto();

    return {
        user: {
            UserId: userId,
            Name: name,
            PhotoData: photo.photoData,
            PhotoExtension: photo.extension,
            Phones: phonesModel.phones,
            Mails: mailsModel.mails
        },
        isValid: userId && name && phonesModel.isPhoneValid && mailsModel.isMailsValid
    };
}

let getPhoto = function () {
    let extension = null;
    let photoBuffer = null;
    let photoData = $("#photo").attr('src').split(";");

    if (photoData.length > 1) {
        extension = photoData[0].split(":")[1].split("/")[1];
        photoBuffer = convertBase64ToByte(photoData[1].split(",")[1]);
    }

    return {
        extension: extension,
        photoData: photoBuffer
    };
}

let getPhonesModel = function () {
    let phones = [];
    let isPhoneValid = true;
    $("#phones").find("input:text").each(function () {
        let phoneId = $(this).data('phoneId');
        let number = $(this).val();

        if (typeof phoneId === 'undefined') {
            phoneId = 0;
        }

        if (isNumberValid(number)) {
            let phone = {
                PhoneId: phoneId,
                Number: number
            };
            phones.push(phone);
            $(this).removeClass('invalid__field');
        }
        else {
            $(this).addClass('invalid__field');
            isPhoneValid = false;
        }
    });

    return {
        phones: phones,
        isPhoneValid: isPhoneValid
    };
}

let getMailsModel = function () {
    let mails = [];
    let isMailsValid = true;
    $("#emails").find("input:text").each(function () {
        let mailId = $(this).data('mailId');
        let email = $(this).val();

        if (typeof mailId === 'undefined') {
            mailId = 0;
        }

        if (isEmailValid(email)) {
            let mail = {
                MailId: mailId,
                Email: email
            };
            mails.push(mail);
            $(this).removeClass('invalid__field');
        }
        else {
            $(this).addClass('invalid__field');
            isMailsValid = false;
        }
    });
    return {
        mails: mails,
        isMailsValid: isMailsValid
    };
}

let isNumberValid = function (number) {
    let phoneRegex = /([0-9]{10})|(\([0-9]{3}\)\s+[0-9]{3}\-[0-9]{4})/;
    return phoneRegex.test(number);
}

let isEmailValid = function (email) {
    let emailRegex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return emailRegex.test(email);
}