const safety = document.getElementById("Safety");
const hostElement = document.getElementById("only-deadly");
const symptomElement = document.getElementById("only-deadly1");

// Attach the event listener to the "Safety" dropdown
safety.addEventListener('change', function () {
    // Check if the selected value is "Deadly"
    if (safety.value === 'Deadly') {
        // Show the input fields
        hostElement.style.display = 'block';
        symptomElement.style.display = 'block';
    } else {
        // Hide the input fields
        hostElement.style.display = 'none';
        symptomElement.style.display = 'none';
    }
});
