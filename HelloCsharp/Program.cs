// See https://aka.ms/new-console-template for more information

var random = new Random();

string[] playable = { "rock", "paper", "scissors" };
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
    
    Console.WriteLine("Choose rock, paper, or scissors.");
    var playerChoice = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(playerChoice) || !playable.Contains(playerChoice.ToLower()))
    {
        Console.WriteLine("Invalid choice, try again.");
        continue;
    }

    var computerChoice = playable[random.Next(0, 3)];
    Console.WriteLine("The computer chose: " + computerChoice);

    var result = CalculateResult(playerChoice, computerChoice);

    switch (result)
    {
        case GameResult.Draw:
            Console.WriteLine("The game ended in a draw.");
            gameInProgress = false;
            break;
        case GameResult.Lose:
            Console.WriteLine("You've lost, better luck next time!");
            gameInProgress = false;
            break;
        default:
            Console.WriteLine("You've won! Congratulations!");
            gameInProgress = false;
            break;
    }

}

return;

GameResult CalculateResult(string player, string computer)
{
    if (player == computer)
    {
        return GameResult.Draw;
    } 
    else switch (player)
    {
        case "rock" when computer == "paper":
        case "paper" when computer == "scissors":
        case "scissors" when computer == "rock":
            return GameResult.Lose;
    }
    
    return GameResult.Win;
}

internal enum GameResult
{
    Draw,
    Win,
    Lose,
}