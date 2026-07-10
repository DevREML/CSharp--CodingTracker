
namespace CSharp__Codingtracker
{
    public class UserInput
    {
        private readonly Validation _validation;

        public UserInput()
        {
            _validation = new Validation();
        }
        
        // General method for dateTime input.
        public DateTime GetDateTimeInput(string promptLabel)
        {
            while (true)
            {
                Console.WriteLine($"Voer de {promptLabel} in (formaat: dd-MM-yyyy HH:mm):");
                string dateTimeInput = Console.ReadLine()!;
                
                // validation 
                bool succes = _validation.TryValidateDateTime(dateTimeInput, out DateTime result);
                
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