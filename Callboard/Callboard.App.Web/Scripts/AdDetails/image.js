function fillImages(images, updateTargerId) {
    let imagesContainer = $("#" + updateTargerId);
    imagesContainer.empty();

    for (let i = 0; i < images.length; i++) {
        let img = getImage();

        let imageBase64 = convertByteToBase64(images[i].Data);

        img.attr('src', `data:image/${images[i].Extension};base64,${imageBase64}`);
        img.attr('data-image-id', images[i].ImageId);
        img.attr('data-extension', images[i].Extension);

        imagesContainer.append(img);
    }
}

function addImage(updateTargerId) {
    let imagesContainer = $("#" + updateTargerId);
    let fileInput = $("<input />").attr('type', 'file');
    let img = getImage();
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