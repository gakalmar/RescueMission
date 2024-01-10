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

        string userInput;
        do
        {
            userInput = _input.GetInputFromUser(player);
            if(!int.TryParse(userInput, out int noInput) || noInput > 3 || noInput < 1)
            {
                _display.PrintMessage($"{userInput} is not a valid choice. Please pick a number from the list!");
            }
        } while (!int.TryParse(userInput, out int reInput) || reInput > 3 || reInput < 1);
            
        int input = int.Parse(userInput);
        var rand = new Random();
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
                    _display.PrintMessage($"Suddenly you notice something odd in the air...");
                    Console.ReadLine();
                    _display.PrintMessage($"You're wondering...Maybe it's the beer? Then suddenly... ");
                    Console.ReadLine();
                    _display.PrintMessage($"...a quiet stranger approaches you.");
                    _display.PrintMessage($"He murmurs something strange into your ear.");
                    Console.ReadLine();
                    _display.PrintMessage($"You sober up in a second and listen carefully:");
                    Console.ReadLine();
                    if (player.Inventory.Count == 3)
                    {
                        _display.PrintMessage("In peaks so high where eagles soar," +
                                              "\nWaits for you a mighty roar." +
                                              "\nYour sword seeking fight," +
                                              "\nBut true love seeks more.");
                    }
                    _display.PrintMessage($"{HintsFromStranger(rand.Next(3))}");
                    Console.ReadLine();
                    _display.AddSeparatorLine();
                    break;
                case 3:
                    _display.AddSeparatorLine();
                    _display.PrintMessage($"You had '{RandomFood(rand.Next(7))}'. It was delicious.");
                    Console.ReadLine();
                    _display.AddSeparatorLine();
                    break;
            }
    }
    public string HintsFromStranger(int index)
    {
        List<string> hintList = new List<string>
        {
            "In green shadows, where secrets abide, ancient knowledge guarded, nowhere to hide. Seek it out, and in its glow confide, protection found where truths coincide.",
            "You might travel far and wide, but between sand grains you can't hide. With pure heart show yourself there, so you can fight!",
            "Ocean of secrets, without shores, meets that, which only for the brave shows: you shall walk there for the treasure of your hopes."
        };
        return hintList[index];
    }
    
    public string RandomFood(int index)
    {
        List<string> menu = new List<string>
        {"Grilled Lizard", "Excited Octopus", "Crab And Mushroom", "Frozen Fishsoup", "Meat", "Lazy Frog"};
        return menu[index];
    }
    public Town(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}