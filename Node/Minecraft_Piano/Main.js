const websocket = require("ws");
const wss = new websocket.Server({port : 8080});
let Computers = new Map(); /**CC:Tweaked Connections */
function print(msg) {
    console.log(msg)
}
wss.on("connection", (ws, msg) => {
    /** recive the message */
    ws.on("message", (data) => {
        if(ws.protocol == "") {
            Computers.set(data.toString(), ws)
            ws.send("Done")
        } else {
            try {
                Computers.get(data.toString()).send("Start")
            } catch (error) {
                
            }
        }

    })

    
});
