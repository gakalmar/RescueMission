namespace MightyTextAdventure.Data.Places;

public class Ruins : Area
{
    public override void Interaction()
    {
        Console.WriteLine("Ruins functionality started");
    }

    public Ruins(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}