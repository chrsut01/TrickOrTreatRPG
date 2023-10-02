namespace TrickOrTreatRPG;

public class CoachHouse : House
{
    public string Name { get; set; }

    public CoachHouse()
    {
        Name = "high school football coach";
    }

    public override string VisitHouse()
    {

        string action1 = base.VisitHouse();

        Console.WriteLine($"\nTurns out it's the house of the {Name}.");

        if (action1 == "1") // You acted aggressively...
        {
            string reaction1 = CalculateReaction(60, 30);
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

        else if (action1 == "2") // You acted moderately...
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

        else if (action1 == "3") //You acted politely...
        {
            GameState.Instance.AddTime(2);
            string reaction3 = CalculateReaction(10, 50);
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
                                  
                                  He is impressed with your assertiveness and says,
                                  “Good for you kid, taking charge like that.
                                  Here, reach in the bowl and grab whatever you want.”
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,6);
                break;

            case "2":
                Console.WriteLine("""
                                  
                                  He gives you a big handful of candy.
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,5);
                break;

            case "3":
                Console.WriteLine("""
                                  
                                  He is impressed with your politeness and says,
                                  “It's nice to see a polite trick-or-treater for once.
                                  Here's a big handful of candy.”
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,5);
                break;
        }
    }
    
    public void ModerateOutcome()
    {
                Console.WriteLine("""
                                    
                                    He gives you a handful of candy. 
                                    """);
                CandyManager.Instance.AddPlayerCandy(1,3);
    }

    public void NegativeOutcome(string action1)
    {
        switch (action1){
            case "1":
            Console.WriteLine("""
                              
                              He is unimpressed with your aggressiveness and says,
                              “Hey kid, no candy for rude trick-or-treaters. Beat it.”
                              """);
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  He says, “Sorry kid, no more candy left.”
                                  """);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  He is unimpressed with your passivity and says,
                                  “Sorry kid, no more candy left. Nice guys finish last.”
                                  """);
                break;
        }
    }
}  
