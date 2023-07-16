const websocket = require("ws");
const wss = new websocket.Server({port : 8080});
/**Website */let Client = null ;
/**CC:Twekaed Connections */let Computers = new Map();
function print(msg) {
    console.log(msg)
}
wss.on("connection", (ws, msg) => {
    ws.on("message", (data) => {
        if(ws.protocol == "") {
            Computers.set(data.toString(), ws)
            ws.send("Done")
            print(Computers)
        } else {
            try {
                print(data.toString())
                Computers.get(data.toString()).send("Start")
            } catch (error) {
                
            }
        }

    })

    
});
