namespace TrickOrTreatRPG.Encounters;

public abstract class ThingToEncounter
{
    private Random random = new Random();
    
    protected string CalculateReaction(int probabilityPositive, int probabilityModerate)
    {
        int randomOutcome = random.Next(1, 101);

        if (randomOutcome <= probabilityPositive)
        {
            return "positive";
        }
        else if (randomOutcome <= probabilityPositive + probabilityModerate)
        {
            return "moderate";
        }
        else
        {
            return "negative";
        }
    }
}