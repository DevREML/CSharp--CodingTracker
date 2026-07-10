using System.Globalization;

namespace CSharp__Codingtracker
{
    public class Validation
    {
        public bool TryValidateDateTime(string dateTimeInput, out DateTime result)
        {
            bool success = DateTime.TryParseExact(
                dateTimeInput,
                "dd-MM-yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result
            );
            return success;
        }
    }
}