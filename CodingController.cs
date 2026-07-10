
namespace CSharp__Codingtracker
{
    public class CodingController
    {
        private readonly UserInput _userInput;
        private readonly CodingSessionRepository _codingSessionRepository;
        private readonly PresentData _presentData;

        public CodingController()
        {
            _userInput = new UserInput();
            _codingSessionRepository = new CodingSessionRepository();
            _presentData = new PresentData();
        }

        public void LogSession()
        {
            DateTime startTime = _userInput.GetDateTimeInput("starttijd");
            DateTime endTime = _userInput.GetDateTimeInput("eindtijd");
            TimeSpan duration = endTime - startTime;

            var session = new CodingSession
            {
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration
            };
            
            _codingSessionRepository.InsertInput(session);
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("Kies een optie:");
                Console.WriteLine("1.Log een nieuwe sessie.\n" +
                                  "2.Toon alle sessies\n" +
                                  "3.Update een sessie\n" +
                                  "4.Verwijder een sessie\n" +
                                  "5. Afsluiten");
                
                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        LogSession();
                        break;
                    case 2:
                        var showDataSession = _codingSessionRepository.RetrieveData();
                        _presentData.DisplaySessions(showDataSession);
                        break;
                    case 3: // Update a session 
                        
                        var updateSession = _codingSessionRepository.RetrieveData();
                        _presentData.DisplaySessions(updateSession);
                        
                        Console.WriteLine("Voer het Id in van de sessie die je wilt updaten:");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        DateTime updatedStartTime = _userInput.GetDateTimeInput("starttijd"); // new value starttime
                        DateTime updatedEndTime = _userInput.GetDateTimeInput("eindtijd");    // new value endtime 

                        var updatedSession = new CodingSession()
                        {
                            Id = updateId,
                            StartTime = updatedStartTime,
                            EndTime = updatedEndTime,
                            Duration = updatedEndTime - updatedStartTime
                        };
                        _codingSessionRepository.UpdateInput(updatedSession);
                        break;
                    case 4: // Delete a session
                        var deleteSession = _codingSessionRepository.RetrieveData();
                        _presentData.DisplaySessions(deleteSession);
                        
                        Console.WriteLine("Voer het Id in van de sessie die je wilt verwijderen:");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        _codingSessionRepository.DeleteInput(deleteId);
                        break;
                    case 5: // Exit
                        Console.WriteLine("Tot ziens!");
                        return;
                    default:
                        Console.WriteLine("Ongeldige invoer: Selecteer een van de opties.");
                        break;
                }
                
            }
        }
    }
}