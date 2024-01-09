namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.UI;
using MightyTextAdventure.Data.Player;

public abstract class Area
{
    public string Description { get; set; }
    public List<Area> ConnectedAreas { get; set; }
    public Input _input;

    public virtual void Interaction(Player player)
    {
    }

    public Area()
    {
    }
}
