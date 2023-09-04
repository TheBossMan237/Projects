/** @typedef {Object} GameObjectConstructor @property {string} [Name] The Name of the GameObject @property {GameArea} Parent **Required**  the GameObjects parent */
class GameArea {
    static CanvasCount = 1;
    /** 
     * @param {Object} Args The Arguments For The Canvas @param {Number} [Args.Width] Defualt: `500` @param {Number} [Args.Height] Defualt: `500` @param {string} [Args.Top]  offset relative to parent in px  Defualt:`"0px"` @param {string} [Args.Left] Left offset relative to parent in px  Defualt:`"0px"` @param {HTMLElement} [Args.Parent] the parent of the canvas  
     * Defualt: `docuemnt.body` @param {string} [Args.ID] The id of the Element  
     * Defualt:`"Can_" + GameArea.CanvasCount` @param {Number} [Args.timeout] The amount of time in ms it takes to reload the frame  
     * Defualt : `10`
    */
    constructor(Args) {
        let elem = document.createElement("canvas");
        
        elem.id = Args.ID || "Can_" + GameArea.CanvasCount
        elem.classList.add("GameArea")

        elem.style.left = Args.Left || "0px"
        elem.style.top = Args.Top || "0px"
        elem.width = Args.Width || 500;
        elem.height = Args.Height || 500;

        (document.body || Args.Parent).append(elem)
        GameArea.CanvasCount++;

        this.elem = elem;
        this.ctx = elem.getContext("2d")
        this.GameObjects = []
        this.Stack = []
        this.dim = elem.getBoundingClientRect()
        setInterval(() => this.Stack.forEach(e => e()), Args.timeout || 10)
    }
    /** @template {string} [T1="mousedown"|"mouseup"|"keydown"|"keyup"|"keypress"|"click"|"scroll"]  @param {T1} ev calls `func()` when the specified event is called   @param {Function} func */ addEventListener(ev, func) {this.elem.addEventListener(ev, func);}
    /**@param {string} object*/ AddGameObject(object) {this.GameObjects.push(object); } 
     DrawRect(type, Args) {
        this.Stack.push(() => {
            this.ctx.strokeStyle = this.ctx.Color || "black"; 
            this.ctx.strokeRect(Args.x, Args.y, Args.width, Args.height)
            this.ctx.strokeStyle = "black";
        })
     }
     Clear() {this.Stack.push(() => this.ctx.clearRect(0, 0, this.dim.width, this.dim.height))}


     
     
}
class GameObject {
    constructor(/**@type {GameObjectConstructor} */ Args) {
        Args.Parent.AddGameObject(this)
    }

    /**@type {string} @type {*} */AddVariable(Name, Value) {this[Name] = Value}
    /**@param {Array[]} Vars*/ AddVariables(Vars) {Vars.forEach(e => {this[e[0]] = e[1]})}
}
let Game = new GameArea({
    Height:500,
    Width:500,
})
let Player = new GameObject({
    Parent:Game, 
})
Player.AddVariables([["X", 0], ["Y", 0]])

Game.addEventListener("mousedown", function(/**@type {MouseEvent} */ ev) {
    Game.DrawRect({width:10, height:10, x:ev.clientX, y:ev.clientY})
})
