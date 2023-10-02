namespace TrickOrTreatRPG;

public class SweetOldLadyHouse : House
{
     public string Name { get; set; }

    public SweetOldLadyHouse()
    {
        Name = "sweet old lady";
    }

    public override string VisitHouse()
    {

        string action1 = base.VisitHouse();
        //int randomReaction = random.Next(1, 101);

        Console.WriteLine($"\nTurns out it's the house of the {Name}.");
        

        if (action1 == "1") // You acted aggressively...
        {
            string reaction1 = CalculateReaction(10, 50);
            if (reaction1 == "positive")
            {
                PositiveOutcome(action1);
            }
            else if (reaction1 == "moderate")
            {
                ModerateOutcome();
            }
            else
            {
                NegativeOutcome(action1);
            }
        }

        if (action1 == "2") // You acted moderately...
        {
            string reaction2 = CalculateReaction(15, 70);
            if (reaction2 == "positive")
            {
                PositiveOutcome(action1);
            }
            else if (reaction2 == "moderate")
            {
                ModerateOutcome();
            }
            else
            {
                NegativeOutcome(action1);
            }
        }

        if (action1 == "3") //You acted politely...
        {
            GameState.Instance.AddTime(2);
            string reaction3 = CalculateReaction(65, 25);
            if (reaction3 == "positive")
            {
                PositiveOutcome(action1);
            }
            else if (reaction3 == "moderate")
            {
                ModerateOutcome();
            }
            else
            {
                NegativeOutcome(action1);
            }
        }
        return null; // just holding place for now
    }

    public void PositiveOutcome(string action1)
    {
        switch (action1)
        {
            case "1":
                Console.WriteLine("""
                                  
                                  You push your way to the front, bump into a pint-size
                                  trick-or-treater, whose jostling knocks some of his candy
                                  into your pumpkin, and still manage to get a decent handful
                                  of candy from the kind-hearted but oblivious octogenarian.
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,6);
                break;

            case "2":
                Console.WriteLine("""
                                  
                                  "My, you all have such impressive costumes! Happy Halloween!
                                  And be careful out there." When it is your turn, she puts a
                                  handful of candy into your pumpkin. You reply with, "Thank you, 
                                  Mrs. Kliezwart."
                                  """);
                CandyManager.Instance.AddPlayerCandy(2,4);
                break;

            case "3":
                Console.WriteLine("""
                                  
                                  After all the other kids have gotten their candy, it is
                                  finally your turn. She says to you, "It's so nice to see 
                                  such consideration in a youngster these days. You don't 
                                  see much of that anymore. You help yourself to a nice handful
                                  of candy from this-here bowl." Which you do.
                                  """);
                CandyManager.Instance.AddPlayerCandy(4,7);
                GameState.Instance.AddTime(2);

                break;
        }
    }
    
    public void ModerateOutcome()
    {
                Console.WriteLine("""
                            
                                    When it is your turn, the smiling hostess
                                    gives you a decent handful of candy.
                            """);
                CandyManager.Instance.AddPlayerCandy(1,3);
    }

    public void NegativeOutcome(string action1)
    {
        switch (action1){
            case "1":
            Console.WriteLine("""
                              
                              You impatiently push and shove your way to the front.
                              Mrs. Kliezwart is not impressed with your behavior.
                              "Now, wait a minute here! I simply cannot reward such
                              rudeness! You go about your way and no candy for you
                              from this God-fearing home."
                              """);
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  When it is your turn, Mrs. Kliezwart says, “Oh my word!
                                  We seem to have run out of candy. I'm so sorry."
                                  """);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  After waiting for the other kids to go before you,
                                  Mrs. Kliezwart says, "Oh dear, we seem to have run 
                                  out of candy! I'm so sorry. I told Mr. Kliezwart
                                  that we hadn't gotten enough. And here you were being
                                  so polite."
                                  """);
                break;
        }
    }
}