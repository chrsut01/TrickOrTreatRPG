namespace TrickOrTreatRPG;

public class Game
{
        private ThingToEncounterFactory factory = new ThingToEncounterFactory();

        private string action1;
        private bool _isGameOver { get; set;}
        
        private Random random = new Random();

        private static Game instance;

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }

        private Game()
        {
        }

        public bool IsGameOver => _isGameOver;
    
        public void PlayerTurn()
        {
            // Check if it's time to activate GameOver
            if (GameState.Instance.Time >= new TimeSpan(9, 0, 0))
            {
                GameOver();
                return; // Exit the method
            }

            Console.WriteLine("""
                              
                              What would you like to do?
                              1 - Trick-or-treat at a house
                              2 - Check my candy/score
                              3 - Check the time
                              4 - Sort my candy
                              """);
            
            string choice = Console.ReadLine() ?? throw new InvalidOperationException();

            switch (choice)
            {
                case "1":
                    ThingToEncounter encounter = factory.CreateRandomEncounter();
                    if (encounter is CoachHouse)
                    {
                        CoachHouse coachHouse = (CoachHouse)encounter;
                        coachHouse.VisitHouse();
                    }
                    else if (encounter is GenericHouse)
                    {
                        GenericHouse genericHouse = (GenericHouse)encounter;
                        genericHouse.VisitHouse();
                    }
                    else if (encounter is SweetOldLadyHouse)
                    {
                        SweetOldLadyHouse sweetOldLadyHouse = (SweetOldLadyHouse)encounter;
                        sweetOldLadyHouse.VisitHouse();
                    }
                    else if (encounter is Bully)
                    {
                        Bully bully = (Bully)encounter;
                        bully.Approach();
                        bully.React();
                    }
                    else if (encounter is Munchkins)
                    {
                        Munchkins munchkins = (Munchkins)encounter;
                        munchkins.Approach();
                        munchkins.React();
                    }
                    
                    break;

                case "2":
                    CandyManager.Instance.CheckCandyScore();
                    break;

                case "3":
                    GameState.Instance.CheckTime();
                    break;
                
                case "4":
                    CandyManager.Instance.SortCandy();
                    break;
                
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        public void Start()
        {
            Console.WriteLine("""
                                        
                                               TRICK-OR-TREAT!!!
                              It is 7PM on Halloween night. You are out trick-or-treating 
                              in your favorite costume, ready to fill your plastic pumpkin 
                              with as much candy as you can before 9PM, at which time the 
                              people usually stop giving out candy, and your mother said 
                              you have to come home anyway.
                              
                        """);
                              
            Console.WriteLine("Press Enter to begin...");
            Console.ReadLine(); // Wait for the user to press Enter

            Console.Clear(); // Clear the console before starting the game
            
            PlayerTurn();
        }
    
        public void GameOver()
        {
            string message;
            if(CandyManager.Instance.CheckScore() < 30)
            {
                message = "Better luck next time!";
            }
            else if (GameState.Instance.Time >= new TimeSpan(9, 0, 0))
            {
                message = "It's 9PM. Times up. You'd better go home now.";
            }
            else
            {
                message = "Good job!";
            }
            //Console.WriteLine("\nGAME OVER");
            int score = CandyManager.Instance.CheckScore();
            Console.WriteLine($"\nGAME OVER\n{message}\nYour final score is: {score}.");
            _isGameOver = true;
        }
    }
