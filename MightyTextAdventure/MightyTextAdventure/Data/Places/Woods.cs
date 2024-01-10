namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Woods : Area
{
    public override void Interaction(Player player, Game game)
    {
        if (player.Inventory.Contains( "Woodland Ward Amulet"))
        {
            Console.WriteLine("You already explored this area. Let's go back to town!");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
        }
        else
        {
            Console.WriteLine($"{player.Name} steps into the heart of the Whispering Woods, " +
                              $"where ancient trees stand sentinel in a dance of shadows.");
            Console.WriteLine($"Soft murmurs rustle through the leaves, creating an enchanted" +
                              $" melody as {player.Name} explores this mystical and serene woodland.");
            Console.WriteLine("Amidst the woodland glade, you encounter a playful fairy, " +
                              "gracefully dwelling in the heart of the woods.");
            Console.ReadLine();
            Console.WriteLine("She suddenly appears in front of you and asks you the following riddle:");
            Console.ReadLine();
            Console.WriteLine("`In the heart of the woods, under the moon's pale gaze,\n" +
                              "I dance without feet and sing without a voice.\n" +
                              "I can be captured but never held in your hands,\n" +
                              "I flicker with joy and vanish at dawn's first light.`");
            Console.ReadLine();
            Console.WriteLine("What am I?`");
            Console.WriteLine("[1] Starlight");
            Console.WriteLine("[2] Shadow");
            Console.WriteLine("[3] Wind");
            Console.WriteLine("[4] Mist");

            int input = int.Parse(_input.GetInputFromUser(player));

            if (input == 2)
            {
                Console.WriteLine("Congratulations, that is the correct answer!");
                Console.ReadLine();
                Console.WriteLine("You earned this 'Woodland Ward Amulet'!");
                Console.ReadLine();
                player.Inventory.Add( "Woodland Ward Amulet");
                Console.WriteLine("'Woodland Ward Amulet' was added to your inventory!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ah, my dear traveler, that's not the answer that flutters through the enchanted glades!");
                Console.WriteLine("*** The fairy dissolves into the whispers of the ancient trees.***");
                Console.ReadLine();
            }
        }
    }

    public Woods(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}