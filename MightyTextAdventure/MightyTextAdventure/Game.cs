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

    public void Init()
    {
        LoadArea();
        GameIntro();
        Console.ReadLine();
        _display.PrintMessage($"{CurrentPlayer.Name} is currently standing at the gates of Meadowbrook, trying to decide where to go next.");
    }
    
    //create player
    public Player CreatePlayer()
    {
        Console.Write("Enter the name of your hero: ");
        Player player = new Player(_input.GetInputFromUser(CurrentPlayer), _areas[0]);
        return player;
    }

    public void Travel()
    { 
        Console.WriteLine($"Where do you want to go next?");
        for (int i = 0; i < CurrentPlayer.CurrentArea.ConnectedAreas.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {CurrentPlayer.CurrentArea.ConnectedAreas[i].Description}");
        }
        
        int input = int.Parse(_input.GetInputFromUser(CurrentPlayer));

        bool newAreaFound = false;
        
        if (input <= CurrentPlayer.CurrentArea.ConnectedAreas.Count && input > 0)
        {
            CurrentPlayer.CurrentArea = CurrentPlayer.CurrentArea.ConnectedAreas[input-1];
            newAreaFound = true;
            Console.WriteLine($"You went to the {CurrentPlayer.CurrentArea.Description}");
        }
        
        if (!newAreaFound)
        {
            Console.WriteLine("Invalid location, please type again.");
            Console.ReadLine();
            Travel();
        }
    }

    public void Interact(Player player, Game game)
    {
        player.CurrentArea.Interaction(player, game);
        
        /*if (player.Inventory.Count > 0)
        {
            foreach (var item in player.Inventory)
            {
                Console.WriteLine(item);
            }
        }*/
    }

    public void GameIntro()
    {
        Console.WriteLine("As dawn breaks in the idyllic town of Meadowbrook,\n" +
                          "you awaken in the cozy embrace of your home.\n" +
                          "You had a long night in the pub, your record still left unbroken.\n" +
                          "The morning sun paints a golden hue across the tranquil meadows outside.\n" +
                          $"However, a sense of unease grips {CurrentPlayer.Name} as they realize their wife is nowhere to be found.\n" +
                          $"Once a seasoned adventurer, {CurrentPlayer.Name} had settled into a peaceful life in this quaint town.\n" +
                          "Now, a mysterious journey awaits as they begin their search for answers,\n" +
                          "their once-peaceful existence disrupted by the unsettling disappearance of their beloved spouse.");
        CurrentPlayer = CreatePlayer();
        Console.WriteLine($"The hero is now named {CurrentPlayer.Name}!");
        Console.WriteLine(CurrentPlayer.Description);
    }

    public void HandleGameEnd()
    {
        if (SavedWife)
        {
            Console.WriteLine($"With a final roar, the dragon falls, defeated before {CurrentPlayer.Name}'s unwavering courage!");
            Console.WriteLine($"{CurrentPlayer.Name} has not only saved his wife but also proven himself as a legendary hero.");
            Console.WriteLine($"Meadowbrook celebrates the victory, and {CurrentPlayer.Name} and his wife live happily ever after.");
        }
        else
        {
            Console.WriteLine($"{CurrentPlayer.Name} fought bravely against the mighty dragon, but its power proved overwhelming.");
            Console.WriteLine($"As the final moments unfold, {CurrentPlayer.Name}'s thoughts linger on his beloved wife.");
            Console.WriteLine("A valiant effort, though fate had other plans for this brave adventurer.");
        }
    }

    private void LoadArea()
    {
        _areas[0] = new Town("Meadowbrook", _input);
        _areas[1] = new Ruins("Ravenrock Ruins", _input);
        _areas[2] = new Lagoon("Lavender Lagoon", _input);
        _areas[3] = new Woods("Whispering Woods", _input);
        _areas[4] = new Mountains("Mystic Mountains", _input);
    
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
