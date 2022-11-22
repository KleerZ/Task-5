let randomBtn = document.getElementById("rand-btn")
let errorInput = document.getElementById("error-input")
let errorRange = document.getElementById("error-range")
let seedInput = document.getElementById("seed")
let selectCountry = document.getElementById("select-country")
let seed = 0
let counter = 1
let loadCounter = 1
let tableBody = document.getElementById("tbody")
let tableContainer = document.getElementById("tableContainer")

tableContainer.addEventListener("scroll", async function () {
    await checkPosition()
})

async function sendData(elementsOnPage, errorCount){
    seed += 10
    let country = selectCountry.options[selectCountry.selectedIndex].value
    let route = `People/Index?country=${country}&elementsOnPage=${elementsOnPage}&errorCount=${errorCount}`

    return await fetch(route, {
        method: "POST",
        body: JSON.stringify(seed + 10),
        headers: {
            "Content-Type": "application/json"
        }
    })
}

function setDataToTable(response){
    let tr = document.createElement("tr")
    let responseJson = response.json()

    responseJson.then(data => {
        data.forEach((item) => {
            let html = `<tr>
                <td>${counter++}</td>
                <td>${random(999999, 1000000000000)}</td>
                <td>${item.fullName.substring(0, 40)}</td>
                <td>${item.address.substring(0, 40)}</td>
                <td>${item.phone.substring(0, 30)}</td>
            </tr>`

            generateHtmlTableCells(html, tableBody)
        })

        tableBody.appendChild(tr)
    })
}

function generateHtmlTableCells(html, parent){
    let tr = document.createElement('tr')
    tr.innerHTML = html.trim()
    return parent.appendChild(tr)
}

async function checkPosition() {
    const height = tableBody.offsetHeight
    const screenHeight = tableContainer.offsetHeight
    const scrolled = tableContainer.scrollTop
    const threshold = height - screenHeight / 3
    const position = scrolled + screenHeight

    if (position >= threshold && loadCounter !== counter) {
        loadCounter = counter;

        let response = await sendData(10, 0);
        setDataToTable(response);

        loadCounter = counter;
        seedInput.value = seed;
    }
}