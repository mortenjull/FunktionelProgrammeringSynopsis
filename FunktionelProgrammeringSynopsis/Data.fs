module Data 
    open Types
    // List of Companies
    let Companies = [Company(1, "McDonalds", Set.ofList [1;2;3;4;5;]); 
                     Company(2, "BurgerKing", Set.ofList [1;2;3;6;8;]); 
                     Company(3, "KFC", Set.ofList [1;4;6;7;8;]); 
                     Company(4, "Sunset", Set.ofList [3;5;7;9;]);
                     Company(5, "Pizza", Set.ofList [6;8;9;5;1;])
                     Company(6, "Mums", Set.ofList [1;2;3;4;5;])]
    // List of categories
    let Categories = [Category(1, "FastFood"); 
                      Category(2, "Kød"); 
                      Category(3, "Sodavand"); 
                      Category(4, "Legetøj");
                      Category(5, "Burger");
                      Category(6, "Sundt");
                      Category(7, "PommesFrittes");
                      Category(8, "Kylling");
                      Category(9, "Dyrt");]



    