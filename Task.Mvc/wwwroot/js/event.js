window.onload = async function(){
    let response = await sendData(20)
    setDataToTable(response)
}

randomBtn.addEventListener("click", async function () {
    seed = random(1000000, 9999999)
    seedInput.value = seed
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1

    let response = await sendData(20);
    setDataToTable(response);

    await sendData()
})

seedInput.addEventListener("change", async function () {
    seed = Number(seedInput.value)
    console.log(seed)
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1

    let response = await sendData(20);
    setDataToTable(response);
})

selectCountry.addEventListener("click", async function (){
    seed = Number(seedInput.value)
    console.log(seed)
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    
    let response = await sendData(20)
    setDataToTable(response)
})