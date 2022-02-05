namespace kcar.interfaces
{
   public class Activity
   {
       public Activity(string provider, string providerVersion, string id, string activityData)
       {
            Provider = provider;
            ProviderVersion = providerVersion;
            Id = id;
            ActivityData = activityData;
       }
       
       public string Provider { get; set; } // i.e. STRAVA
       public string ProviderVersion { get; set; } // i.e. 1.0
       public string Id { get; set; }
       public string ActivityData { get; set; }
   }
}

