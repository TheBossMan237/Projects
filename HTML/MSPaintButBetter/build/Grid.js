var Color = /** @class */ (function () {
    function Color(r, g, b, a) {
        if (a === void 0) { a = 1; }
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }
    Color.prototype.toString = function () {
        return "rgb(".concat(this.r, ",").concat(this.g, ",").concat(this.b, ")");
    };
    Color.White = new Color(255, 255, 255);
    return Color;
}());
var Draw;
(function (Draw) {
    /**Clears the grid */
    function Clear(grid) {
        Draw.Fill(grid, Color.White);
    }
    Draw.Clear = Clear;
    function Fill(grid, color) {
        grid.forEach(function (e) {
            e.style.backgroundColor = color.toString();
        });
    }
    Draw.Fill = Fill;
    function FillArea(grid, color, r1, c1, r2, c2) {
        grid.forEach(function (e) {
            if (e.row >= r1 && e.row < r2 && e.col >= c1 && e.col < c2) {
                e.style.backgroundColor = color.toString();
            }
        });
    }
    Draw.FillArea = FillArea;
    function ColorCell(grid, color, row, col) {
        var Cell = grid.GetCell(row, col);
        Cell.style.backgroundColor = Color.toString();
        Cell.Color = color;
    }
    Draw.ColorCell = ColorCell;
})(Draw || (Draw = {}));
var Vector2 = /** @class */ (function () {
    function Vector2(x, y, HasLength) {
        if (HasLength === void 0) { HasLength = true; }
        this.x = x;
        this.y = y;
        if (HasLength)
            this.length = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
    }
    Vector2.FromPolar = function (Angle, Length) {
        return new Vector2(Length * Math.cos(Angle), Length * Math.sin(Angle));
    };
    return Vector2;
}());
var Vector3 = /** @class */ (function () {
    function Vector3(x, y, z, HasLength) {
        if (HasLength === void 0) { HasLength = true; }
        this.x = x;
        this.y = y;
        this.z = z;
        if (HasLength)
            this.length = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2) + Math.pow(z, 2));
    }
    return Vector3;
}());
var Rect = /** @class */ (function () {
    function Rect(x, y, width, height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    return Rect;
}());
var Grid = /** @class */ (function () {
    function Grid(cols, rows, w, h) {
        //The position of the mouse in Local Coords
        this.MouseX = 0;
        this.MouseY = 0;
        this.IsMouseDown = false;
        this.rows = rows;
        this.cols = cols;
        this.CellHeight = w / rows;
        this.CellWidth = h / cols;
        var elem = document.createElement("div");
        elem.style.display = "grid";
        elem.style.gridTemplateColumns = "repeat(".concat(cols, ",").concat(w / cols, "px)");
        elem.style.gridTemplateRows = "repeat(".concat(rows, ",").concat(h / rows, "px)");
        this.Cells = new Array(rows);
        for (var r = 0; r < rows; r++) {
            this.Cells[r] = new Array(cols);
            for (var c = 0; c < cols; c++) {
                this.Cells[r][c] = document.createElement("div");
                this.Cells[r][c].classList.add("Grid_Cell");
                this.Cells[r][c].row = r;
                this.Cells[r][c].col = c;
                this.Cells[r][c].Color = Color.White;
                elem.append(this.Cells[r][c]);
            }
        }
        document.body.append(elem);
        this.rect = new Rect(elem.clientLeft, elem.clientTop, w, h);
    }
    //Iterates through the grid
    Grid.prototype.forEach = function (func) {
        var r = 0;
        var c = 0;
        while (r < this.rows) {
            func(this.Cells[r][c], r, c);
            if (c < this.cols - 1)
                c++;
            else {
                c = 0;
                r++;
            }
        }
        return true;
    };
    Grid.prototype.MouseDown = function (func) {
        var _this = this;
        document.addEventListener("mousedown", function (ev) {
            if (!func) {
                _this.IsMouseDown = true;
                return;
            }
            //executes the function given 
            func(ev, _this.GetCellAtGlobalPos(ev.clientX, ev.clientY));
            _this.IsMouseDown = true;
        });
        document.addEventListener("mouseup", function (ev) { return _this.IsMouseDown = false; });
    };
    Grid.prototype.MouseMove = function (func) {
        var _this = this;
        document.addEventListener("mousemove", function (ev) {
            var temp = _this.GetCellAtGlobalPos(ev.clientX, ev.clientY);
            if (!temp)
                return;
            func(ev, temp);
        });
    };
    Grid.prototype.GetCellAtGlobalPos = function (x, y) {
        this.MouseX = Math.floor((y - this.rect.y) / this.CellHeight);
        this.MouseY = Math.floor((x - this.rect.x) / this.CellWidth);
        return this.Cells[this.MouseX][this.MouseY];
    };
    Grid.prototype.KeyBind = function (key, func) {
    };
    Grid.prototype.Save = function (Name) {
        var img = document.createElement('canvas');
        img.width = this.cols;
        img.height = this.rows;
        document.body.appendChild(img);
        var ctx = img.getContext("2d");
        this.forEach(function (e, r, c) {
            ctx.fillStyle = e.Color.toString();
            ctx.fillRect(c, r, 1, 1);
        });
        window.open(img.toDataURL());
    };
    Grid.prototype.GetCell = function (row, col) {
        return this.Cells[row][col];
    };
    Grid.prototype.ColorCell = function (row, col, color) {
        this.Cells[row][col].style.backgroundColor = color.toString();
        this.Cells[row][col].Color = color;
    };
    Grid.Grids = [];
    return Grid;
}());
var A = new Grid(256, 256, 1000, 1000);
