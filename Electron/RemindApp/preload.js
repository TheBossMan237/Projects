const {contextBridge, ipcRenderer} = require("electron")
contextBridge.exposeInMainWorld("api", {
    title:"The Remind App",
    create:(data) => ipcRenderer.invoke('create-file', data)
})