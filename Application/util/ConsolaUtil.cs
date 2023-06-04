namespace Application.util;

public class ConsolaUtil
{
    public static T GetConsoleLine<T>(string message)
    {
        Console.WriteLine(message);

        string lineaDeConsola = Console.ReadLine();
        
        if (typeof(T) == typeof(int))
        {
            return (T) (object) Int64.Parse(lineaDeConsola);
        }
        else
        {
            return (T) (object) lineaDeConsola;
        }
    }
}