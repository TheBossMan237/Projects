const { log } = require("console");
const {app, BrowserWindow, ipcMain, Menu, MenuItem} = require("electron")
const path = require("path")
const sqlite = require("sqlite3")
let db = new sqlite.Database("Reminders.db", sqlite.OPEN_READWRITE);
//Create the `main` table in the `db` database
db.serialize(() => {
    db.run("CREATE TABLE IF NOT EXISTS Reminders (name TEXT PRIMARY KEY, time TEXT)")
})
/**
 * @typedef {Object} Remind_Data
 * @property {String} Name the name of the reminder also PRIMARY KEY
 * @property {String} Time the time that the reminder will push a notification to the os. 
*/


function CreateWindow() {
    let win = new BrowserWindow({
        width:1000,
        height:1000,
        webPreferences: {
            preload:__dirname + "/preload.js",
        }
    })
    win.loadFile("src/Main_1.html")

}
let menu = new Menu()

//Flutter be like
menu.append(new MenuItem({
    label:"Debug",
    submenu:[
        new MenuItem({
            label:"Reload",
            click:()=>{BrowserWindow.getAllWindows()[0].loadFile("./src/Main_1.html")}
        }),
        new MenuItem({
            label:"Open F12",
            click:()=>{BrowserWindow.getAllWindows()[0].webContents.openDevTools();}
        })
    ]
}))

Menu.setApplicationMenu(menu);

app.whenReady().then(() => {
    CreateWindow()
    app.on("activate", (ev) => {
        if(BrowserWindow.getAllWindows().length === 0) {
            CreateWindow()
        }
    })
    //Get the reminders from Reminders.db file on startup/reload
    ipcMain.handle("Get_Reminders",(req) => {
        //Returns each of the values in the table line [time1,name1,time2,name2,...]
        return new Promise((resolve, reject) => {
            var out = []
            db.each("SELECT name, time FROM Reminders", (err, data) =>{
                out = out.concat([data.time, data.name])
            },(err, count) => {
                resolve(out)
            })
        });
    })
    //Either creates a new Reminder or just updates an already exisiting one
    ipcMain.handle("Modify_Reminder", /**@param {Remind_Data} data */(req, data) => {

        if(!data.Name || !data.Time || data.Name=="" || data.Time == "") return undefined
        
        return new Promise((resolve, reject) => {
            //if there is an name attribute of the Renderer side Reminder then delete it  
            if(data.Index != undefined) {
                let cmnt = db.prepare("DELETE FROM Reminders WHERE name=?")
                cmnt.run(data.Index)
            }

            //Create a new reminder given the name and the time are not null
            let cnmt = db.prepare("INSERT INTO Reminders VALUES (?,?)")
            cnmt.run(data.Name, data.Time, (err) => {
                if(err) return undefined
                else resolve(data.Name)
            })

        });

    })
    ipcMain.handle("Delete_Reminder",(req, data) => {
            let cmnt = db.prepare("DELETE FROM Reminders WHERE name=?")
            if(data.Name == "" || !data.Name || !data.Name) return {success:false}
            cmnt.run(data.Name, (err) => {
                if(err) return {success:false}
                return {success:true}
            }); 
    })
    ipcMain.handle("Create_Reminder", (req, data) => {
        let cnmt = db.prepare("INSERT INTO Reminders VALUES (?,?)")
        cnmt.run(data.name, data.time, (err) => {
        })
    })
    ipcMain.handle("Search", /**
    *
    * @param {Object} data
    * @param {String} data.Query - the thing that we need to search for 
    */(req, data) => {
        
    })
})