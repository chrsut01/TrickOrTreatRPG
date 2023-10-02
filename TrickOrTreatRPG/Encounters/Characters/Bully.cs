namespace TrickOrTreatRPG;

public class Bully : Character
{
    private string action1;
    
    public string Approach()
    {
        Console.WriteLine("""
                          Suddenly the bully from the neighborhood, Scott Farkas,
                          stomps toward you dressed in a Donald Trump costume.
                          "Hey kid! Yeah YOU! Gimme all your candy!"
                          You freeze for a second...

                          What action do you take?
                          1 - Run away
                          2 - Stand your ground
                          3 - Attack!
                          """);
        action1 = Console.ReadLine();
        return action1;
    }

    public override void React()
    {
        GameState.Instance.AddTime(7);

        switch(action1)
        //if (action == "1") // You run away
        {
            case "1" :
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

        //else if (action == "2") // You stand your ground
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
        //else if (action == "3") // You attack!
            case "3":
                string reaction3 = CalculateReaction(10, 80);
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
                Console.WriteLine("Please enter 1, 2 or 3");
                break;
            }
    }

    public void PositiveOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                     You run away as fast as you can. Luckily the bully is as
                                     physically slow as he is mentally. In unthinking desperation
                                     he hurls something at you, which ends up being candy. You quickly
                                     pick it up off the ground and in glancing back you can see that
                                     he's given up and is probably looking for some other poor
                                     trick-or-treater to harass.
                                  """);
                CandyManager.Instance.AddPlayerCandy(1,3);
                break;
            case "2": 
                Console.WriteLine("""
                                  
                                  Despite your fear of the Donald Trump wanna-be, you 
                                  stand your ground. He hesitates for a moment, surprised
                                  by your bravery. He slowly approaches you, glaring. You
                                  glare back and say, "I'm not afraid of you!" He tries to 
                                  laugh it off but is clearly unsettled as he goes off to
                                  find an easier victim.
                                  """);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  Unintimidated by the Donald Trump wanna-be, you 
                                  raise brandish your little pumpkin like a weapon. 
                                  He lunges at you, but you swing the pumpkin as hard 
                                  as you can and wack him square on the side of his 
                                  rubber-coated, fat head. He falls to the ground 
                                  crying. You grab his pumpkin full of candy and run 
                                  off as fast as you can.
                                  """);
                    CandyManager.Instance.AddPlayerCandy(7,12);
                break;
        }
    }

    public void ModerateOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                  You try to run away, as fast as you can. He yells
                                  after you, "You little coward!" But you are just 
                                  relieved to be away from him.
                                  """);
                CandyManager.Instance.RemovePlayerCandy(1,1);
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  Despite your fear of the Donald Trump wanna-be, you 
                                  stand your ground. He lunges at you, but you swing 
                                  your little pumpkin as hard as you can. You don't 
                                  manage to hit him very hard, but he is surprised to 
                                  see you fight back. He gives you a slight shove on the
                                  shoulder, reaches into your pumpkin, pulls out a handful
                                  of your candy, and walks off smirking. 
                                  """);
                CandyManager.Instance.RemovePlayerCandy(2,6);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  Unintimidated by the Donald Trump wanna-be, you 
                                  raise brandish your little pumpkin like a weapon. 
                                  He lunges at you, but you swing the pumpkin as hard 
                                  as you can. You barely nick the side of his rubber-coated
                                  fat head. He is a bit take aback by your brazenness but
                                  grabs your pumpkin from you and takes a couple piece of 
                                  candy, swaggering off saying, "You're lucky I let you off
                                  this easy, shrimp."
                                  """);
                CandyManager.Instance.RemovePlayerCandy(2,4);
                break;
        }
    }

    public void NegativeOutcome(string action)
    {
        switch (action)
        {
            case "1":
                Console.WriteLine("""
                                  
                                  You run away as fast as you can, but the bully catches
                                  up with you and gives you a powerful shove from behind.
                                  You go flying to the ground and your pumpkin goes flying
                                  up in the air and into the bully's hands. All is lost.
                                  You lie there crying quietly to yourself before giving up
                                  and heading home.
                                  """);
                CandyManager.Instance.RemoveAllPlayerCandy();
                Game.Instance.GameOver();
                break;
            case "2":
                Console.WriteLine("""
                                  
                                  Despite your fear of the Donald Trump wanna-be, you 
                                  stand your ground. He lunges at you, but you swing 
                                  your little pumpkin as hard as you can. You don't 
                                  manage to hit him very hard, but he is surprised to 
                                  see you fight back. He gives you a slight shove on the
                                  shoulder, reaches into your pumpkin, pulls out some
                                  of your candy, and walks off smirking.
                                  """);
                CandyManager.Instance.RemovePlayerCandy(2,4);
                break;
            case "3":
                Console.WriteLine("""
                                  
                                  Unintimidated by the Donald Trump wanna-be, you 
                                  raise brandish your little pumpkin like a weapon. 
                                  He lunges at you, but you swing the pumpkin as hard 
                                  as you can. You, however, don't manage to hit him
                                  and he's even now more angry than before. He takes
                                  your pumpkin, shoves you by the face to the ground.
                                  All is lost. You lie there crying quietly to yourself 
                                  before giving up and heading home.
                                  """);
                CandyManager.Instance.RemoveAllPlayerCandy();
                Game.Instance.GameOver();
                break;
        }
    }
}