const Parasitic = document.getElementById("Parasitic");
const hostElement = document.getElementById("only-deadly-f");
const symptomElement = document.getElementById("only-deadly1-f");

// Attach the event listener to the "Safety" dropdown
Parasitic.addEventListener('change', function () {
    // Check if the selected value is "Deadly"
    if (Parasitic.value === 'Parasitic') {
        // Show the input fields
        hostElement.style.display = 'block';
        symptomElement.style.display = 'block';
    } else {
        // Hide the input fields
        hostElement.style.display = 'none';
        symptomElement.style.display = 'none';
    }
});
