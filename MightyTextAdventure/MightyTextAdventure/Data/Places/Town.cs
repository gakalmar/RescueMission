namespace MightyTextAdventure.Data.Places;

public class Town : Area
{
    public override void Interaction()
    {
        Console.WriteLine("Town functionality started");
    }

    public Town(string description)
    {
        Description = description;
        ConnectedAreas = new List<Area>();
    }
}