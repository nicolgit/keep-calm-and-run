using System.Threading.Tasks;
using kcar.model;

namespace kcar.interfaces
{
    public interface IWriter
    {
        public Task Initialize(Settings settings);
        public Task WriteActivity(IActivity activity);
    }
}