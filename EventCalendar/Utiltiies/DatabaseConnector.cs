using EventCalendar.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class DatabaseConnector
{
    // SQLite connection
    public SqliteConnection conn = new SqliteConnection();

    // Constructor that accepts a connection string
    public DatabaseConnector(string connection_string)
    {
        conn.ConnectionString = connection_string;
    }
    public DatabaseConnector()
    {
        conn.ConnectionString = "";
    }

    public void setConnectionString(string connection_string)
    {
        conn.ConnectionString = connection_string;
    }

    // Opens a connection to the database
    public void OpenConnection()
    {
        if (conn.State != System.Data.ConnectionState.Open)
        {
            conn.Open();
        }
    }

    // Validates and stores an event
    public void StoreEvent(Event e)
    {
        OpenConnection();
        var sql = "INSERT INTO Events (Title, Description, StartDate, EndDate) VALUES (@Title, @Description, @StartDate, @EndDate)";
        using (var cmd = new SqliteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Title", e.Title);
            cmd.Parameters.AddWithValue("@Description", e.Description);
            cmd.Parameters.AddWithValue("@StartDate", e.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", e.EndDate);
            cmd.ExecuteNonQuery();
        }
        CloseConnection();
    }

    // Deletes an event based on its Id
    public void DeleteEvent(Event e)
    {
        OpenConnection();
        var sql = "DELETE FROM Events WHERE Id = @Id";
        using (var cmd = new SqliteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Id", e.Id);
            cmd.ExecuteNonQuery();
        }
        CloseConnection();
    }

    // Updates an event based on event data
    public void UpdateEvent(Event e)
    {
        OpenConnection();
        var sql = "UPDATE Events SET Title = @Title, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";
        using (var cmd = new SqliteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Title", e.Title);
            cmd.Parameters.AddWithValue("@Description", e.Description);
            cmd.Parameters.AddWithValue("@StartDate", e.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", e.EndDate);
            cmd.Parameters.AddWithValue("@Id", e.Id);
            cmd.ExecuteNonQuery();
        }
        CloseConnection();
    }

    // Retrieve a single event by Id
    public Event RetrieveEvent(int id)
    {
        OpenConnection();
        var sql = "SELECT Id, Title, Description, StartDate, EndDate FROM Events WHERE Id = @Id";
        using (var cmd = new SqliteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var retrievedEvent = new Event
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        StartDate = reader.GetDateTime(3),
                        EndDate = reader.GetDateTime(4)
                    };
                    CloseConnection();
                    return retrievedEvent;
                }
            }
        }
        CloseConnection();
        return null; // If no event is found
    }

    // Retrieve all events
    public List<Event> RetrieveEvents()
    {
        OpenConnection();
        var sql = "SELECT Id, Title, Description, StartDate, EndDate FROM Events";
        var events = new List<Event>();
        using (var cmd = new SqliteCommand(sql, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var retrievedEvent = new Event
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        StartDate = reader.GetDateTime(3),
                        EndDate = reader.GetDateTime(4)
                    };
                    events.Add(retrievedEvent);
                }
            }
        }
        CloseConnection();
        return events;
    }

    // Closes the database connection
    public void CloseConnection()
    {
        if (conn.State != System.Data.ConnectionState.Closed)
        {
            conn.Close();
        }
    }
}
