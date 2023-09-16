const { log } = require("console");
const {app, BrowserWindow, Menu, MenuItem, webContents} = require("electron")
const ipc = require("electron").ipcMain
const fs = require("fs");
const path = require("path")


const filepath = "./Reminders.csv"
if (!fs.existsSync(filepath)) fs.appendFileSync(filepath, "Name,Date,Time,Desc\n") 

const createWindow = () => {
    
    const win = new BrowserWindow(
        {   width:500, 
            height:800,
            resizable:false,
            webPreferences:{
                preload: path.join(__dirname + "/preload.js")
            }
        }
    )
    ipc.handle("Get_Reminders", (req, data) => {
        const file = fs.readFileSync(filepath, {encoding:"ascii"})
        let seg = ""
        let out = []
        let count = 0;
        for(let i = 0; i < file.length; i++) {
            if(file[i] == "\n" || file[i] == ",") {
                if(count > 0) out.push(seg);
                seg = ""; if(file[i] == "\n") count++;
            } else {seg += file[i]}
        }
        return out
    })
    ipc.handle("New_Reminder", (req, data) => {
        fs.appendFileSync(filepath, `${data.Name},${data.Time}\n`)
        let file = fs.readFileSync(filepath, "ascii");

    });
    ipc.handle("Update_Reminder", (req, data) => {
        let file = fs.readFileSync(filepath, "ascii");
        let count =0
        let out = ""
        console.log(data);
        for(let i = 0; i < file.length; i++) {
            if(file[i] == "\n") {
                if(count == data.Index) {
                    out += `${data.Name},${data.Time}\n`
                }
                count++;
            } else {
                if(count != data.Index) out += file[i];
            }
        }
        fs.writeFileSync(filepath, out);

        
        
    })
    ipc.handle("Delete_Reminder", (req, data) => {

    })
    win.loadFile("src/CreateReminder.html")
    win.webContents.openDevTools();
} 
const m = new Menu()
m.append(new MenuItem(
    {
        label:"Settings",
        submenu:[
            new MenuItem({
                label:"DarkTheme?"
            }),
        ]
    }
))
//DEBUG
m.append(new MenuItem(
    {
        label:"Debug",
        submenu:[
            new MenuItem({
                label:"Reload",
                click:()=>{BrowserWindow.getAllWindows()[0].loadFile("src/CreateReminder.html")}
            }),
            new MenuItem({
                label:"Open F12",
                click:()=>{BrowserWindow.getAllWindows()[0].openDevTools()}
            })
        ]
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