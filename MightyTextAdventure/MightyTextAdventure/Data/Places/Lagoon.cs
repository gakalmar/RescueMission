namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Lagoon : Area
{
    public override void Interaction(Player player, Game game)
    {
        if (player.Inventory.Contains("Pearl of Wisdom"))
        {
            _display.PrintMessage($"{player.Name}, you've already explored this serene lagoon. Let's return to the bustling town!");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
            Console.ReadLine();
        }
        else
        {
            _display.PrintMessage($"{player.Name} stands at the edge of Lavender Lagoon, where tranquil waters mirror the setting sun's hues.");
            _display.PrintMessage($"The lavender coloured sky paints the water, and dragonflies add to the enchantment.");
            _display.PrintMessage($"A water sprite appears in front of {player.Name}");
            Console.ReadLine();
            _display.PrintMessage($"The water sprite poses a riddle for you to ponder:");
            Console.ReadLine();
            _display.PrintMessage($"`In quiet ponds or oceans deep,\n" +
                                  "My presence felt in waters' sweep.\n" +
                                  "A subtle pulse, a gentle sway,\n" +
                                  "A liquid dance in light of day.`");
            Console.ReadLine();
            _display.PrintMessage($"What am I?");
            _display.PrintMessage($"[1] Moonbeam");
            _display.PrintMessage($"[2] Ripple");
            _display.PrintMessage($"[3] Seashell");
            _display.PrintMessage($"[4] Misty Veil");

            string userInput;
            do
            {
                userInput = _input.GetInputFromUser(player);
                if(!int.TryParse(userInput, out int noInput))
                {
                    _display.PrintMessage($"{userInput} is not a valid choice. Please pick a number from the list!");
                }
            } while (!int.TryParse(userInput, out int reInput));
            
            int input = int.Parse(userInput);
            
            if (input == 2)
            {
                _display.PrintMessage($"Congratulations, {player.Name}, that's the correct answer!");
                Console.ReadLine();
                _display.PrintMessage($"{player.Name} has earned the 'Seashell of Wisdom'!");
                Console.ReadLine();
                player.Inventory.Add("Seashell of Wisdom");
                _display.PrintMessage($"'Seashell of Wisdom' has been added to {player.Name}'s inventory!");
                Console.ReadLine();
            }
            else
            {
                _display.PrintMessage($"Alas, {player.Name}, the waves of truth elude us. That wasn't the answer dancing upon the water's surface.");
                _display.PrintMessage($"*** The water sprite gracefully disappears into the lagoon ***");
                Console.ReadLine();
            }
        }
    }


    public Lagoon(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}