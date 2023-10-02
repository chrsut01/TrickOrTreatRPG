namespace TrickOrTreatRPG;

public class GenericHouse : House
{
    
    public string Name { get; set; }

    public GenericHouse()
    {
        Name = "";
    }
    
    public override string VisitHouse()
    {

        string action1 = base.VisitHouse();

        if (action1 == "1") // You acted aggressively...
        {
            string reaction1 = CalculateReaction(40, 20);
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
            string reaction3 = CalculateReaction(20, 60);
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
                                  
                                  You push your way up to the front of the group,
                                  and accidentally knock over a small trick-or-treater
                                  in a Yoda costume. The host gives you a handful of candy,
                                  and upon turning around to leave, notice that Yoda has 
                                  dropped a piece or two of candy, which you surreptitiously
                                  snatch up and put into your pumpkin. 
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,6);
                break;

            case "2":
                Console.WriteLine("""
                                  
                                  When it is your turn to get some candy,
                                  the host gives you a big handful. You say, 
                                  "Thanks!" and head on your merry way.
                                  """);
                CandyManager.Instance.AddPlayerCandy(2,4);
                break;

            case "3":
                Console.WriteLine("""
                                  
                                  The host is impressed with your politeness and says,
                                  “Well, aren't you the polite little trick-or-teater
                                  this evening. Here's a big handful of candy.”
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,5);
                break;
        }
    }
    
    public void ModerateOutcome()
    {
                Console.WriteLine("""
                  
                                   The host gives you a handful of candy.
                                   You say, "Thank you", and head off back 
                                   to the sidewalk with the other trick-or-treaters. 
                                   """);
                CandyManager.Instance.AddPlayerCandy(1,3);
    }

    public void NegativeOutcome(string action1)
    {
        switch (action1){
            case "1":
                if (CandyManager.Instance.PlayerCandy.Count > 0)
                {
                    Console.WriteLine("""
                                      
                                      You push your way to the front of the group and
                                      end up pissing off the other trick-or-treaters
                                      who shove you back and send you and your pumpkin
                                      flying. You lie there helplessly as they grab as
                                      much of your candy as they can and then run off
                                      laughing, "Ha-ha! You get what you deserve, jerk!"
                                      """);
                    CandyManager.Instance.RemovePlayerCandy(4, 8);
                    GameState.Instance.AddTime(6);
                }
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  The host says, “Sorry kid, no more candy left.”
                                  You reply, "That's OK.", but you are so actually so
                                  despondent that, upon leaning, don't notice the 
                                  uneven pavement on the sidewalk and stumble, causing
                                  a piece of candy to fall out of your pumpkin.
                                  """);
                CandyManager.Instance.RemovePlayerCandy(1,1);
                GameState.Instance.AddTime(3);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  The host unfortunately doesn't seem to notice your
                                  calculated politeness and says, “Sorry kid, I seem 
                                  to have just run out of candy. That previous trick-or-
                                  treater in the Dalai Lama costume just got the last piece.”
                                  """);
                break;
        }
    }
}  
