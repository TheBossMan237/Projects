const {contextBridge, ipcRenderer} = require("electron")
contextBridge.exposeInMainWorld("Reminders", {
    Get:()=>ipcRenderer.invoke("Get_Reminders"),
    Create:(data)=>ipcRenderer.invoke("Create_Reminder", data),
    Remove:(data) => ipcRenderer.invoke("Delete_Reminder", data),
    Modify:(data) => ipcRenderer.invoke("Modify_Reminder", data)

})