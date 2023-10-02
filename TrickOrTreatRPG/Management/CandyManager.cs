namespace TrickOrTreatRPG;

public class CandyManager
{
    public List<Candy> PlayerCandy;
    public List<Candy> PossibleCandy;

    public static CandyManager instance;

    public static CandyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CandyManager();
            }
            return instance;
        }
    }
    
    private CandyManager()
    {
        PlayerCandy = new List<Candy>();
        PossibleCandy = new List<Candy>();

        CreateAndAddCandy("Candy Bar", 10);
        CreateAndAddCandy("Milk Duds", 9);
        CreateAndAddCandy("Red Hots", 8);
        CreateAndAddCandy("Jolly Rancher", 7);
        CreateAndAddCandy("Taffy", 6);
        CreateAndAddCandy("Skittles", 5);
        CreateAndAddCandy("Jaw Breaker", 4);
        CreateAndAddCandy("Mary Jane", 3);
        CreateAndAddCandy("Necco Wafers", 2);
        CreateAndAddCandy("Candy Corn", 1);
        CreateAndAddCandy("Rock", 0);

    }

    private void CreateAndAddCandy(string name, int points)
    {
        Candy candy = new Candy(name, points);
        PossibleCandy.Add(candy);
    }
    
    public void AddPlayerCandy(int min, int max)
    {
        Random random = new Random();

        // Determine how many items to add (randomly)
        int numItemsToAdd = random.Next(min, max + 1); // "+1" to include max value

        // Shuffle the PossibleCandy list to randomize item selection
        List<Candy> shuffledCandy = PossibleCandy.OrderBy(x => random.Next()).ToList();

        // Add the selected items to PlayerCandy
        for (int i = 0; i < numItemsToAdd && i < shuffledCandy.Count; i++)
        {
            PlayerCandy.Add(shuffledCandy[i]);
        }
    }
    
    public void RemovePlayerCandy(int min, int max)
{
    if (PlayerCandy.Count == 0)
    {
        return; // Return early if PlayerCandy is empty
    }
    Random random = new Random();
    
    // Determine how many items to remove (randomly)
    int numItemsToRemove = random.Next(min, max + 1); 
  
    // Shuffle the PossibleCandy list to randomize item selection
    List<Candy> shuffledCandy = PlayerCandy.OrderBy(x => random.Next()).ToList();

    if (numItemsToRemove > shuffledCandy.Count)
    {
        numItemsToRemove = shuffledCandy.Count - 1;
    }
    int i = 0;
    while (i < numItemsToRemove && PlayerCandy.Count > 0)
    {
        PlayerCandy.Remove(shuffledCandy[i]);
        i++;
    }
    }
    
public void RemoveAllPlayerCandy()
{
    PlayerCandy.Clear();
}


    public void CheckCandyScore()
    {
        Console.WriteLine($"\nYou look down into your pumpkin and see... ");
        GameState.Instance.AddTime(2);
        int Score = 0;
        foreach (Candy candy in PlayerCandy)
        {
            Score += candy.Points;
            Console.WriteLine($"{candy.Name}, Points: {candy.Points}");
        }
        if (PlayerCandy.Count == 0)
        {
            Console.WriteLine($"\nYikes! It's in empty!");
        }
        int score = CheckScore(); // Calculate the score using the new method
        Console.WriteLine($"Your score is: {score}");
    }
    public int CheckScore()
    {
        int score = 0;
        foreach (Candy candy in PlayerCandy)
        {
            score += candy.Points;
        }
        return score;
    }
    public void SortCandy()
    {
        if (PlayerCandy.Count == 0)
        {
            GameState.Instance.AddTime(1);
            Console.WriteLine($"\nYou don't have any candy to sort!");
        }
        else
        {
            Console.WriteLine($"\nAfter sorting your candy, it now looks like this:");
            GameState.Instance.AddTime(5);
            PlayerCandy.Sort();
            foreach (Candy candy in PlayerCandy)
            {
                Console.WriteLine($"{candy.Name} Points: {candy.Points}");
            }
        }
    }
}

