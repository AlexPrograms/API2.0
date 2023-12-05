namespace MagicVilla_VillaAPI.Logging;

public class LoggingV2 : ILogging
{
    public void Log(string message, string type)
    {
        if (type == "error")
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error - " + message);
            
        }
        else
        {
            if (type == "warning")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Error - " + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}