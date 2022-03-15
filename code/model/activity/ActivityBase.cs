using Newtonsoft.Json.Linq;
using System;

namespace kcar.model.activity
{
    public abstract class ActivityBase
    {
        public ActivityBase(string p, int pv,string ad)
        {
            ActivityData = ad;

            jActivityData = JObject.Parse(ad);
            jActivityData.Add("PROVIDERVERSION", pv);
            jActivityData.Add("PROVIDER", p);
        }

        public string Provider { get => jActivityData.SelectToken("PROVIDER")!.ToString(); }
        public int ProviderVersion { get => jActivityData.SelectToken("PROVIDERVERSION")!.ToObject<int>(); }
        public string ActivityData { get; set; }

        protected JObject jActivityData {get; set;}

        abstract public string Type { get; }
        abstract public DateTime StartDate { get; }

        public string ToShortString() => $"{Type} - {StartDate}";
    }
}