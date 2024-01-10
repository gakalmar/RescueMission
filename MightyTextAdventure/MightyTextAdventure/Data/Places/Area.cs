namespace MightyTextAdventure.Data.Places;
using MightyTextAdventure.UI;
using MightyTextAdventure.Data.Player;

public abstract class Area
{
    public Input _input;
    public Display _display;
    public string Description { get; set; }
    public List<Area> ConnectedAreas { get; set; }

    public virtual void Interaction(Player player, Game game)
    {
    }

    public Area()
    {
        _input = new Input();
        _display = new Display();
    }
}
