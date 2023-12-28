




class Color {
    constructor(public r : number, public g : number, public b : number, public a = 1) {}
    toString() {
        return `rgb(${this.r},${this.g},${this.b})`;
    }
    public static readonly White = new Color(255, 255, 255);
}
namespace Draw {
    /**Clears the grid */
    export function Clear(grid : Grid) {
        Draw.Fill(grid, Color.White);
    }
    export function Fill(grid : Grid, color : Color) {
        grid.forEach(e => {
            e.style.backgroundColor = color.toString();
        })
    }
    export function FillArea(grid : Grid, color : Color, r1 : number, c1 : number, r2 : number, c2 : number) : void {
        grid.forEach(e => {
            if(e.row >= r1 && e.row < r2 && e.col >= c1 && e.col < c2) {
                e.style.backgroundColor = color.toString();
            } 
        })
    }
    export function ColorCell(grid : Grid, color : Color, row : number, col : number) {
        const Cell = grid.GetCell(row, col);
        Cell.style.backgroundColor = Color.toString();
        Cell.Color = color;
    }



}


class Vector2 {
    length? : number;
    constructor(public x : number, public y : number, HasLength = true) {
        if(HasLength) this.length = Math.sqrt(x**2 + y**2)
    }
    static FromPolar(Angle : number, Length : number) : Vector2 {
        return new Vector2(Length * Math.cos(Angle), Length * Math.sin(Angle));
    }
    
}
class Vector3 {
    length : number
    constructor(public x : number, public y : number, public z : number, HasLength = true) {
        if(HasLength) this.length = Math.sqrt(x**2 + y**2 + z**2)
    }
}

class Rect {
    constructor(public x : number, public y : number, public width : number, public height : number) {}
}
interface CellElement extends HTMLDivElement {
    row? : number
    col? : number
    data? : object
    Color? : Color;
}
type keybind = () => void




class Grid {
    public static readonly Grids = [];
    public readonly rows : number
    public readonly cols : number
    public readonly rect : Rect;
    public readonly CellWidth : number;
    public readonly CellHeight : number;
    //The position of the mouse in Local Coords
    public MouseX : number = 0;
    public MouseY : number = 0;

    public IsMouseDown : boolean = false;
    private KeyBinds : Record<string,keybind>;



    private Cells :Array<Array<CellElement>>;

    constructor(cols : number, rows : number, width : number, height : number);
    
    constructor(cols : number, rows : number, w, h) {
        this.rows = rows;
        this.cols = cols;   
        this.CellHeight = w / rows;
        this.CellWidth = h / cols;
        let elem : HTMLDivElement= document.createElement("div");
        elem.style.display = "grid";
        elem.style.gridTemplateColumns = `repeat(${cols},${w / cols}px)`
        elem.style.gridTemplateRows = `repeat(${rows},${h / rows}px)`

        this.Cells = new Array(rows);
        for(let r = 0; r < rows; r++) {
            this.Cells[r] = new Array(cols);
            for(let c = 0; c < cols; c++) {
                this.Cells[r][c] = document.createElement("div");
                this.Cells[r][c].classList.add("Grid_Cell");
                this.Cells[r][c].row = r;
                this.Cells[r][c].col = c;
                this.Cells[r][c].Color = Color.White;
                elem.append(this.Cells[r][c])
            }
        }
        document.body.append(elem);
        this.rect= new Rect(elem.clientLeft, elem.clientTop, w, h);
        
    }
    //Iterates through the grid
    forEach(func : (e : CellElement, r?, c?) => void){
        let r = 0; 
        let c = 0; 
        while(r < this.rows) {
            func(this.Cells[r][c], r, c);
            if(c < this.cols-1) c++;
            else {c = 0; r++;}
        }
        return true;
    }
    MouseDown(func? : (ev : MouseEvent, insc : CellElement) => void) {
        document.addEventListener("mousedown", ev => {
            if(!func) {
                this.IsMouseDown = true;
                return;
            }
            //executes the function given 
            func(ev, this.GetCellAtGlobalPos(ev.clientX, ev.clientY))
            this.IsMouseDown = true;
        })
        document.addEventListener("mouseup", ev => this.IsMouseDown = false);
    }
    MouseMove(func : (ev : MouseEvent, insc : CellElement) => void) {
        document.addEventListener("mousemove", ev => {
            const temp = this.GetCellAtGlobalPos(ev.clientX, ev.clientY) 
            if(!temp) return;
            func(ev, temp);
        })
    }


    GetCellAtGlobalPos(x : number, y : number) {
        this.MouseX = Math.floor((y - this.rect.y) / this.CellHeight)
        this.MouseY = Math.floor((x - this.rect.x) / this.CellWidth)
        return this.Cells[this.MouseX][this.MouseY];
    }
    KeyBind(key : string, func : (...Args : any[]) => void) {

    }
    Save(Name : string) {
        
        let img = document.createElement('canvas')
        img.width = this.cols;
        img.height = this.rows;
        document.body.appendChild(img);
        let ctx = img.getContext("2d"); 
        this.forEach((e,r,c) => {
            ctx.fillStyle = e.Color.toString();
            ctx.fillRect(c, r, 1, 1);
        })
        window.open(img.toDataURL())
    }
    GetCell(row : number, col : number) {
        return this.Cells[row][col];
    }
    ColorCell(row : number, col : number, color : Color) {
        this.Cells[row][col].style.backgroundColor = color.toString();
        this.Cells[row][col].Color = color;
    }


}
const A = new Grid(256, 256, 1000, 1000);




