namespace Application.util;

public class ConsolaUtil
{
    public static T GetConsoleLine<T>(string message)
    {
        Console.WriteLine(message);

        string lineaDeConsola = Console.ReadLine();
        
        if (typeof(T) == typeof(int))
        {
            return (T) (object) System.Int32.Parse(lineaDeConsola);
        } 
        else if (typeof(T) == typeof(double))
        {
            return (T)(object)Double.Parse(lineaDeConsola);
        }
        else
        {
            return (T) (object) lineaDeConsola;
        }
    }
}