let randomBtn = document.getElementById("rand-btn")
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

async function sendData(elementsOnPage){
    seed += 20
    let country = selectCountry.options[selectCountry.selectedIndex].value

    return await fetch(`People/Index?country=${country}&elementsOnPage=${elementsOnPage}`, {
        method: "POST",
        body: JSON.stringify(seed + 20),
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
            console.log(item)
            let html = `<tr>
                <td>${counter++}</td>
                <td>${random(999999, 1000000000000)}</td>
                <td>${item.fullName}</td>
                <td>${item.address}</td>
                <td>${item.phone}</td>
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

        let response = await sendData(10);
        setDataToTable(response);

        loadCounter = counter;
        console.log(seed)
    }
}