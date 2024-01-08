namespace MightyTextAdventure.Data.Places;

public class Area
{
    public string Description { get; }
    
    public List<Area> ConnectedAreas { get; set; }
    public void Interaction()
    {
        //solve puzzle , fight
    }

    public Area(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();

    }
}
