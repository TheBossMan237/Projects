const fs = require("fs");
const {log} = require("console");
const { FORMERR } = require("dns");
let data = fs.readFileSync("Data.csv", "utf-8")
const {ap} = require("open")
//Score on column side is {lineNumber - 2}


let out = ""
let isFirstLine = true;
let Col = 0
let Row = 0;
let teams = [];
let temp = ""

for(const x of data) {
    switch(x) {
        case "\n":
            if(isFirstLine) {isFirstLine = false; break;}
            teams = [];
            Row++;
            teams = []
            Col=0;
            break;
        case ",":
            if(teams.length > 0)log(teams, Row, Col)
            teams.forEach(e => out += e)
            Col++;
            teams = []
            temp = "";
            break;
        case "/":
            teams.push(temp + "," + Row + "," + Col + "\n")
            temp = "";
            break;
        default:
            temp+=x;
            break;
    }


}
fs.writeFileSync("Output.csv", out);
