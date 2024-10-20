using EventCalendar.Models;
using System.Text;
using System.Data;
using Microsoft.Data.Sqlite;
namespace EventCalendar.Utiltiies
{
    public class DatabaseConnector
    {
        //conn - used for creating an initiial connection via SQLite
        public SqliteConnection conn = new SqliteConnection();
        public DatabaseConnector(string connection_string) { 
            conn.ConnectionString = connection_string;
            


        }
        //opens a connection to the specified database
        public void openConnection()
        {
            conn.Open();
        }
        //validates and stores an event
        public void StoreEvent(Event e){
        }
        //deletes an event based on id
        public void DeleteEvent(Event e){

        }
        //updates an event based on event data
        public void UpdateEvent(Event e)
        {

        }
        //retrieve a single event
        public void RetrieveEvent(Event e)
        {

        }

        //retrieve all events
        public void RetrieveEvents(Event e)
        {

        }
        //close down connection 
        public static void CloseConnection()
        {
        }
    }
}
