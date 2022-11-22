errorRange.addEventListener('input', async () => { 
    errorInput.value = errorRange.value
    
    seed = Number(seedInput.value);
    let response = await sendData(20, errorRange.value);
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    setDataToTable(response);
})

errorInput.addEventListener("change", async function () {
   if (errorInput.value > 1000)
       errorInput.value = 1000
    
    if (errorInput.value <= 10)
        errorRange.value = errorInput.value
    else errorRange.value = 10
    
    seed = Number(seedInput.value)
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1

    let response = await sendData(20, errorInput.value);
    setDataToTable(response);
})

function random(min, max){
    return Math.floor(Math.random() * (max - min))
}