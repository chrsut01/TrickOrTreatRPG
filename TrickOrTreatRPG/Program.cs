namespace TrickOrTreatRPG;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize game elements and state
        //Game game = new Game();
        Game game = Game.Instance;

        game.Start();
        // Main game loop
        while (!game.IsGameOver)
        {
            game.PlayerTurn();
        }
    }
}