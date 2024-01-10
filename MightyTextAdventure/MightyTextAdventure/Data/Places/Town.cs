namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Town : Area
{
    public override void Interaction(Player player, Game game)
    {
        _display.PrintMessage($"You're back in {player.CurrentArea.Description}. " +
                              $"What would you like to do now?");
        _display.PrintMessage($"[1] Sleep");
        _display.PrintMessage($"[2] Go to pub");
        _display.PrintMessage($"[3] Eat");
        
        int input = int.Parse(_input.GetInputFromUser(player));

        switch (input)
        {
            case 1:
                _display.AddSeparatorLine();
                _display.PrintMessage($"You had a good rest. You had a dream about dragons.");
                Console.ReadLine();
                _display.AddSeparatorLine();
                break; 
            case 2:
                _display.AddSeparatorLine();
                _display.PrintMessage($"New record: 8 beers! Wow!");
                Console.ReadLine();
                _display.AddSeparatorLine();
                break;
            case 3:
                _display.AddSeparatorLine();
                _display.PrintMessage($"You had 'Grilled Lizard'. It was a bit chewy."  );
                Console.ReadLine();
                _display.AddSeparatorLine();
                break;
            default:
                break;
        }
        
        
    }

    public Town(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}