namespace CSharp__Codingtracker
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Coding Tracker!");
            Console.WriteLine("------------------------------");

            var repository = new CodingSessionRepository();
            repository.InitializeDatabase();

            var controller = new CodingController();
            controller.ShowMenu();

        }
    }
}
