const foodSelect = document.getElementById("food");
const foodname = document.getElementById("foodname");
const foodid = document.getElementById("foodid");
const submit = document.getElementById("submitbut");
const selectedFood = foodSelect.value;
submit.addEventListener('click', function () {

    if (selectedFood === 'Leaves') {

        foodname.value = 'Leaves';
        foodid.value = 1;
    }
    else if (selectedFood === "Flowers") {
        foodname.value = 'Flowers';
        foodid.value = 2;
    }
    else if (selectedFood === "Grass") {
        foodname.value = 'Grass';
        foodid.value = 3;
    }
    else if (selectedFood === "Mammals") {
        foodname.value = 'Mammals';
        foodid.value = 4;
    }
    else if (selectedFood === "Fish") {
        foodname.value = 'Fish';
        foodid.value =5;
    }
    else if (selectedFood === "Mushrooms") {
        foodname.value = 'Mushrooms';
        foodid.value = 6;
    }
    else if (selectedFood === "Birds") {
        foodname.value = 'Birds';
        foodid.value = 7;
    }
    else if (selectedFood === "Everything") {
        foodname.value = 'Everything';
        foodid.value = 8;
    }
});