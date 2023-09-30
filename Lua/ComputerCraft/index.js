const { log } = require("console")
const {WebSocketServer, WebSocket} = require("ws")
let ws = new WebSocketServer({port:8080})
let connection = undefined
let per = {
    
}
/**
 * 
 * @param {MessageEvent} ev 
 */
function After_Init_Msg(ev) {
    let object = JSON.parse(ev.data)
    log(object) 
}
ws.on("connection", (wss, req) => {
    if(!connection) {
        connection = wss
        connection.onmessage = function(ev)  {
            log(ev)
            let d = ev.data
            log(ev.data)
            if(d == "Done") {
                log(1)
                connection.onmessage = After_Init_Msg
                return 
                
            }
            let vals = d.split(" ") // [Per_Name, Coords]
            per[vals[0]] = {Coords : vals[1]}

        }
        connection.onclose = (ev) => connection = undefined
    }
})
