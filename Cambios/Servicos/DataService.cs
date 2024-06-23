using Cambios.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Cambios.Servicos
{
    public class DataService
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private DialogService dialogService;
        private string dbPath;

        public DataService()
        {
            dialogService = new DialogService();

            // Criar o diretório "Data" se não existir
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            dbPath = @"Data\Rates.sqlite";

            try
            {
                connection = new SQLiteConnection("Data Source=" + dbPath);
                connection.Open();

                string sqlcommand =
                    @"CREATE TABLE IF NOT EXISTS Rates (
                        RateId INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Code VARCHAR(5), 
                        TaxRate REAL, 
                        Name VARCHAR(250)
                    )";

                command = new SQLiteCommand(sqlcommand, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SaveData(List<Rate> rates)
        {
            try
            {
                connection.Open();

                foreach (var rate in rates)
                {
                    string sql = "INSERT INTO Rates (Code, TaxRate, Name) VALUES (@Code, @TaxRate, @Name)";
                    command = new SQLiteCommand(sql, connection);
                    command.Parameters.AddWithValue("@Code", rate.Code);
                    command.Parameters.AddWithValue("@TaxRate", rate.TaxRate);
                    command.Parameters.AddWithValue("@Name", rate.Name);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Rate> GetData()
        {
            List<Rate> rates = new List<Rate>();

            try
            {
                connection.Open();

                string sql = "SELECT RateId, Code, TaxRate, Name FROM Rates";
                command = new SQLiteCommand(sql, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rates.Add(new Rate
                    {
                        RateId = Convert.ToInt32(reader["RateId"]),
                        Code = reader["Code"].ToString(),
                        Name = reader["Name"].ToString(),
                        TaxRate = Convert.ToDouble(reader["TaxRate"])
                    });
                }

                reader.Close();
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
            finally
            {
                connection.Close();
            }

            return rates;
        }

        public void DeleteData()
        {
            try
            {
                connection.Open();

                string sql = "DELETE FROM Rates";
                command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                dialogService.ShowMessage("Erro", e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
