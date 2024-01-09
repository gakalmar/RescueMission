namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;
using MightyTextAdventure.Data;

public class Mountains : Area
{
    public override void Interaction(Player player, Game game)
    {
        Console.WriteLine("You encountered a huge dragon who kidnapped your wife." +
                          "\nYou must defeat him to save her.");
        Console.ReadLine();
        if (player.Inventory.Count == 3)
        {
            var rand = new Random();
            int dragonHp = 10;
            while (player.HealthPoints > 0 && dragonHp > 0)
            {
                int playerAttack = rand.Next(1,6);
                dragonHp -= playerAttack;
                Console.WriteLine("You attack the dragon...");
                Console.WriteLine($"...and caused {playerAttack} damage");
                if (dragonHp < 0)
                {
                    Console.WriteLine("The dragon has 0 HP left.");
                }
                else
                {
                    Console.WriteLine($"The dragon has {dragonHp} HP left.");
                }

                Console.ReadLine();
                if (dragonHp > 0)
                {
                    int dragonAttack = rand.Next(2);
                    player.HealthPoints -= dragonAttack;
                    Console.WriteLine("The dragon fights back...");
                    if (dragonAttack == 1)
                    {
                        Console.WriteLine($"...and you lost health");
                    }
                    else
                    {
                        Console.WriteLine("Your amulet seems to have protected you.");
                    }
                    Console.WriteLine($"You have {player.HealthPoints} HP left.");
                    Console.ReadLine();
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
            Console.WriteLine("You're not prepared for this fight yet." +
                              "\nLet's keep exploring to get stronger!");
            Console.ReadLine();
            Console.WriteLine("You go back to the town.");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
        }
            
            
        //int input = int.Parse(_input.GetInputFromUser());
        
        
    }

    public Mountains(string description, Input input)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
        _input = input;
    }
}