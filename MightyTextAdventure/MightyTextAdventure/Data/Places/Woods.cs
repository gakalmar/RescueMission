namespace MightyTextAdventure.Data.Places;

public class Woods : Area
{
    public override void Interaction()
    {
        Console.WriteLine("Woods functionality started");
    }

    public Woods(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}