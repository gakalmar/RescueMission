namespace MightyTextAdventure.Data.Player;
using MightyTextAdventure.Data.Places;
public class Player
{
    public string Name { get; }
    public string[] Inventory { get; set; }
    public Area Area { get; set; }
    
    public string Description { get; set; }

    public Player(string name, Area area )
    {
        Name = name;
        Inventory = new string[3];
        Area = area;
        Description = $"{name}, the hero of our story.";
    }
    public override string ToString()
    {
        return Description;
    }
}