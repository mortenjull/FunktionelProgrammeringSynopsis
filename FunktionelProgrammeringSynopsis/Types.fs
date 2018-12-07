module Types

    // Type configuration of company.
    type Company(name:string, categories:Set<int>) =
        member this.Name = name
        member this.Categories = categories
    
    // Type configuration of category.
    type Category(id: int, name: string) = 
        member this.Id = id
        member this.Name = name

    type Match(company1: Company, company2: Company, categories: Set<int>, rate:float) =
        member this.Company1 = company1
        member this.Company2 = company2
        member this.Categories = categories
        member this.Rate = rate
