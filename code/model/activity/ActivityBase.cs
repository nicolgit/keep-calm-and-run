using Newtonsoft.Json.Linq;
using System;

namespace kcar.model.activity
{
    public abstract class ActivityBase
    {
        public ActivityBase(string p, int pv,string ad)
        {
            ActivityData = JObject.Parse(ad);
            ActivityData.Add("PROVIDERVERSION", pv);
            ActivityData.Add("PROVIDER", p);
        }

        public ActivityBase(JObject j)
        {
            ActivityData = j;
        }

        public string Provider { get => ActivityData.SelectToken("PROVIDER")!.ToString(); }
        public int ProviderVersion { get => ActivityData.SelectToken("PROVIDERVERSION")!.ToObject<int>(); }
        public JObject ActivityData { get; set; }

        abstract public string Type { get; }
        abstract public DateTime StartDate { get; }

        public string ToShortString() => $"{Type} - {StartDate}";
        public string ToJsonString() => ActivityData.ToString();
    }
}