﻿module Logic
    open Types
    open System.Linq

    //MatchMaking funktion for finding mathces between companies. Result is based upon,
    //the given condition resombling match rate procentage.
    let rec MatchMaking (company:Company, companies: List<Company>, condition: float) =
        
        let local2 (company1: Company, company2: Company) =
            let intersection = Set.intersect company1.Categories company2.Categories
            let rate = float (intersection.Count) / float (company1.Categories.Count)
            Match(company1, company2, intersection, rate)

        let local3 (company1: Company, company2: Company, condition: float) =
            let m = local2 (company1, company2)
            match m with
            | m when m.Rate >= condition -> [m]
            | _ -> []

        let rec local (company: Company, companies: List<Company>, condition: float) =
            match companies with
            | h::t -> (local3 (company, h, condition)) @ local(company, t, condition)
            | _ -> []


        local (company, companies, condition)

    //Prints the given list of mathces in the console.
    let rec PrintMatches (matches:List<Match>) =
        match matches with
        | h::t -> (printfn "Company %s matches with %s and match rate is %f" h.Company1.Name h.Company2.Name h.Rate)
                  PrintMatches t
        | _ -> ()


    //Prints the lsit of companies.
    let rec PrintCompanies (companies: List<Company>) = 
        match companies with
        |h::t -> (printfn "Company %s" h.Name)
                 PrintCompanies t
        |_ -> ()

    let rec FindCompanyAtIndex (input: string, companies: List<Company>) = 
        let index = List.tryFindIndex<Company> (fun c -> c.Name.ToLowerInvariant().Equals(input.Trim().ToLowerInvariant())), companies
        index




