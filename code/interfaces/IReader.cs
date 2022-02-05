namespace kcar.interfaces.Reader
{
    public interface IReader
    {
        public bool Initialize();
        public string ReadActivities(DateTime before, DateTime after, int page, int pageSize);
        public string ReadActivity(int id);
        public int Count();
    }
}