function displayAwardCategories(idOfYearToDisplay) {
    let element = document.getElementById(idOfYearToDisplay);
    if (element.display != "block") {
        element.display = "block";
    }
    else {
        element.display = "none";
    }
}
