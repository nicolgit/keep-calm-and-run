using kcar.interfaces.Reader;
using kcar.model;
using System;
using System.Data.SqlClient;
using System.Text;
using Serilog;

namespace kcar.interfaces.Reader
{
    public class CaledosReader : IReader
    {
        private model.Caledos? _settings;

        public void Initialize(Settings settings)
        {
            _settings = settings.Caledos;
            if (_settings == null)
            {
                throw new kcarSettingsNotFoundException("Caledos settings not found");
            }
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ReadActivities(DateTime before, DateTime after, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public string ReadActivity(string id)
        {            
            using (SqlConnection connection = new SqlConnection( _settings!.DBConnectionString))
            {              
                connection.Open();       

                String sql = $"select top 10 * from FitnessActivity where Id = '{id}' FOR JSON AUTO";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetString(0);
                            Log.Verbose($"Activity Data: {result}");
                            return result;
                        }
                    }
                }                    
            }
            throw new kcarNotFoudException($"Activity {id} not found");
        }
    }
}