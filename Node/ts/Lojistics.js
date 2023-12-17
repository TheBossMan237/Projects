/** */
namespace resource {
    export class Resource {
        public readonly Name : string;
        public readonly ID : number;
        private static ResAmounts = 0;

        private constructor(Name : string) {
            this.Name = Name;
            this.ID = Resource.ResAmounts;
            Resource.ResAmounts++;
        }
        static NewResource(Name : string) {
            if(Resources[Name]) throw new Error("Resource " + Name + " already exsists");
            Resources[Name] = new Resource(Name);
        }
        static FromList(...Names : string[]) {
            for(let i = 0; i < Names.length; i++) {
                if(Resources[Names[i]]) throw new Error("Resource " + Names[i] + " already exsists");
                Resources[Names[i]] = new Resource(Names[i]);
            }
        }
        
    }
    let ResCount : number = 0;
    export function AddRecipe() {}

    export interface IResource {
        ID : number,
        Name : string;
    }



    export let Resources : Record<string, Resource> = {};
    

}
namespace recipe {
    export interface IRecipe {
        Ingredients : resource.IResource[];
        IngredientAmount : number[];
        Results : resource.IResource[];
        ResultAmounts : number[];

        ProccessingTime : number;
        TotalEnergyRequired : number;

    }
    interface IRecipeConfig {
        /**Total amount of time to complete this recipe IN MILISECONDS, defaults to 1000 */ Time : number,
        /**Amount of energy consumed over the total time, defualts to 0*/Energy : number
    }
    export class Recipe {
        //All Values will initialy be just 1 value, after adding more then 2, it becomes an array;
        private Ingredients : resource.IResource[] = []
        private IngredientAmounts : number[] = [];
        private Results : Array<resource.IResource> = [];
        private ResultAmounts : number[] = [];
        private ProccessingTime : number = 1000;
        private TotalEnergyRequired : number = 0;
        constructor(){}
        AddIngredient(Resource : resource.IResource, Amount : number) : Recipe {    
            if(Amount >> 0 != Amount || Amount < 0) throw new Error("Amounts must be a Postive Integer");
            this.Ingredients.push(Resource);
            this.IngredientAmounts.push(Amount);
            return this;
        }
        AddResult(Resource : resource.IResource, Amount : number): Recipe {
            if(Amount >> 0 != Amount || Amount < 0) throw new Error("Amounts must be a Positive Integer");
            this.Results.push(Resource);
            this.ResultAmounts.push(Amount);
            return this;
        }

        RegisterTo(Machine : machine.IMachine) : Recipe{
            Machine.Recipes.push(this);
            return this;
        }
        Config(options : Partial<IRecipeConfig>) : Recipe {
            this.TotalEnergyRequired = options.Energy ? options.Energy : 0
            this.ProccessingTime = options.Time ? options.Time : 1000;
            return this;
        }
        Calc(NumberToMake) {
            let Out = {Time : this.ProccessingTime * NumberToMake, Energy : this.TotalEnergyRequired * NumberToMake};
            
            this.Ingredients.forEach((e, i) => {
                console.log(e)
                Out[e.Name] = NumberToMake * this.IngredientAmounts[i];
            })
            return Out

        }
    }
}
resource.Resource.FromList("Copper", "Nickel", "Cupronickel")

resource.Resource.FromList("Polonium", "Antimatter");
const R_Cupronickel_Wire = new recipe.Recipe()
.AddIngredient(resource.Resources.Copper, 1)
.AddIngredient(resource.Resources.Nickel, 1)
.AddResult(resource.Resources.Cupronickel, 2)
.Config({})


console.log(resource.Resources.Nickel)



console.log(new recipe.Recipe()
.AddIngredient(resource.Resources.Polonium, 1000)
.Config({Energy : 200000000, Time : 1})
.Calc(1000)

)
