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

    public Game()
    {
        _areas = new Area[5];
        _input = new Input();
        _display = new Display();
    }

    public void Init()
    {
        LoadArea();
        CurrentPlayer = CreatePlayer();
        Console.WriteLine($"{CurrentPlayer.Name} was created!");
        Console.WriteLine(CurrentPlayer.Description);
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
            Travel();
        }
        
        // foreach (var area in CurrentPlayer.CurrentArea.ConnectedAreas)
        // { 
        //     if (area.Description.ToLower() == input.ToLower())
        //     {
        //             CurrentPlayer.CurrentArea = area;
        //             newAreaFound = true;
        //             Console.WriteLine($"You went to the {CurrentPlayer.CurrentArea.Description}");
        //     }
        // }
        //
        // if (!newAreaFound)
        // {
        //     Console.WriteLine("Invalid location, please type again.");
        //     Travel();
        // }
    }

    private void LoadArea()
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
        
        // Console.WriteLine(_areas[1].Description);
        // _areas[0].Interaction();
        // _areas[1].Interaction();
        // _areas[2].Interaction();
        // _areas[3].Interaction();
        // _areas[4].Interaction();
        
    }
    
}
