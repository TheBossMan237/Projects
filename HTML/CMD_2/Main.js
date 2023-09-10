class Folder {
    constructor(name, parent) {
        this.name = name;
        this.parent = parent;
    }
    /**Creates a Folder while assigning the parent of the Folder being created to this instance @param {String} name the name of the folder being created **cannot contain forward-slash or null character***/
    CreateFolder(name) {this[name] = new Folder(name, this)}
    /**Creates a File while assigning the parent of the File being created to this instance @param {String} name the name of the File being create <br />**cannot contain a forward-slash or null character***/
    CreateFile(name) {this[name = new File(name, this)]}
}

class File {
    constructor(name, parent) {
        this.parent = parent
        this.name = name
        this.mata = {}
    }
}
let fs = new Folder("C:")
let cwd = fs




/**@param {String} Path the string that will be parsed @param {Function} func the function with one argument which is the current piece of the path in the parser*/
function Parse(Path, func) {
    Path += "/"
    let List = []
    let cur = ""
    for(let i = 0; i <= Path.length; i++) {
        if(Path.charAt(i) == "/" && cur.length > 0) {
            List.push(func(cur) || cur)
        } else {cur += Path.charAt(i)}
    }
    return List
}

/** changes the working directory @param {String} path `cwd` will be changed to the path specified if the path is valid @return {String}*/
function CD(path) {
    let i = 0;
    /**@type {String} - a section of the path */let cur_path = ""
    /**@type {Folder|File} - The node of the `fs` tree*/let cur_node = cwd
    path += "/"
    while(i < path.length) {
        if(path.charAt(i) == "/" && cur.length > 0) {
            cur_node = cur_node[cur_path] 
            //if the folder does not exist
            if(cur_node == undefined) return "The system cannot find the path specified"
            //if the current node is instance of File instead of a Folder
            if(cur_node.meta != undefined) return "The directory name is invalid"
            cur_path = ""
        }
    }
    return ""
}

}



/**Creates a new Line*/
function CreateLine() {
    let Line = document.createElement("div"); 
    Line.classList.add("Line");

    let Dir = document.createElement("span"); 
    Dir.classList.add("Dir"); 
    Dir.innerText = "C:/" + ">"
    Line.append(Dir)

    let Content = document.createElement("textarea"); 
    Content.classList.add("Content"); 
    Content.id = "Active";
    Line.append(Content)
    
    document.body.append(Line);
    Content.focus()
    return Content
}
let CurLine = CreateLine();
/**When the user presses enter, this function. . .
 * 1. Removes the id from `CurLine` and any events
 * 2. Creates a new line and assings it to `CurLine`
*/
function Enter() {
    console.log(CurLine.value);
    CurLine.id = undefined
    CurLine = CreateLine();
}
document.addEventListener("keydown", ev => {
    CurLine.style.height = ""; 
    CurLine.style.height = CurLine.scrollHeight + "px"
    switch (ev.key) {
        case "Enter": ev.preventDefault(); Enter(); break;
    }

})
document.addEventListener("mousedown", ev => {
    if(typeof ev.cancelable !== "boolean" || ev.cancelable) {
        ev.preventDefault()
    }
})

