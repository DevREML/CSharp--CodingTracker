using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CSharp__Codingtracker

{
    public class CodingSessionRepository
    {
        private readonly string _connectionString;

        public CodingSessionRepository()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); 
            
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        // Making a table 
        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = """
                      CREATE TABLE IF NOT EXISTS CodingSessions (
                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                          StartTime TEXT NOT NULL,
                          EndTime TEXT NOT NULL,
                          Duration TEXT NOT NULL)
                      """;
            connection.Execute(sql);
        }

        // Save Session
        public void InsertInput(CodingSession codingSession)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = """
                      INSERT INTO CodingSessions (StartTime, EndTime, Duration)
                      VALUES (@StartTime, @EndTime, @Duration)
                      """;
            connection.Execute(sql, codingSession);
        }

        public List<CodingSession> RetrieveData()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM CodingSessions";
            return connection.Query<CodingSession>(sql).ToList();
        }

        public void DeleteInput(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "DELETE FROM CodingSessions WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }

        public void UpdateInput(CodingSession codingSession)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "UPDATE CodingSessions SET StartTime=@StartTime, EndTime=@EndTime, Duration=@Duration WHERE Id = @Id ";
            connection.Execute(sql, codingSession);
        }
    }
}