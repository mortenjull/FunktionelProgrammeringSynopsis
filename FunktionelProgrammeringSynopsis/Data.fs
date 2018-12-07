module Data 
    open Types
    
    let Companies = [Company("McDonalds", Set.ofList [1;2;3;4;5;]); 
                     Company("BurgerKing", Set.ofList [1;2;3;6;8;]); 
                     Company("KFC", Set.ofList [1;4;6;7;8;]); 
                     Company("Sunset", Set.ofList [3;5;7;9;]);
                     Company("Pizza", Set.ofList [6;8;9;5;1;])]

    let Categories = [Category(1, "FastFood"); 
                      Category(2, "Kød"); 
                      Category(3, "Sodavand"); 
                      Category(4, "Legetøj");
                      Category(5, "Burger");
                      Category(6, "Sundt");
                      Category(7, "PommesFrittes");
                      Category(8, "Kylling");
                      Category(9, "Dyrt");]



    