﻿namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.Data.Player;
using MightyTextAdventure.UI;
using MightyTextAdventure.Data;

public class Mountains : Area
{
    public override void Interaction(Player player, Game game)
    {
        _display.PrintMessage($"Venturing into the mountains, {player.Name} hears an ominous roar,\n" +
                              $"{player.Name} will need 'everything what it takes' to face this monster!");
        _input.WaitForEnter();
        if (player.Inventory.Count == 3)
        {
            var rand = new Random();
            int dragonHp = 10;
            
            _display.PrintMessage($"You seem to have collected all the magical items in the game!\n" +
                                  $"Are you ready to face the dragon? [y/n]");
            string decision = _input.GetInputFromUser(player);

            while (decision != "y" && decision != "n")
            {
                _display.PrintSameLineMessage($"Please enter a valid answer: [y/n] ");
                decision = _input.GetInputFromUser(player);
            }

            if (decision == "n")
            {
                _display.PrintMessage($"You return to the safety of the town.");
                player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
                _input.WaitForEnter();
            }
            else
            {
                
                
    
                _display.PrintMessage($"{player.Name} stands before the mighty dragon, " +
                                      $"Casting a chilling shadow, it clutches {player.Name}'s wife in its formidable claws. " +
                                      $"{player.Name} is ready to save her!");
                _display.PrintMessage($"The battle begins...");
                _display.AddSeparatorLine();
                _input.WaitForEnter();
    
                while (player.HealthPoints > 0 && dragonHp > 0)
                {
                    int playerAttack = rand.Next(1, 6);
                    dragonHp -= playerAttack;
    
                    _display.PrintMessage($"{player.Name} strikes at the dragon...");
                    _display.PrintMessage($"...dealing {playerAttack} damage.");
        
                    if (dragonHp <= 0)
                    {
                        _display.PrintMessage($"With a final strike, {player.Name} defeats the dragon!");
                    }
                    else
                    {
                        _display.PrintMessage($"The dragon has {dragonHp} HP remaining.");
                    }
    
                    _input.WaitForEnter();
    
                    if (dragonHp > 0)
                    {
                        int dragonAttack = rand.Next(2);
                        player.HealthPoints -= dragonAttack;
    
                        _display.PrintMessage($"The dragon retaliates...");
            
                        if (dragonAttack == 1)
                        {
                            _display.PrintMessage($"...and {player.Name} loses health.");
                        }
                        else
                        {
                            _display.PrintMessage($"...but the 'Woodland Ward Amulet' protected {player.Name} from the dragon's assault!");
                        }
    
                        _display.PrintMessage($"{player.Name} now has {player.HealthPoints} HP remaining.");
                        _input.WaitForEnter();
                    }
                }
                if (player.HealthPoints > 0)
                {
                    game.GameEnded = true;
                    game.SavedWife = true;
                    _display.AddSeparatorLine();
                }
                else
                {
                    game.GameEnded = true;
                    _display.PrintMessage($"The dragon's might proved overwhelming. {player.Name} has no more health.");
                    _input.WaitForEnter();
                }
            }
        }
        else
        {
            _display.PrintMessage($"You sense the dragon's presence but realize you're not prepared for this battle yet.");
            _display.PrintMessage($"Let's continue exploring to grow stronger!");
            _input.WaitForEnter();
            _display.PrintMessage($"You return to the safety of the town.");
            player.CurrentArea = player.CurrentArea.ConnectedAreas[0];
        }
    }

    public Mountains(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}