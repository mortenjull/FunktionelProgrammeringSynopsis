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

    // Ask the user for a company to run match against.
    let selectedCompany = AskForCompany Companies

    printfn "You have selected: %s" selectedCompany.Name
    
    //Gets the seleceted rate.
    let selectedRate = AskForRate (0.0, 1.0)

    //Gets mathes from MatchMaking
    let result = MatchMaking (selectedCompany, Companies, selectedRate)

    //Prints matches
    PrintMatches result
    
    Console.ReadLine()
    
    //MatchMakes for all companies in program.
    let result2 = MatchMakeAllCompanies (Companies, selectedRate)

    //Prints matches
    PrintMatches result2

    Console.ReadLine()
    0

    
        


