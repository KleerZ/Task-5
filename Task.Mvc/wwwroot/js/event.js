window.onload = async function(){
    let response = await sendData(20)
    setDataToTable(response)
    seed = 10
}

randomBtn.addEventListener("click", async function () {
    seedInput.value = +Number(+random(1000000, 9999999))
    let text = +seedInput.value
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    seed = +Number(+text);
    let response = await sendData(20, errorInput.value);
    setDataToTable(response);
    seed = +Number(+text)+20;
})

seedInput.addEventListener("change", async function () {
    let text = seedInput.value
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    seed = +Number(+text)
    let response = await sendData(20, errorInput.value);
   
    setDataToTable(response);
    seed = +Number(+text)+20
})

selectCountry.addEventListener("click", async function (){
    let text = seedInput.value
    tableBody.innerHTML = ''
    counter = 1
    loadCounter = 1
    seed = +Number(+text)
    
    let response = await sendData(20, errorInput.value)
    setDataToTable(response)
    seed = +Number(+text)+20
})