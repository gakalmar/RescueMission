namespace MightyTextAdventure.Data.Player;
using MightyTextAdventure.Data.Places;
public class Player
{
    public string Name { get; }
    public List<string> Inventory { get; set; }
    public Area CurrentArea { get; set; }
    public string Description { get; set; }

    public Player(string name, Area currentArea )
    {
        Name = name;
        Inventory = new List<string> ();
        CurrentArea = currentArea;
        Description = $"{name}, the hero of our story.";
    }
    public override string ToString()
    {
        return Description;
    }
}