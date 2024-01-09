namespace MightyTextAdventure.Data.Places;

public abstract class Area
{
    public string Description { get; set; }
    public List<Area> ConnectedAreas { get; set; }

    public virtual void Interaction()
    {
    }

    public Area()
    {
    }
}
