using MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

namespace MightyTextAdventure;

public class Game
{
    private readonly Area[] _areas;

    private readonly Input _input;
    private readonly Display _display;
    
    

    public Game()
    {
        _areas = new Area[5];
        _input = new Input();
        _display = new Display();
    }

    public void Init()
    {
        LoadArea();
        CreatePlayer();
        _display.PrintMessage("Start Area");
    }
    
    //create player
    public void CreatePlayer()
    {
        Console.Write("Enter the name of your hero: ");
        Player player = new Player(_input.GetInputFromUser(), _areas[0]);
        Console.WriteLine($"{player.Name} was created!");
    }

    public void GoTo()
    {
        
    }

    private void LoadArea()
    {
        _areas[0] = new Area("Town");
        _areas[1] = new Area("Woods");
        _areas[2] = new Area("Lake");
        _areas[3] = new Area("Desert");
        _areas[4] = new Area("Mountain");

        Area starterArea = _areas[0]; //connected to 4 areas, chose area togo, character creation only for the first time, back after fights for item
        // common areas => chose to fight or go back to town after win area empty connected to town//

    }
    
}
