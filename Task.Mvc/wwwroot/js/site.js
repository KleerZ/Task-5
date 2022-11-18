let errorRange = document.getElementById("error-range")
errorRange.addEventListener('input', () => {
    let errorInput = document.getElementById("error-input")
    errorInput.value = errorRange.value
})