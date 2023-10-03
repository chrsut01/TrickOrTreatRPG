namespace TrickOrTreatRPG.Management;

public class GameState
{
    private static GameState instance;
    
    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState();
            }
            return instance;
        }
    }
    
    //public int minutesToAdd;
    public TimeSpan Time = new TimeSpan(06,00,00);
    public string PresentTime;
    
    public void CheckTime()
    {
        PresentTime = Time.ToString("hh\\:mm"); 
        Console.WriteLine($"The time is now {PresentTime}");
    }

    public void AddTime(int minutesToAdd)
    {
        Time = Time.Add(TimeSpan.FromMinutes(minutesToAdd));
        PresentTime = Time.ToString("hh\\:mm");
    }
    
}
