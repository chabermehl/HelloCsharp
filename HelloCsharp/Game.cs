namespace HelloCsharp;

public class Game
{
    public Game(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    private Player Player1 { get; set; }

    private Player Player2 { get; set; }

    public void GameLoop()
    {
        var gameInProgress = false;
        
        while (true)
        {
            string? continuePlayingInput = null;
            if (!gameInProgress)
            {
                Console.WriteLine("Do you want to play rock, paper, scissors? (y/n)");
                continuePlayingInput = Console.ReadLine();
            }
            
            if (string.IsNullOrWhiteSpace(continuePlayingInput))
            {
                Console.WriteLine("Invalid input, try again.");
                continue;
            }
            
            if (continuePlayingInput.ToLower() == "n")
            {
                Console.WriteLine("Exiting game, goodbye!");
                break;
            }
            
            gameInProgress = true;

            if (Player1.Automated)
            {
                Player1.SetAutomatedMove();
            }
            else
            {
                try
                {
                    Player1.SetMove();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }

            if (Player2.Automated)
            {
                Player2.SetAutomatedMove();
            }
            else
            {
                try
                {
                    Player2.SetMove();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                
            }
            
            Console.WriteLine("Player 1 Move: " + Player1.PlayerMove);
            Console.WriteLine("Player 2 Move: " + Player2.PlayerMove);

            GameResult result;
            try
            {
                result = CalculateGameResult(Player1.PlayerMove, Player2.PlayerMove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }

            PrintGameResult(result);

            gameInProgress = false;
        }
    }

    private static GameResult CalculateGameResult(Move? player1, Move? player2)
    {
        if (player1 == null || player2 == null)
        {
            throw new Exception("A player move was null.");
        }

        if (player1 == player2)
        {
            return GameResult.Draw;
        }

        switch (player1)
        {
            case Move.Rock when player2 == Move.Paper:
            case Move.Paper when player2 == Move.Scissors:
            case Move.Scissors when player2 == Move.Rock:
                return GameResult.Lose;
            default:
                return GameResult.Win;
        }
    }

    private static void PrintGameResult(GameResult result)
    {
        switch (result)
        {
            case GameResult.Draw:
                Console.WriteLine("The game ended in a draw.");
                break;
            case GameResult.Lose:
                Console.WriteLine("You've lost, better luck next time!");
                break;
            case GameResult.Win:
            default:
                Console.WriteLine("You've won! Congratulations!");
                break;
        }
    }
}