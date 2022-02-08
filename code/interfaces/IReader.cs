namespace kcar.interfaces
{
    public interface IReader
    {
        public void Initialize(kcar.model.Settings settings );
        public string ReadActivities(DateTime before, DateTime after, int page, int pageSize);
        public string ReadActivity(string id);
        public int Count();
    }
}