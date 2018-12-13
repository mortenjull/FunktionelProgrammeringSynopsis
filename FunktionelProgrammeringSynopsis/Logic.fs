module Logic
    open Types
    open System.Linq
    open System
    open Data
    
    // MatchMaking funktion for finding mathces between companies. Result is based upon,
    // the given condition resembling match rate procentage.
    // Company: Selected Company.
    // Companies: List of Companies.
    // Condition: Matching rate.
    // Return: List of Matches.
    let rec MatchMaking (company:Company, companies: List<Company>, condition: float) =
        
        // Compares Categories from companies and calculates Rate and
        // Creates Match object based open this.
        // Company1: Selected Company.
        // Company2: Company to be matched with.
        // Return: Match object.
        let CompareCompanies (company1: Company, company2: Company) =
            let intersection = Set.intersect company1.Categories company2.Categories
            let rate = float (intersection.Count) / float (company1.Categories.Count)
            Match(company1, company2, intersection, rate)

        // Filters matches from CompareCompanies and removes those bellow the given condition.
        // M: Match object.
        // Condition: Match rate.
        // Return: List of matches with Rate above or equal to Condition.
        let Filter (m: Match, condition: float) =
            match m with
            | m when m.Rate >= condition -> [m]
            | _ -> []
        
        // Calls the local functions in a pipelike fashion.
        // Company: Selected company:
        // Companies: List of companies to be matches with.
        // Condition: Match rate.
        // Return: List of matches with Rate above or equal to Condition.
        let rec local (company: Company, companies: List<Company>, condition: float) =
            match companies with
            | h::t -> (Filter (CompareCompanies(company, h), condition)) @ local(company, t, condition)
            | _ -> []
        
        // Starts the loop.
        local (company, companies, condition)
    
    // Runs Matchmaking in recursion by looping throug Companies list.
    // Companies: List of all companies.
    // Condition: Match rate.
    // Return: returns a list of Matches with match rate above or equal to Condition.
    let rec MatchMakeAllCompanies (companies: List<Company>, condition: float) =
        match companies with
        | h::t -> MatchMaking (h, t, condition) @ MatchMakeAllCompanies (t, condition)
        | _ -> []

    // Prints the given list of mathces in the console.
    // Matches: List of matches.
    // Return: Prints Console dialog in recusinve fasion.
    let rec PrintMatches (matches:List<Match>) =
        match matches with
        | h::t -> (printfn "Company %s matches with %s and match rate is %f" h.Company1.Name h.Company2.Name h.Rate)
                  PrintMatches t
        | _ -> ()


    // Prints the list of companies.
    // Return: Prints Console dialog in recursive fasion.
    let rec PrintCompanies (companies: List<Company>) = 
        match companies with
        |h::t -> (printfn "Company %s" h.Name)
                 PrintCompanies t
        |_ -> ()

    // Finds the company asked for based on name taken from input.
    // Runs in recusive fashion until a company is found.
    // Companies: List of all companies.
    // Return: Selected Company.
    let rec AskForCompany (companies: List<Company>) =
        printfn "Enter Name of Company:"
        let input  = Console.ReadLine().Trim().ToLowerInvariant()
        let company = List.tryFind<Company> (fun c -> c.Name.ToLowerInvariant().Equals(input)) companies
        match company with 
            | Some company -> company 
            | None -> AskForCompany Companies 

    // Takes input and casts it to float. Rate represents matching criteria for matches.
    // Min: Minimum Rate value.
    // Max: Maximum Rate value.
    // Return: Matching rate of type float.
    let rec AskForRate (min:float, max:float) = 
        printfn "Enter your lowest matchRate between: %f and %f ." min max
        let rate = Console.ReadLine().Trim().ToLowerInvariant()
        match Double.TryParse(rate) with 
            | true , n when n <= max && n >= min-> n
            | _ -> AskForRate (max, min)

        




