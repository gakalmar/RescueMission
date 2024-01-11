using MightyTextAdventure;
using MightyTextAdventure.UI;

Display _display = new Display();

_display.AddSeparatorLine();
_display.PrintMessage($"Rescue Mission is Starting!");
_display.AddSeparatorLine();

var game = new Game();

game.Init();
while (game.GameEnded == false)
{
    game.Travel();
    game.Interact(game.CurrentPlayer, game);
}
game.HandleGameEnd();

_display.AddSeparatorLine();
_display.PrintMessage($"Rescue Mission Ended!");
_display.AddSeparatorLine();