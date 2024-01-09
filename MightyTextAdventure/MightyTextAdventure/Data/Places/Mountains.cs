namespace MightyTextAdventure.Data.Places;

public class Mountains : Area
{
    public override void Interaction()
    {
        Console.WriteLine("Mountains functionality started");
    }

    public Mountains(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}