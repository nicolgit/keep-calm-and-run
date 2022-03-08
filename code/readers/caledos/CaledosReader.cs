using kcar.model;
using System;
using System.Data.SqlClient;
using System.Text;
using Serilog;
using Newtonsoft.Json.Linq;
using Azure.Data.Tables;
using Azure;
using Newtonsoft.Json;
using kcar.model.interfaces;
using kcar.model.activity;

namespace kcar.interfaces.Reader
{
    public class CaledosReader : IReader
    {
        private readonly string READER_TYPE="Caledos";
        private readonly int READER_VERSION=1;

        private readonly string STORAGE_URI = "https://caledosblobproduction.table.core.windows.net";
        private readonly string FITNESSPOINTS_TABLE = "FitnessActivityPoints";
        private readonly string HEARTRATES_TABLE = "HeartActivityPoints";
        private readonly string STORAGE_ACCOUNT = "caledosblobproduction";
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

        public IActivity ReadActivity(string id)
        {            
            using (SqlConnection connection = new SqlConnection( _settings!.DBConnectionString))
            {              
                connection.Open();       

                String sql = $"select * from FitnessActivity where Id = '{id}' FOR JSON AUTO";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetString(0);
                            result = result.Substring(1, result.Length - 2);

                            Log.Verbose($"Activity Data: {result}");

                            JObject o = JObject.Parse(result);
                            var fitnessActivityId = ((string)o.SelectToken("Id")).ToLower().Replace("-", "");
                            var userId = (string?)o.SelectToken("UserId");
                            
                            Log.Verbose($"Activity: {fitnessActivityId}");
                            Log.Verbose($"UserId: {userId}");

                            // Get the activity data
                            var client = new TableClient(
                                new Uri(STORAGE_URI),
                                FITNESSPOINTS_TABLE,
                                new TableSharedKeyCredential(STORAGE_ACCOUNT, Settings.Instance.Caledos.TableStorageAccessKey));

                            Pageable<TableEntity> queryResultsFilter = client.Query<TableEntity>(filter: $"PartitionKey eq '{fitnessActivityId}'");

                            var jarray = new JArray();
                            foreach (TableEntity qEntity in queryResultsFilter)
                            {
                                var jobj = new JObject();
                                
                                foreach (var prop in qEntity.AsEnumerable())
                                {
                                    jobj.Add(prop.Key, prop.Value.ToString());
                                }
                                
                                jarray.Add(jobj);
                            }

                            var jsorted = new JArray(jarray.OrderBy(obj => (int)obj["ActivityTimestamp"]) );

                            // Get HR data
                            var clientHR = new TableClient(
                                new Uri(STORAGE_URI),
                                HEARTRATES_TABLE,
                                new TableSharedKeyCredential(STORAGE_ACCOUNT, Settings.Instance.Caledos.TableStorageAccessKey));

                            Pageable<TableEntity> queryResultsFilterHR = clientHR.Query<TableEntity>(filter: $"PartitionKey eq '{fitnessActivityId}'");

                            var jarrayHR = new JArray();
                            foreach (TableEntity qEntity in queryResultsFilterHR)
                            {
                                var jobj = new JObject();
                                
                                foreach (var prop in qEntity.AsEnumerable())
                                {
                                    jobj.Add(prop.Key, prop.Value.ToString());
                                }
                                
                                jarrayHR.Add(jobj);
                            }

                            var jsortedHR = new JArray(jarrayHR.OrderBy(obj => (int)obj["ActivityTimestamp"]) );



                            o.Add("FitnessActitivyPoints", jsorted);
                            o.Add("HRPoints", jsortedHR);

    	                    string s = o.ToString();
                            Log.Verbose($"{o}");
                            Log.Verbose($"The query returned {queryResultsFilter.Count()} entities.");

                            var caledosActivity = new CaledosActivity(READER_TYPE, READER_VERSION, s);
                            return caledosActivity;
                        }
                    }
                }                    
            }
            throw new kcarNotFoudException($"Activity {id} not found");
        }
        
    }
}