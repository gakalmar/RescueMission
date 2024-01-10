using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.UI;

public class Input
{
    public Display _display = new Display();
    public string GetInputFromUser(Player player)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "h" || input.ToLower() == "help")
                {
                    PrintGameControls();
                }
                else if (input.ToLower() == "i")
                {
                    CheckInventory(player);
                }
                else
                {
                    return input;
                }
            }
        } 
    private void PrintGameControls()
    {
        _display.AddSeparatorLine();
        _display.PrintMessage($"Game Controls:");
        _display.PrintMessage($"- Enter the corresponding number to make a choice.");
        _display.PrintMessage($"- Type 'i' to check your inventory.");
        _display.PrintMessage($"- Type 'h' or 'help' to display this help message.");
    }

    private void CheckInventory(Player player)
    {
        if (player.Inventory.Count > 0)
        {
            _display.AddSeparatorLine();
            _display.PrintMessage($"You have the following items in your bag:");
            foreach (var item in player.Inventory)
            {
                _display.PrintMessage($"- {item}");
            }
        }
        else
        {
            _display.PrintMessage($"Your bag is empty.");
        }
    }
}
