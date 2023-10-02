namespace TrickOrTreatRPG;

public class House : ThingToEncounter
{
    public string Name { get; set; }
    protected static Random random = new Random();
    
    
    private string action1;
   // protected int randomReaction;
   

    public virtual string VisitHouse()
    {
        GameState.Instance.AddTime(5);
        while (true)
        {
            Console.WriteLine("""

                              You go up to the nearest house with a group of other trick-or-treaters.
                              Someone rings the doorbell, and you all say "Trick-or-treat!" as the
                              host answers the door.

                              What action do you want to take?
                              1 - Push your way up to the front.
                              2 - Stay in the group and wait your turn.
                              3 - Let all the other kids go before you.
                              """);
            action1 = Console.ReadLine();
            
            if (action1 == "1" || action1 == "2" || action1 == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter 1, 2 or 3.");
            }
        }
        return action1; 
    }
}