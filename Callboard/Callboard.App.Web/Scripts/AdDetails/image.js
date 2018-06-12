function getImageSrc(byteArray, extension) {
    console.log(byteArray);
    let base64 = convertByteToBase64(byteArray);
    let src = "data:image/" + extension + ";base64," + base64;
    return src;
}

function addImage(updateTargerId) {
    let imagesContainer = $("#" + updateTargerId);
    let fileInput = $("<input />").attr('type', 'file');
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
            fileInput.remove();
        }
        else {
            // fallback -- perhaps submit the input to an iframe and temporarily store
            // them on the server until the user's session ends.
        }
    });
    imagesContainer.append(fileInput);
    imagesContainer.append(img);
}

let getImage = function () {
    let img = $("<img />");
    img.attr('width', '100');
    img.attr('height', '100');
    return img;
}