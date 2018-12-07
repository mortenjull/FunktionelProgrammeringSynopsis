// Learn more about F# at http://fsharp.org

open System
open Types
open Data
open Logic

[<EntryPoint>]
let main argv =       
    printfn "Welcome to Campany Match Making"

    //Prints companies from data.
    PrintCompanies Companies

    printfn "Please choose a company by writing its name:"
    let input = Console.ReadLine()

    let index = FindCompanyAtIndex(input, Companies)


  

    let result = MatchMaking (Companies.Item 0, Companies, 0.5)

    PrintMatches result



    Console.ReadLine()

    0

    
        


