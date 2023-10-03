namespace TrickOrTreatRPG.Encounters.Characters;

public class Munchkins : Character
{
      private string action1;

    public override string Approach()
    {
        Console.WriteLine("""
                          
                          You are suddenly surrounded by a gang of trick-or-treaters 
                          dressed as Wizard of Oz Munchkins. As their costumes would 
                          suggest, they are clearly smaller than but clearly outnumber 
                          you. They holler, “Hey! We represent the Lolly-pop Guild, so 
                          give us your candy”. (You also notice they are carrying eggs.)

                          What action do you take?
                          1 - Run away
                          2 - Try to scare them off
                          3 - Fight!
                          """);
        action1 = Console.ReadLine();
        return action1;
        //throw new NotImplementedException();
    }

    public override void React()
    {
        switch (action1)
        {
            case "1":
                string reaction1 = CalculateReaction(70, 25);
                if (reaction1 == "positive")
                {
                    PositiveOutcome(action1);
                }
                else if (reaction1 == "moderate")
                {
                    ModerateOutcome(action1);
                }
                else
                {
                    NegativeOutcome(action1);
                }
                break;
            
            case "2":
                string reaction2 = CalculateReaction(10, 80);
                if (reaction2 == "positive")
                {
                    PositiveOutcome(action1);
                }
                else if (reaction2 == "moderate")
                {
                    ModerateOutcome(action1);
                }
                else
                {
                    NegativeOutcome(action1);
                }
                break;
            case "3":
                string reaction3 = CalculateReaction(70, 25);
                if (reaction3 == "positive")
                {
                    PositiveOutcome(action1);
                }
                else if (reaction3 == "moderate")
                {
                    ModerateOutcome(action1);
                }
                else
                {
                    NegativeOutcome(action1);
                }
                break;
            default:
                Console.WriteLine("Please enter 1, 2 or 3.");
                break;
        }
    }

    public void PositiveOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                     Although surrounded, you push past the little rascals
                                     and run away as fast as you can. A few eggs whiz past
                                     your head as you run, but none of them land a direct hit.
                                  """);
                break;
            case "2": 
                Console.WriteLine("""
                                  
                                  You stand tall, make as scary a face as possible,
                                  and with all your might, let out a deep "ROARRRR!!!"
                                  The little twerps run off in various directions, bumping
                                  into one another and dropping eggs and some candy on the 
                                  ground, which now belongs to you. (The candy, not the eggs.)
                                  """);
                CandyManager.Instance.AddPlayerCandy(1,3);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                    Now you're really pissed off! How dare they even
                                    indirectly threaten you with egg pelting! You clobber 
                                    a few of them on the head with your pumpkin. Most of them
                                    back away in fear. "We're sorry. We didn't mean it. Here's
                                    some candy." They drop a few handfuls before scampering off
                                    like the cowards they are. More candy for you!
                                  """);
                CandyManager.Instance.AddPlayerCandy(3,6);
                break;
        }
    }

    public void ModerateOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                  Although surrounded, you push past the little rascals
                                  and run away as fast as you can. A few eggs whiz past
                                  your head as you run. None of them land a direct hit,
                                  but in your haste (and the dimming evening light), you
                                  stumble and lose a piece or two of candy.
                                  
                                  """);
                CandyManager.Instance.RemovePlayerCandy(1,2);
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  You stand tall, make as scary a face as possible,
                                  and with all your might, let out a deep "ROARRRR!!!"
                                  The little twerps are unfazed and begin hurling eggs toward
                                  you. In order to distract them, you toss a piec of candy on 
                                  the ground, which they fight for just long enough for you to 
                                  make a quick get-away. (Luckily egg-free.)
                                  """);
                CandyManager.Instance.RemovePlayerCandy(1,1);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  Now you're really pissed off! How dare they even
                                  indirectly threaten you with egg pelting! You clobber 
                                  a few of them on the head with your pumpkin, and they
                                  immediately run off to see the Wizard or the yellow
                                  brick road or something...
                                  """);
                break;
        }
    }

    public void NegativeOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                  You are surrounded. And those egge they're holding
                                  aren't too encouraging. You try to make a run for it, but
                                  the little rascals are surprisingly strong and trip you. 
                                  They pounce on you and your candy, grabbing it up with 
                                  their greedy paws, and running off before you can say,
                                  "There's no place like home."
                                  """);
                CandyManager.Instance.RemovePlayerCandy(4,8);
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  You stand tall, make as scary a face as possible,
                                  and with all your might, let out a deep "ROARRRR!!!"
                                  But, with your mouth wide open, you suddenly find 
                                  it filled with fast moving egg one of the Munchkins 
                                  has hurled your way. While you are gagging and trying
                                  to get your bearings, their grabbing your candy and 
                                  skedaddling!
                                  """);
                CandyManager.Instance.RemovePlayerCandy(4,8);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  You swing at them unsuccessfully with your pumpkin, 
                                  but then they really let you have it. "Fire away!", 
                                  you hear just before being hit by what must be a 
                                  baker's dozen of eggs. You are completely covered 
                                  in dripping egg slime as is all your candy, which is 
                                  as ruined as your evening. The Munchkins run off.
                                  You stand there in shock.
                                  """);
                CandyManager.Instance.RemoveAllPlayerCandy();
                Game.Instance.GameOver();
                break;
        }
    }
}