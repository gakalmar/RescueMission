using MightyTextAdventure;
using MightyTextAdventure.Data.Player;

Console.WriteLine("Starting Mighty Text Adventure!");

var game = new Game();

game.Init();
while (game.GameEnded == false)
{
    game.Travel();
    game.Interact(game.CurrentPlayer, game);
}
game.HandleGameEnd();

Console.WriteLine("Exiting from Mighty Text Adventure!");
