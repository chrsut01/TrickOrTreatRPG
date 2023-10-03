namespace TrickOrTreatRPG;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = Game.Instance;

        game.Start();
        // Main game loop
        while (!game.IsGameOver)
        {
            game.PlayerTurn();
        }
    }
}