namespace kcar.model.activity
{
    public class ActivityBase
    {
        public ActivityBase(string p, int pv,string ad)
        {
            Provider = p;
            ProviderVersion = pv;
            ActivityData = ad;
        }

        public string Provider { get; set; }
        public int ProviderVersion { get; set; }
        public string ActivityData { get; set; }
    }
}