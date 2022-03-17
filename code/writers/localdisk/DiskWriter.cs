
using System.Text;
using kcar.interfaces;
using kcar.model;

namespace kcar.Writer
{
    public class DiskWriter : IWriter
    {
        private model.Disk? _settings;

        public async Task Initialize(Settings settings)
        {
            _settings = settings.Disk;

            if (_settings == null)
            {
                throw new kcarSettingsNotFoundException("DiskWriter.Initialize: settings not found");
            }   

            if (!System.IO.Directory.Exists(_settings.Path))
            {
                System.IO.Directory.CreateDirectory(_settings.Path);
            }

            await Task.Yield();
        }

        public async Task WriteActivity(IActivity activity)
        {
            await File.WriteAllTextAsync (
                _settings!.Path + $"\\{activity.Provider}-{activity.Id}.fitness.json",
                activity.ToJsonString(),
                Encoding.UTF8);
                
            await Task.Yield();
        }
    }
}