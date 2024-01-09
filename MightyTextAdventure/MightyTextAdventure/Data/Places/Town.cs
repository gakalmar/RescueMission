namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;

public class Town : Area
{
    public override void Interaction(Player player, Game game)
    {
        Console.WriteLine($"You're back in {player.CurrentArea.Description}." +
                          $"\nWhat would you like to do now?");
        Console.WriteLine("[1] Sleep");
        Console.WriteLine("[2] Go to pub");
        Console.WriteLine("[3] Eat");
        
        int input = int.Parse(_input.GetInputFromUser());

        switch (input)
        {
            case 1:
                Console.WriteLine("You had a good rest. You had a dream about dragons.");
                break; 
            case 2:
                Console.WriteLine("New record: 8 beers! Wow!");
                break;
            case 3:
                Console.WriteLine("You had 'Grilled Lizard'. It was a bit chewy."  );
                break;
        }
        
        
    }

    public Town(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}