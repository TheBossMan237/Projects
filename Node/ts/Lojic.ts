import { log } from "console"

type GateType = "xor" | "and" | "not" | "Input";
type GateFunction = (...args : number[]) => number[] | number
interface I_Templates {
    [key : string] : {
        func : GateFunction,
        Inputs : number,
        Outputs : number
    }
}
class Gate {
    private static Templates : I_Templates = {
        "xor" : {
            func : (a, b) => a ^ b,
            Inputs : 2,
            Outputs : 1
        },
        "and" : {
            func : (a, b) => a & b,
            Inputs : 2,
            Outputs : 1
        },
        "Input" : {
            func : a => a,
            Inputs : 1,
            Outputs : 1
        },
        "not" : {
            func : a => ~a,
            Inputs : 1,
            Outputs : 1
        },
    }
    func : GateFunction;
    Inputs : Gate[][];
    /*Only use if this gate has an Input type**/ Value : number;
    constructor(public readonly type : GateType | string) {
        if(!Gate.Templates[type]) throw new Error(type + " is not a valid gate type")
        this.func = Gate.Templates[type].func;
        this.Value = 0;
        this.Inputs = []
        for(let i = 0; i < Gate.Templates[type].Inputs; i++) this.Inputs.push([])
    }

    Eval() {
        let a =this.Inputs.map(e => {
            for(let i = 0; i < e.length; i++) {
                if(e[i].Value == 1 || e[i].Eval() == 1) {
                    return 1;
                }
            }
            return 0;
        });
        return this.func(...a)
    }
    /**Connects the gate's given output to this gates input*/
    Connect(/**Alternate types between Gate and Number in that order */...args : Array<any>) {
        if(args.length & 1) throw new Error("Must be an even amount of arguments") 
        for(let i = 0; i < args.length / 2; i++) {
            let index = args[i * 2 + 1]
            let value = args[i * 2];
            this.Inputs[index].push(value)
            
        }
    }
    static CreateTemplate(name : string, func : GateFunction) {
        
        let Length = func(...new Array(func.length).fill(1))
        Length = typeof(Length) == "number" ? 1 : Length.length 
        if(Gate.Templates[name]) throw new Error("Gate already exists")
        Gate.Templates[name] = {func, Outputs : Length, Inputs : func.length};

    }
    static TemplateInfo(name : string) {
        if(!Gate.Templates[name]) return "Gate does not exist";
        return `Inputs: ${Gate.Templates[name].Inputs}\nOutputs: ${Gate.Templates[name].Outputs}`
    }


}
let Inputs : Gate[] = []
function Init(NInputs : number, NOutputs : number) {
    Inputs = new Array(NInputs);
    for(let i = 0;i < Math.max(NInputs, NOutputs); i++) {
        if(i < NInputs) Inputs[i] = new Gate("Input");
    }
}


Init(2, 2);
Gate.CreateTemplate("half adder", (a, b) => [a ^ b, a & b])
let a = new Gate("half adder")
a.Connect(Inputs[0],0, Inputs[1], 1);
log(a.Eval())







