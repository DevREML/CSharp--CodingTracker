using System.Globalization;

namespace CSharp__Codingtracker
{
    public class UserInput
    {
        // General method for dateTime input.
        public DateTime GetDateTimeInput(string promptLabel)
        {
            while (true)
            {
                Console.WriteLine($"Voer de {promptLabel} in (formaat: dd-MM-yyyy HH:mm):");
                string dateTimeInput = Console.ReadLine();
                
                // validation 

                bool succes = DateTime.TryParseExact(
                    dateTimeInput,
                    "dd-MM-yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime result
                );
                if (succes)
                    {
                    return result;
                    }
                else
                {
                    Console.WriteLine("Ongeldig formaat. Probeer het opnieuw.");
                }
            }
        }
    }
}