//Get the content element which contains the list of reminders 
let root = document.getElementById("Content")
//Create the container for the Reminder
let con = document.createElement("div")
con.classList.add("Reminder")
con.rowid = 0;
//Create the button that when clicked will delete the Reminder that it is apart of
let btn = document.createElement("button")
btn.innerText = "X"




//Creates the input element for the name of the remidner
//Then it adds an event listener for the elemnent which then calls `Remidners.update`
let NameInput = document.createElement("input")
NameInput.type = "text";

let TimeInput = document.createElement("input")
TimeInput.type = "datetime-local";

function CreateReminder(Name, Time) {
    let con_clone = con.cloneNode(); 
    let btn_clone = btn.cloneNode();
    
    btn_clone.addEventListener("click", (ev) => {
        let parent = ev.target.parentElement
        Reminders.Remove({Name:ev.target.parentElement.children[2].value})
        console.log(ev.target.parentElement);
        ev.target.parentElement.remove()
    })
    con_clone.append(btn_clone);
    

    let time_clone = TimeInput.cloneNode(); 
    time_clone.value = Time ? Time : ""
    time_clone.name = Name ? Name : undefined
    time_clone.addEventListener("blur", async (ev) => {
        let res = await Reminders.Modify({
            Name:ev.target.parentElement.children[2].value,
            Time:ev.target.value,
            Index:ev.target.name
        })
        if(res) ev.target.name = res;
        
    })
    con_clone.append(time_clone);
    
    let name_clone = NameInput.cloneNode(); 
    
    name_clone.value = Name ? Name : ""; //sets the value to the name in the databse if it exsits
    name_clone.name = Name ? Name : undefined //does the same thing  but for `name` attribute 
    
    name_clone.addEventListener("blur", async (ev) => {
        let res = await Reminders.Modify({
            Name:ev.target.value,
            Time:ev.target.parentElement.children[1].value,
            Index:ev.target.name
        })
        if(res) ev.target.name = res;
      })
    
    
    con_clone.append(name_clone);        
    root.insertBefore(con_clone, AddReminder);
}
let AddReminder = document.getElementById("AddElem")
//Get the reminders in the database and then add them to the DOM
let total = 0
async function Init() {
    /**@type {Array}*/
    let e = await Reminders.Get();
    console.log(e);
    for(let i = 1; i < e.length;i+=2) {
        CreateReminder(e[i], e[i-1])
    }
}
Init()
AddReminder.addEventListener("click", (ev) => {
    CreateReminder();
})
