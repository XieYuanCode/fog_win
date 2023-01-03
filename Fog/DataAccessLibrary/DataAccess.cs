using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Sqlite;
using Windows.Devices.Geolocation;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static string Dbpath { get; set; }

        public async static Task<bool> InitializeDatabase()
        {
            var desktop = await StorageFolder.GetFolderFromPathAsync(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            await desktop.CreateFileAsync("Fog.db", CreationCollisionOption.OpenIfExists);
            //await ApplicationData.Current.LocalFolder.CreateFileAsync("Fog.db", CreationCollisionOption.OpenIfExists);
            Dbpath = Path.Combine(desktop.Path, "Fog.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={Dbpath}"))
            {
                db.Open();

                String createRepoTableCommand = "CREATE TABLE IF NOT EXISTS LocalRepos" +
                    "(" +
                    "RepoID Text PRIMARY KEY, " +
                    "IsGroup Text, " +
                    "Name Text, " +
                    "Path Text, " +
                    "Pin Text DEFAULT(true)" +
                    ")";
                String createAccountTableCommand = "CREATE TABLE IF NOT EXISTS ServiceAccounts" +
                    "(" +
                    "AccountID Text PRIMARY KEY, " +
                    "Type Text, " +
                    "Host Text, " +
                    "Name Text, " +
                    "PAT Text " +
                    ")";

                SqliteCommand createTable = new SqliteCommand(createRepoTableCommand, db);
                SqliteCommand createAccount = new SqliteCommand(createAccountTableCommand, db);

                try
                {
                    createTable.ExecuteReader();
                    createAccount.ExecuteReader();

                    return true;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                    return false;
                }
            }
        }

        public static void AddLocalRepo(string id, string Name, bool Pin, string RepoPath)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename={Dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO LocalRepos VALUES (@ID, @IsGroup, @Name, @Path, @Pin);";
                insertCommand.Parameters.AddWithValue("@ID", id);
                insertCommand.Parameters.AddWithValue("@IsGroup", false.ToString());
                insertCommand.Parameters.AddWithValue("@Name", Name);
                insertCommand.Parameters.AddWithValue("@Path", RepoPath);
                insertCommand.Parameters.AddWithValue("@Pin", Pin.ToString());

                try
                {
                    insertCommand.ExecuteReader();

                    db.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }

            }

        }

        public static void AddAccount(string id, string type, string host, string name, string pat)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename={Dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO ServiceAccounts VALUES (@AccountID, @Type, @Host, @Name, @PAT);";
                insertCommand.Parameters.AddWithValue("@AccountID", id);
                insertCommand.Parameters.AddWithValue("@Type", type);
                insertCommand.Parameters.AddWithValue("@Host", host);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@PAT", pat);

                try
                {
                    insertCommand.ExecuteReader();

                    db.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }

            }
        }

        public static List<List<String>> GetServiceAccounts()
        {
            List<List<String>> entries = new List<List<string>>();

            using (SqliteConnection db =
               new SqliteConnection($"Filename={Dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from ServiceAccounts", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var innerEntries = new List<string>();
                    innerEntries.Add(query.GetString(0));
                    innerEntries.Add(query.GetString(1));
                    innerEntries.Add(query.GetString(2));
                    innerEntries.Add(query.GetString(3));
                    innerEntries.Add(query.GetString(4));
                    entries.Add(innerEntries);
                }

                db.Close();
            }

            return entries;
        }

        public static List<String> GetRepoCollection()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db =
               new SqliteConnection($"Filename={Dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from LocalRepos", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
