const TimeElement = document.getElementById("RemindTime")
const TextElement = document.getElementById("RemindText")
const Sub = document.getElementById("Submit")
Sub.addEventListener("click", async (ev) => {
    const Time = TimeElement.value;
    const _text = TextElement.value;
    const res = await api.create({
        Time,
        _text
    }) 
    TimeElement.value = ""
    TextElement.value = ""

})