namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;
using MightyTextAdventure.Data;

public class Mountains : Area
{
    public override void Interaction(Player player, Game game)
    {
        Console.WriteLine($"Venturing into the mountains, {player.Name} hears an ominous roar ,\n" +
                          $"{player.Name} will need 'everything what it takes' to face this monster!");
        Console.ReadLine(); 
        if (player.Inventory.Count == 3)
            {
                var rand = new Random();
                int dragonHp = 10;

                Console.WriteLine($"{player.Name} stands before the mighty dragon, " +
                                  $"Casting a chilling shadow, it clutches {player.Name}'s wife in its formidable claws." +
                                  $"{player.Name} is ready to save her!");
                Console.WriteLine("The battle begins...");

                while (player.HealthPoints > 0 && dragonHp > 0)
                {
                    int playerAttack = rand.Next(1, 6);
                    dragonHp -= playerAttack;

                    Console.WriteLine($"{player.Name} strikes at the dragon...");
                    Console.WriteLine($"...dealing {playerAttack} damage.");
        
                    if (dragonHp <= 0)
                    {
                        Console.WriteLine("The dragon has been defeated!");
                    }
                    else
                    {
                        Console.WriteLine($"The dragon has {dragonHp} HP remaining.");
                    }

                    Console.ReadLine();

                    if (dragonHp > 0)
                    {
                        int dragonAttack = rand.Next(2);
                        player.HealthPoints -= dragonAttack;

                        Console.WriteLine("The dragon retaliates...");
            
                        if (dragonAttack == 1)
                        {
                            Console.WriteLine($"...and {player.Name} loses health.");
                        }
                        else
                        {
                            Console.WriteLine($"The amulet protected {player.Name} from the dragon's assault!");
                        }

                        Console.WriteLine($"{player.Name} now has {player.Name} HP remaining.");
                        Console.ReadLine();
                    }
                if (player.HealthPoints > 0)
                {
                    game.GameEnded = true;
                    game.SavedWife = true;
                    Console.WriteLine($"With a final strike, {player.Name} defeats the dragon!");
                }
                else
                {
                    game.GameEnded = true;
                    Console.WriteLine($"The dragon's might proved overwhelming. {player.Name} has no more health.");
                }
                }
                
                if (player.HealthPoints > 0)
                {
                    game.GameEnded = true;
                    game.SavedWife = true;
                }
                else
                {
                    game.GameEnded = true;
                }
            }
        else
        {
            Console.WriteLine("You sense the dragon's presence but realize you're not prepared for this battle yet.");
            Console.WriteLine("Let's continue exploring to grow stronger!");
            Console.ReadLine();
            Console.WriteLine("You return to the safety of the town.");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
        }
    }

    public Mountains(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}