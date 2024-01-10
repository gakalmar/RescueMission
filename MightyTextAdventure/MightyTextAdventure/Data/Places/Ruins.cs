namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Ruins : Area
{
    public override void Interaction(Player player, Game game)
{
    if (player.Inventory.Contains("Sword of Mirage"))
    {
        Console.WriteLine("You've already explored these desert ruins. Let's return to the town! Don't waste your time");
        player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
    }
    else
    {
        Console.WriteLine($"The Desert Ruins sprawl before {player.Name}, ancient remnants sculpted by time and winds.");
        Console.WriteLine($"Whispers of forgotten tales linger in the air as golden sand dunes embrace crumbling structures beneath the relentless desert sun.");
        Console.WriteLine($"A mystical jinn materializes before {player.Name}.");
        Console.ReadLine();
        Console.WriteLine($"He is asking {player.Name} the following riddle:");
        Console.ReadLine();
        Console.WriteLine("`In the heart of arid lands, under the sun's relentless blaze,\n" +
                          "I sway without breeze and echo without a sound.\n" +
                          "I can be glimpsed but never caught in your grasp,\n" +
                          "I shimmer with warmth and vanish at twilight's embrace.`");
        Console.ReadLine();
        Console.WriteLine("What am I?`");
        Console.WriteLine("[1] Mirage");
        Console.WriteLine("[2] Shadow");
        Console.WriteLine("[3] Zephyr");
        Console.WriteLine("[4] Dust Devil");

        int input = int.Parse(_input.GetInputFromUser(player));

        if (input == 1)
        {
            Console.WriteLine($"Congratulations, {player.Name}, that is the correct answer!");
            Console.ReadLine();
            Console.WriteLine("You earned the 'Sword of Mirage'!");
            Console.ReadLine();
            player.Inventory.Add("Sword of Mirage");
            Console.WriteLine("'Sword of Mirage' was added to your inventory!");
            Console.WriteLine("A great challenge is waiting for you, let's continue the journey!");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("That's not the right choice. You must keep searching for answers!");
            Console.WriteLine("*** The jinn dissipates into the swirling sands ***");
            Console.ReadLine();
        }
    }
}

    public Ruins(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}