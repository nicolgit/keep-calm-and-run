namespace kcar.interfaces
{
    public interface IWriter
    {
        public bool Initialize();
        public string WriteActivity(IActivity activity);
    }
}