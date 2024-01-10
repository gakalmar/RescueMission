namespace MightyTextAdventure.UI;

public class Display
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void PrintSameLineMessage(string message)
    {
        Console.WriteLine(message);
    }
    

    public void AddSeparatorLine()
    {
        Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * *");
    }
}
