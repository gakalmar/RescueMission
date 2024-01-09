namespace MightyTextAdventure.Data.Places;

public class Lagoon : Area
{
    public override void Interaction()
    {
        Console.WriteLine("Lagoon functionality started");
    }

    public Lagoon(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}