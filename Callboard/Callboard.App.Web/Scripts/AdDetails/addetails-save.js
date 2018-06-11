function saveAdDetails() {
    let adDetails = getAdDetails();
    console.log(adDetails);
    $.post('/AdDetails/SaveAdDetails', { adDetailsData: JSON.stringify(adDetails) });
}

let getAdDetails = function () {
    let name = $("#name").val();
    let price = $("#price").val();
    let description = $("#description").val();
    let addressLine = $("#addressLine").val();
    let kind = $("#kinds").find(":selected").val();
    let state = $("#states").find(":selected").val();
    let userId = $("#userId").val();
    let adId = $("#adId").val();

    let locationId = getLocationId();
    let categories = getCategoriesList();
    let images = getImages();

    return {
        Name: name,
        Price: price,
        Description: description,
        AddressLine: addressLine,
        Kind: kind,
        State: state,
        UserId: userId,
        AdId: adId,
        Location: {
            LocationId: locationId
        },
        Categories: categories,
        Images: images
    };
}

let getLocationId = function () {
    let locationId = $("#cities").find(":selected").val();
    if (typeof locationId != 'undefined') {
        return locationId;
    }
    else {
        return $("#locationId").val();
    }
}

let getCategoriesList = function () {
    let categories = [];
    $("#categories").find(":selected").each(function () {
        let category = {
            CategoryId: $(this).val()
        };
        categories.push(category);
    });
    return categories;
}

let getImages = function () {
    let images = [];
    $("#images").find("img").each(function () {
        let imageSrc = this.src;

        let imageData = imageSrc.split(";");
        let extension = imageData[0].split(":")[1].split("/")[1];
        let imageBase64 = imageData[1].split(",")[1];

        let imageId = $(this).data('imageId');
        if (typeof imageId == 'undefined') {
            imageId = 0;
        }

        let image = {
            ImageId: imageId,
            Data: convertBase64ToByte(imageBase64),
            Extension: extension
        };
        images.push(image);
    });
    return images;
}