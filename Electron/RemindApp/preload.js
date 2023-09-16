const {contextBridge, ipcRenderer} = require("electron")
contextBridge.exposeInMainWorld("api", {
    Get_Reminders:(data)=>ipcRenderer.invoke("Get_Reminders", data),
    New_Reminder:(data)=>ipcRenderer.invoke("New_Reminder", data),
    Delete_Reminder:()=>ipcRenderer.invoke("Delete_Reminder"),
    Update_Reminder:(data)=>ipcRenderer.invoke("Update_Reminder", data)
})