namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Woods : Area
{
    public override void Interaction(Player player, Game game)
    {
        if (player.Inventory.Contains( "Woodland Ward Amulet"))
        {
            _display.PrintMessage($"You already explored this area. Let's go back to town!");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
            _input.WaitForEnter();
        }
        else
        {
            _display.PrintMessage($"{player.Name} steps into the heart of the Whispering Woods, " +
                                  $"where ancient trees stand sentinel in a dance of shadows.");
            _display.PrintMessage($"Soft murmurs rustle through the leaves, creating an enchanted" +
                                  $" melody as {player.Name} explores this mystical and serene woodland.");
            _display.PrintMessage($"Amidst the woodland glade, you encounter a playful fairy, " +
                                  "gracefully dwelling in the heart of the woods.");
            _input.WaitForEnter();
            _display.PrintMessage($"She suddenly appears in front of you and asks you the following riddle:");
            _input.WaitForEnter();
            _display.PrintMessage($"`In the heart of the woods, under the moon's pale gaze,\n" +
                                  "I dance without feet and sing without a voice.\n" +
                                  "I can be captured but never held in your hands,\n" +
                                  "I flicker with joy and vanish at dawn's first light.`");
            _input.WaitForEnter();
            _display.PrintMessage($"What am I?`");
            _display.PrintMessage($"[1] Starlight");
            _display.PrintMessage($"[2] Wind");
            _display.PrintMessage($"[3] Shadow");
            _display.PrintMessage($"[4] Mist");
            
            // Check if input is a number:
            int input;
            if (_input.CheckIfNumber(player, out int parsedNum));
            {
                input = parsedNum;
            }
            
            // Correct answer:
            if (input == 3)
            {
                _display.PrintMessage($"Congratulations, that is the correct answer!");
                _input.WaitForEnter();
                _display.PrintMessage($"You earned this 'Woodland Ward Amulet'!");
                _input.WaitForEnter();
                player.Inventory.Add( "Woodland Ward Amulet");
                _display.PrintMessage($"'Woodland Ward Amulet' was added to your inventory!");
                _input.WaitForEnter();
            }
            else if (input == 1 || input == 2 || input == 4)
            {
                _display.PrintMessage($"Ah, my dear traveler, that's not the answer that flutters through the enchanted glades!");
                _display.PrintMessage($"*** The fairy dissolves into the whispers of the ancient trees.***");
                _input.WaitForEnter();
            }
            else
            {
                _display.PrintMessage($"Ah, my dear traveler, you missed your opportunity to answer correctly!");
                _display.PrintMessage($"*** The fairy dissolves into the whispers of the ancient trees.***");
                _input.WaitForEnter();
            }
        }
    }

    public Woods(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}