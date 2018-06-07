function searchByParams() {
    console.log($("#countries"));
    let countryId = $("#countries").options[$("#countries").selectedIndex].value;
    console.log(countryId);
}