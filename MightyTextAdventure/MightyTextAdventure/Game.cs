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

    public Game()
    {
        _areas = new Area[5];
        _input = new Input();
        _display = new Display();
        GameEnded = false;
    }

    public void Init()
    {
        LoadArea();
        CurrentPlayer = CreatePlayer();
        Console.WriteLine($"{CurrentPlayer.Name} was created!");
        Console.ReadLine();
        Console.WriteLine(CurrentPlayer.Description);       // Update and add it to intro text
        Console.ReadLine();
        _display.PrintMessage("Start Area");
    }
    
    //create player
    public Player CreatePlayer()
    {
        Console.Write("Enter the name of your hero: ");
        Player player = new Player(_input.GetInputFromUser(), _areas[0]);
        return player;
    }

    public void Travel()
    { 
        Console.WriteLine($"Where do you want to go next?");
        for (int i = 0; i < CurrentPlayer.CurrentArea.ConnectedAreas.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {CurrentPlayer.CurrentArea.ConnectedAreas[i].Description}");
        }
        
        int input = int.Parse(_input.GetInputFromUser());

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

    public void Interact(Player player)
    {
        player.CurrentArea.Interaction(player);
        
        if (player.Inventory.Count > 0)
        {
            foreach (var item in player.Inventory)
            {
                Console.WriteLine(item);
            }
        }
    }

    public void HandleGameEnd()
    {
        // if won
        //      Do this
        // if lost
        //      Do this
    }

    private void LoadArea()
    {
        // Input inp = new Input();
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
