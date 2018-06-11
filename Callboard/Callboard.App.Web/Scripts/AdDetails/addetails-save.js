function saveAdDetails() {
    let adDetails = getAdDetails();
    console.log(adDetails);
    console.log({ adDetailsModel: JSON.stringify(adDetails) });
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
    let locationId = $("#cities").find(":selected").val();

    let categories = [];
    $("#categories").find(":selected").each(function () {
        let category = {
            CategoryId: $(this).val()
        };
        categories.push(category);
    });

    return {
        Name: name,
        Price: price,
        Description: description,
        AddressLine: addressLine,
        Kind: kind,
        State: state,
        UserId: userId,
        AdId: adId,
        LocationId: locationId,
        Categories: categories
    };
}