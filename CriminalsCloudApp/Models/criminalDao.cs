using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using CriminalsCloudApp.Interfaces;
using CriminalsCloudApp.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore; // This is the important namespace for Entity Framework Core
using Microsoft.Extensions.Logging;


namespace CriminalsCloudApp.Models
{
    public class criminalDao : ICriminalInterface
    {
       private readonly string connectionString;
        public criminalDao()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("CriminalDatabase");
        }




        public List<Criminal> GetAllCriminals()
        {
            List<Criminal> crim = new List<Criminal>();



            try
                {
             
                string sqlstatement = "Select * from longlistofsuspects";


                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    MySqlCommand cmd = new MySqlCommand(sqlstatement, connection);
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        crim.Add(new Criminal(
                            id: (int)reader[0],
                            name: (string)reader[1],
                            sex: (string)reader[2],
                            hair: (string)reader[3],
                            eyes: (string)reader[4],
                            height: (string)reader[5],
                            build: (string)reader[6],
                            fingerPrint: (string)reader[7],
                            glasses: (string)reader[8]));
                    }


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(ex.Message);
                  
            }
                return crim;
            }
        public List<Criminal> SelectByAttributes(string name, string sex, string hair, string eyes, string height, string build, string fingerPrint, string glasses)
        {
            List<Criminal> matchingCriminals = new List<Criminal>();

            string sqlStatement = "SELECT * FROM longlistofsuspects WHERE ";
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(name))
                conditions.Add($"Name LIKE '%{name}%'");

            if (!string.IsNullOrEmpty(sex))
                conditions.Add($"Sex = '{sex}'");

            if (!string.IsNullOrEmpty(hair))
                conditions.Add($"Hair = '{hair}'");

            if (!string.IsNullOrEmpty(eyes))
                conditions.Add($"Eyes = '{eyes}'");

            if (!string.IsNullOrEmpty(height))
                conditions.Add($"Height = '{height}'");

            if (!string.IsNullOrEmpty(build))
                conditions.Add($"Build = '{build}'");

            if (!string.IsNullOrEmpty(fingerPrint))
                conditions.Add($"Finger_Print = '{fingerPrint}'");

            if (!string.IsNullOrEmpty(glasses))
                conditions.Add($"Glasses = '{glasses}'");

            sqlStatement += string.Join(" AND ", conditions);
            Console.WriteLine(sqlStatement.Length);
            if (sqlStatement.Length == 39)
            {
                sqlStatement = "SELECT * FROM longlistofsuspects";
            }
            Console.WriteLine(sqlStatement);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        matchingCriminals.Add(new Criminal(
                                id: (int)reader[0],
                                name: (string)reader[1],
                                sex: (string)reader[2],
                                hair: (string)reader[3],
                                eyes: (string)reader[4],
                                height: (string)reader[5],
                                build: (string)reader[6],
                                fingerPrint: (string)reader[7],
                                glasses: (string)reader[8]));


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return matchingCriminals;
        }

    }
   
    // Implement other CRUD methods as needed...
}

