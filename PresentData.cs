using Spectre.Console;

namespace CSharp__Codingtracker
{
   public class PresentData
   {
      public void DisplaySessions(List<CodingSession> sessions)
      {
         var table = new Table();
         
         // adding columns
         table.AddColumn("ID");
         table.AddColumn("StartTime");
         table.AddColumn("EndTime");
         table.AddColumn("Duration");

         foreach (var session in sessions)
         {
            table.AddRow(session.Id.ToString(), session.StartTime.ToString(), session.EndTime.ToString(),  session.Duration.ToString());
         }
         AnsiConsole.Write(table);
      }
   }
}