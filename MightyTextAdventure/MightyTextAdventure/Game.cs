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

    public void GoTo()
    { 
        Console.WriteLine($"Where do you want to go next?");
        foreach (var area in CurrentPlayer.CurrentArea.ConnectedAreas)
        { 
            Console.WriteLine($"{area.Description}");
        }
        string input = _input.GetInputFromUser();

        bool newAreaFound = false;
        
        foreach (var area in CurrentPlayer.CurrentArea.ConnectedAreas)
        { 
            if (area.Description.ToLower() == input.ToLower())
            {
                    CurrentPlayer.CurrentArea = area;
                    newAreaFound = true;
                    Console.WriteLine($"You went to the {CurrentPlayer.CurrentArea.Description}");
            }
        }

        if (!newAreaFound)
        {
            Console.WriteLine("Invalid location, please type again.");
            GoTo();
        }
        
        
        
    }

    private void LoadArea()
    {
        _areas[0] = new Area("Town");
        _areas[1] = new Area("Woods");
        _areas[2] = new Area("Lake");
        _areas[3] = new Area("Desert");
        _areas[4] = new Area("Mountain");
    
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
