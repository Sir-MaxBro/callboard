function saveAdDetails() {
    let adDetailsModel = getAdDetailsModel();
    if (adDetailsModel.isValid) {
        $.post('/AdDetails/SaveAdDetails', { adDetailsData: JSON.stringify(adDetailsModel.adDetails) }, showAdDetailsSaveResult);
    }
}

let showAdDetailsSaveResult = function (data) {
    let saveResultContainer = $("#save-result");
    saveResultContainer.removeClass('none');
    setTimeout(function () {
        saveResultContainer.addClass('none');
    }, 4000);
}

let getAdDetailsModel = function () {
    let name = getName();
    let price = getPrice();
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
        adDetails: {
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
        },
        isValid: name && price && userId && adId && locationId && categories.length
    };
}

let getName = function () {
    let name = $("#name").val();
    if (name === '') {
        name = 'Product';
    }
    return name;
}

let getPrice = function () {
    let price = +$("#price").val().replace(',', '.');
    if (price <= 0) {
        price = 1;
    }
    return price;
}

let getLocationId = function () {
    let locationId = $("#cities").find(":selected").val();
    if (typeof locationId === 'undefined') {
        locationId = $("#locationId").val();
    }
    if (locationId <= 0) {
        locationId = 1;
    }
    return locationId;
}

let getCategoriesList = function () {
    let categories = [];
    $("#categories").find(":checked").each(function () {
        let category = {
            CategoryId: $(this).data('categoryId')
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
        if (typeof imageId === 'undefined') {
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