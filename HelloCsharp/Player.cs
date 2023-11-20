namespace HelloCsharp;

public class Player
{
    private readonly string[] _playable = { "rock", "paper", "scissors" };
    private readonly Random _random = new Random();
    
    public Player(bool automated)
    {
        this.Automated = automated;
    }
    
    public bool Automated { get; }
    
    public Move? PlayerMove { get; private set; }

    public void SetAutomatedMove()
    {
        var moves = Enum.GetValues((typeof(Move)));
        this.PlayerMove = (Move)(moves.GetValue(_random.Next(moves.Length)) ?? Move.Paper);
    }

    public void SetMove()
    {
        Console.WriteLine("What is your move? (rock/paper/scissors)");
        var moveInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(moveInput) || !_playable.Contains(moveInput.ToLower()))
        {
            this.PlayerMove = null;
            throw new Exception("Invalid move.");
        }

        this.PlayerMove = moveInput switch
        {
            "paper" => Move.Paper,
            "rock" => Move.Rock,
            _ => Move.Scissors
        };
    }
}