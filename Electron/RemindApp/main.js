const {app, BrowserWindow, Menu, MenuItem} = require("electron")
const ipc = require("electron").ipcMain
const fs = require("fs");



const path = require("path")
const createWindow = () => {
    const win = new BrowserWindow(
        {   width:500, 
            height:500,
            webPreferences:{
                preload: path.join(__dirname + "/preload.js")
            }
        }
    )
    ipc.handle('create-file', (req, data) => {
        if(!data || !data._text || !data.Time) {return false;}
        const filepath = "./main.txt"
        fs.appendFileSync(filepath, `${data.Time} : ${data._text}\n`)
        console.log(data)
        return {success: true}
    
    
    })

    win.loadFile("src/CreateReminder.html")
    win.webContents.openDevTools();
} 
const m = new Menu()
m.append(new MenuItem(
    {
        label:"Add Reminder",
        click:()=>{BrowserWindow.getAllWindows()[0].loadFile("src/CreateReminder.html")}
    }
))
m.append(new MenuItem(
    {
    label:"Remove Reminder",
    click:()=>{BrowserWindow.getAllWindows()[0].loadFile("src/RemoveReminder.html")}
    }
))
Menu.setApplicationMenu(m);


app.whenReady().then(() => {
    createWindow()
    app.on("activate", () => {
        if(BrowserWindow.getAllWindows().length === 0) createWindow()
    })
    app.on("window-all-closed", () => {
        if(process.platform !== "darwin") app.quit()
    })    
})
