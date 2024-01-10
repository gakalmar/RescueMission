using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

namespace MightyTextAdventure;

public class Game
{
    private readonly Area[] _areas;
    private readonly Input _input;
    private readonly Display _display;
    public Player CurrentPlayer;
    public bool GameEnded { get; set; }
    public bool SavedWife { get; set; }

    public Game()
    {
        _areas = new Area[5];
        _input = new Input();
        _display = new Display();
        GameEnded = false;
        SavedWife = false;
    }
    
    public void GameIntro()
    {
        CurrentPlayer = CreatePlayer();
        _display.AddSeparatorLine();
        _display.PrintMessage(CurrentPlayer.Description);
        Console.ReadLine();
        _display.AddSeparatorLine();
        _display.PrintMessage($"As dawn breaks in the idyllic town of Meadowbrook,\n" +
                              $"{CurrentPlayer.Name} awakens in the cozy embrace of {(CurrentPlayer.Gender == "m" ? "his" : "her")} home.\n" +
                              $"{CurrentPlayer.Name} had a long night in the pub, with {(CurrentPlayer.Gender == "m" ? "his" : "her")} record still left unbroken.\n" +
                              $"The morning sun paints a golden hue across the meadows outside.\n" +
                              $"However, a sense of unease grips {CurrentPlayer.Name} as {(CurrentPlayer.Gender == "m" ? "he" : "she")} realizes {(CurrentPlayer.Gender == "m" ? "his wife" : "her husband")} is missing.\n" +
                              $"Once a seasoned adventurer, {CurrentPlayer.Name} had settled into a peaceful life in this quaint town.\n" +
                              $"Now, a mysterious journey awaits as {(CurrentPlayer.Gender == "m" ? "he" : "she")} begins {(CurrentPlayer.Gender == "m" ? "his" : "her")} search for answers,\n" +
                              $"{(CurrentPlayer.Gender == "m" ? "His" : "Her")} once-peaceful existence disrupted by the unsettling disappearance of {(CurrentPlayer.Gender == "m" ? "his beloved wife" : "her beloved husband")}.");
        _display.AddSeparatorLine();
    }
    
    public void Init()
    {
        LoadAreas();
        GameIntro();
        Console.ReadLine();
        _display.PrintMessage($"{CurrentPlayer.Name} is currently standing at the gates of Meadowbrook, trying to decide where to go next.");
    }
    
    public Player CreatePlayer()
    {
        _display.PrintSameLineMessage($"Enter the name of your hero: ");
        Player player = new Player(_input.GetInputFromUser(CurrentPlayer), _areas[0]);

        _display.PrintSameLineMessage($"Enter the gender of your hero: [m/f] ");
        string gender = _input.GetInputFromUser(player);

        while (gender != "m" && gender != "f")
        {
            _display.PrintSameLineMessage($"Please enter a valid answer: [m/f] ");
            gender = _input.GetInputFromUser(player);
        }

        player.Gender = gender;
        return player;
    }

    public void Travel()
    { 
        _display.PrintMessage($"Where do you want to go next?");
        for (int i = 0; i < CurrentPlayer.CurrentArea.ConnectedAreas.Count; i++)
        {
            _display.PrintMessage($"[{i + 1}] {CurrentPlayer.CurrentArea.ConnectedAreas[i].Description}");
        }
        
        int input = int.Parse(_input.GetInputFromUser(CurrentPlayer));

        bool newAreaFound = false;
        
        if (input <= CurrentPlayer.CurrentArea.ConnectedAreas.Count && input > 0)
        {
            CurrentPlayer.CurrentArea = CurrentPlayer.CurrentArea.ConnectedAreas[input-1];
            newAreaFound = true;
            _display.AddSeparatorLine();
            _display.PrintMessage($"You went to the {CurrentPlayer.CurrentArea.Description}");
            _display.AddSeparatorLine();
        }
        
        if (!newAreaFound)
        {
            _display.PrintMessage($"Invalid location, please try again.");
            Console.ReadLine();
            Travel();
        }
    }

    public void Interact(Player player, Game game)
    {
        player.CurrentArea.Interaction(player, game);
    }

    public void HandleGameEnd()
    {
        if (SavedWife)
        {
            _display.PrintMessage($"With a final roar, the dragon falls, defeated before {CurrentPlayer.Name}'s unwavering courage!");
            _display.PrintMessage($"{CurrentPlayer.Name} has not only saved his wife but also proven himself as a legendary hero.");
            _display.PrintMessage($"Meadowbrook celebrates the victory, and {CurrentPlayer.Name} and his wife live happily ever after.");
        }
        else
        {
            _display.PrintMessage($"{CurrentPlayer.Name} fought bravely against the mighty dragon, but its power proved overwhelming.");
            _display.PrintMessage($"As the final moments unfold, {CurrentPlayer.Name}'s thoughts linger on his beloved wife.");
            _display.PrintMessage($"A valiant effort, though fate had other plans for this brave adventurer.");
        }
    }

    private void LoadAreas()
    {
        _areas[0] = new Town("Meadowbrook");
        _areas[1] = new Ruins("Ravenrock Ruins");
        _areas[2] = new Lagoon("Lavender Lagoon");
        _areas[3] = new Woods("Whispering Woods");
        _areas[4] = new Mountains("Mystic Mountains");
    
        _areas[0].ConnectedAreas.Add(_areas[1]);
        _areas[0].ConnectedAreas.Add(_areas[2]);
        _areas[0].ConnectedAreas.Add(_areas[3]);
        _areas[0].ConnectedAreas.Add(_areas[4]);
        
        _areas[1].ConnectedAreas.Add(_areas[0]);
        _areas[2].ConnectedAreas.Add(_areas[0]);
        _areas[3].ConnectedAreas.Add(_areas[0]);
        _areas[4].ConnectedAreas.Add(_areas[0]);
    }
    
}
