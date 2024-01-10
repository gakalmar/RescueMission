namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Lagoon : Area
{
    public override void Interaction(Player player, Game game)
{
    if (player.Inventory.Contains("Pearl of Wisdom"))
    {
        Console.WriteLine($"{player.Name}, you've already explored this serene lagoon. Let's return to the bustling town!");
        player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine($"{player.Name} stands at the edge of Lavender Lagoon, where tranquil waters mirror the setting sun's hues.");
        Console.WriteLine($"The lavender coloured sky paints the water, and dragonflies add to the enchantment.");
        Console.WriteLine($"A water sprite appears in front of {player.Name}");
        Console.ReadLine();
        Console.WriteLine($"The water sprite poses a riddle for you to ponder:");
        Console.ReadLine();
        Console.WriteLine("`In quiet ponds or oceans deep,\n" +
                          "My presence felt in waters' sweep.\n" +
                          "A subtle pulse, a gentle sway,\n" +
                          "A liquid dance in light of day.`");
        Console.ReadLine();
        Console.WriteLine("What am I?");
        Console.WriteLine("[1] Moonbeam");
        Console.WriteLine("[2] Ripple");
        Console.WriteLine("[3] Seashell");
        Console.WriteLine("[4] Misty Veil");

        int input = int.Parse(_input.GetInputFromUser(player));

        if (input == 2)
        {
            Console.WriteLine($"Congratulations, {player.Name}, that's the correct answer!");
            Console.ReadLine();
            Console.WriteLine($"{player.Name} has earned the 'Seashell of Wisdom'!");
            Console.ReadLine();
            player.Inventory.Add("Pearl of Wisdom");
            Console.WriteLine($"'Pearl of Wisdom' has been added to {player.Name}'s inventory!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine($"Alas, {player.Name}, the waves of truth elude us. That wasn't the answer dancing upon the water's surface.");
            Console.WriteLine("*** The water sprite gracefully disappears into the lagoon ***");
            Console.ReadLine();
        }
    }
}


    public Lagoon(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}