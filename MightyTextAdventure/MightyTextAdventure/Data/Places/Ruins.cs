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
            _input.WaitForEnter();
        }
        else
        {
            _display.PrintMessage($"The Desert Ruins sprawl before {player.Name}, ancient remnants sculpted by time and winds.");
            _display.PrintMessage($"Whispers of forgotten tales linger in the air as golden sand dunes embrace crumbling structures beneath the relentless desert sun.");
            _display.PrintMessage($"A mystical jinn materializes before {player.Name}.");
            _input.WaitForEnter();
            _display.PrintMessage($"He is asking {player.Name} the following riddle:");
            _input.WaitForEnter();
            _display.PrintMessage($"`In the heart of arid lands, under the sun's relentless blaze,\n" +
                                  "I sway without breeze and echo without a sound.\n" +
                                  "I can be glimpsed but never caught in your grasp,\n" +
                                  "I shimmer with warmth and vanish at twilight's embrace.`");
            _input.WaitForEnter();
            _display.PrintMessage($"What am I?`");
            _display.PrintMessage($"[1] Mirage");
            _display.PrintMessage($"[2] Shadow");
            _display.PrintMessage($"[3] Zephyr");
            _display.PrintMessage($"[4] Dust Devil");
    
            // Check if input is a number:
            int input;
            if (_input.CheckIfNumber(player, out int parsedNum));
            {
                input = parsedNum;
            }
            
            // Correct answer:
            if (input == 1)
            {
                _display.PrintMessage($"Congratulations, {player.Name}, that is the correct answer!");
                _input.WaitForEnter();
                _display.PrintMessage($"You earned the 'Sword of Mirage'!");
                _input.WaitForEnter();
                player.Inventory.Add("Sword of Mirage");
                _display.PrintMessage($"'Sword of Mirage' was added to your inventory!");
                _display.PrintMessage($"A great challenge is waiting for you, let's continue the journey!");
                _input.WaitForEnter();
            }
            else if (input == 2 || input == 3 || input == 4)
            {
                _display.PrintMessage($"That's not the right choice. You must keep searching for answers!");
                _display.PrintMessage($"*** The jinn dissipates into the swirling sands ***");
                _input.WaitForEnter();
            }
            else
            {
                _display.PrintMessage($"Ah, my dear traveler, you missed your opportunity to answer correctly!");
                _display.PrintMessage($"*** The jinn dissipates into the swirling sands ***");
                _input.WaitForEnter();
            }
        }
    }

    public Ruins(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}