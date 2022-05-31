function toggleExactDate() {
    var exactDiv = document.getElementById("ExactDateDiv");
    if (exactDiv.style.display === "none") {
        exactDiv.style.display = "block";

    } else {
        exactDiv.style.display = "none";
    }
}
function toggleIntervalDate() {
    var intervalDiv = document.getElementById("IntervalDateDiv");
    if (intervalDiv.style.display === "none") {
        intervalDiv.style.display = "block";

    } else {
        intervalDiv.style.display = "none";
    }
}

function toggleDate() {
    toggleExactDate();
    toggleIntervalDate();
}

function showAccordionItem() {
    var panel = document.getElementById("accordionBody");
    if (panel.style.display === "block") {
        panel.style.display = "none";
    } else {
        panel.style.display = "block";
    }

}

