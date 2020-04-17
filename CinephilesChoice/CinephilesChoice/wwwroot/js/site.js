function displayAwardCategories(idOfYearToDisplay) {
    let element = document.getElementById(idOfYearToDisplay);
    if (element.style.display != "block") {
        element.style.display = "block";
    }
    else {
        element.style.display = "none";
    }
}
