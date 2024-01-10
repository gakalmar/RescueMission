using MightyTextAdventure.Data.Player;

namespace MightyTextAdventure.UI;

public class Input
{
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
        Console.WriteLine("Game Controls:");
        Console.WriteLine("- Enter the corresponding number to make a choice.");
        Console.WriteLine("- Type 'i' to check your inventory.");
        Console.WriteLine("- Type 'h' or 'help' to display this help message.");
        //Console.WriteLine("- Press 'Enter' to go back to choices!");

    }

    private void CheckInventory(Player player)
    {
        if (player.Inventory.Count > 0)
        {
            Console.WriteLine("You have the following items in your bag:");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
        else
        {
            Console.WriteLine("Your bag is empty.");
            //Console.WriteLine("- Press 'Enter' to go back to choices!");
        }
    }
}
