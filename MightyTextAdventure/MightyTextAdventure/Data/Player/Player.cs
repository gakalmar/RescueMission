namespace MightyTextAdventure.Data.Player;
using MightyTextAdventure.Data.Places;
public class Player
{
    public string Name { get; }
    public string[] Inventory { get; set; }
    public Area Area { get; set; }

    public Player(string name, Area area )
    {
        Name = name;
        Inventory = new string[3];
        Area = area;
    }
}