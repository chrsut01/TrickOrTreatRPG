using TrickOrTreatRPG.Management;

namespace TrickOrTreatRPG.Encounters.Characters;

public class RockPaperScissorsFriend : Character
{
    private string action1;
    
    public string Approach()
    {
        Console.WriteLine("""
                          
                          Suddenly you are approached by someone in a ghost costume. 
                          It turns out to be a friend of yours. She says, “How about 
                          a dare? Want to play rock-paper-scissors to see who gets to 
                          grab a handful of candy out of the other persons pumpkin?”

                          What action do you take?
                          1 - Not to play
                          2 - To play
                          
                          """);
        action1 = Console.ReadLine();
        return action1;
    }

    public override void React()
    {
        switch(action1)
        {
            case "1" :  // you don't play
                GameState.Instance.AddTime(2);
                
           Console.WriteLine("""
                             
                             You say, "Thank you for your kind offer, but I don't
                             think I can afford to risk losing any candy." 
                             "Just thought I'd ask," she replies. "Good night."
                             """);
        break;

            case "2": // you do play
                GameState.Instance.AddTime(7);
            string reaction2 = CalculateReaction(50, 0);
                if (reaction2 == "positive")
                {
                 PositiveOutcome(action1);
                }
                else
                {
                NegativeOutcome(action1);
                }
            break;
            
            default:
                Console.WriteLine("Please enter 1 or 2.");
                break;
            }
    }

    public void PositiveOutcome(string action)
    {
        Console.WriteLine("""

                          After three intense rounds, you are the winner!
                          "I did it! I won!" You take a generous handful of
                          candy from your disappointed friends pumpkin.
                          Thank her for her suggestion and continue on your way.
                          """);
    }

    public void NegativeOutcome(string action)
    {
        Console.WriteLine("""

                          After three intense rounds, you are the loser!
                          Your friend says, "I did it! I won!" She takes a 
                          generous handful of candy from your pumpkin. You
                          are disappointed by manage a reluctant, "Congratulations."
                          And continue on your way.
                          """);
        }
}