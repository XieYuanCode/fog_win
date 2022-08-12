using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static string Dbpath { get; set; }

        public async static void InitializeDatabase()
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

                SqliteCommand createTable = new SqliteCommand(createRepoTableCommand, db);

                try
                {
                    createTable.ExecuteReader();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
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
