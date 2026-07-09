
namespace CSharp__Codingtracker
{
    public class CodingController
    {
        private readonly UserInput _userInput;
        private readonly CodingSessionRepository _codingSessionRepository;

        public CodingController()
        {
            _userInput = new UserInput();
            _codingSessionRepository = new CodingSessionRepository();
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
    }
}