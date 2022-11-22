errorRange.addEventListener('input', async () => {
    errorInput.value = Number(+errorRange.value)
    if (errorRange.value === "0"){
        errorRange.value = 0
    }
})

errorRange.addEventListener('change', async () => {
    let text = +seedInput.value
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    text = +seedInput.value
    seed = +Number(+text);
    let response = await sendData(20, +errorInput.value);
    setDataToTable(response);
    seed = +Number(+text)+20;
})

errorInput.addEventListener("change", async function () {
    let text = seedInput.value
    if (errorInput.value > 1000)
        errorInput.value = 1000
    text = seedInput.value
    if (errorInput.value <= 10)
        errorRange.value = Number(+errorInput.value)
    else errorRange.value = 10
    text = seedInput.value
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    text = seedInput.value
    seed = +Number(+text)
    let response = await sendData(20, +errorInput.value);
    setDataToTable(response);
    seed = +Number(+text)+20;
})

function random(min, max) {
    return Math.floor(Math.random() * (max - min))
}

$('body').on('input', 'input[type="number"][maxlength]', function(){
    if (this.value.length > this.maxLength){
        this.value = this.value.slice(0, this.maxLength);
    }
});

$('body').on('input', '.input-number', function(){
    this.value = this.value.replace(/[^0-9]/g, '');
});