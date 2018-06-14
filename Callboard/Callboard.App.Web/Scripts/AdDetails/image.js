function getImageSrc(byteArray, extension) {
    console.log(byteArray);
    let base64 = convertByteToBase64(byteArray);
    let src = "data:image/" + extension + ";base64," + base64;
    return src;
}

let getFileInput = function () {
    let mainDiv = $("<div></div>");
    mainDiv.addClass('ad__image_big valign-wrapper file-field');

    let btnDiv = $("<div></div>");
    btnDiv.addClass('btn green center-auto');

    let span = $("<span></span>");
    span.append('<i class="material-icons">add</i>')

    let input = $('<input />');
    input.attr('type', 'file');

    btnDiv.append(span);
    btnDiv.append(input);

    mainDiv.append(btnDiv);

    return mainDiv;
}

function addImage(updateTargerId) {
    let imagesContainer = $("#" + updateTargerId);
    let fileInput = getFileInput();
    fileInput.addClass('col s3');
    let img = getImage();
    img.on('click', function () {
        this.remove();
    });

    fileInput.on('change', function (evt) {
        let tgt = evt.target || window.event.srcElement;
        let files = tgt.files;

        if (FileReader && files && files.length) {
            var fileReader = new FileReader();
            fileReader.onload = function () {
                img.attr('src', fileReader.result);
            }
            fileReader.readAsDataURL(files[0]);
            imagesContainer.append(img);
            fileInput.remove();
            addImage(updateTargerId);
        }
    });
    imagesContainer.append(fileInput);
}

let getImage = function () {
    let img = $("<img />");
    img.addClass('col s3');
    img.addClass('ad__image_big');
    return img;
}