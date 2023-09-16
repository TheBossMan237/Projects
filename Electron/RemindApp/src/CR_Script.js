let Add = document.getElementById("AddNew")
let Amount = 0;
let Init = async () => {
    let t = await api.Get_Reminders();
    for(let i = 1; i < t.length; i+=2) {
        console.log(t);




        let TimeElem = document.createElement("input"); TimeElem.type = "datetime-local"; TimeElem.value = t[i]

        document.body.insertBefore(TimeElem, Add)

        let NameElem = document.createElement("input"); NameElem.type = "text"; NameElem.value = t[i-1]
        document.body.insertBefore(NameElem, Add)
        NameElem.addEventListener("blur", () => {
            api.Update_Reminder({
                Time:TimeElem.value,
                Name:NameElem.value,
                Index:Remove.index
            })
        })
        let Remove = document.createElement("button"); Remove.innerText = "x"
        document.body.insertBefore(Remove, TimeElem)
        Remove.addEventListener("click", () => {
            Remove.remove(); NameElem.remove(); TimeElem.remove();
        })
        Remove.index = Math.floor((i - 1) / 2)
        console.log()

    }




}
Init()



/**@param {MouseEvent|KeyboardEvent} ev */
async function EventHandler(ev) {
    let TimeElem = document.createElement("input"); TimeElem.type = "datetime-local"; 
    let NameElem = document.createElement("input"); NameElem.type = "text"; 
    let Remove = document.createElement("button"); Remove.innerText='x'; 
    Remove.addEventListener("mousedown", (ev_2) => {
        TimeElem.remove(); NameElem.remove(); Remove.remove(); Amount--;
    });
    Remove.index = Amount;

    
    [Remove, TimeElem, NameElem].forEach(e => {
        document.body.insertBefore(e, Add);
        if(e != Remove) e.addEventListener("blur", async (ev_2) => {

            api.Update_Reminder({
                Time:TimeElem.value,
                Name:NameElem.value,
                Index:Remove.index + 1
            })
        })

    })
    Amount++;

    await api.New_Reminder({
        Time:'',
        Name:'',
    })
}

Add.addEventListener("mousedown", EventHandler)
