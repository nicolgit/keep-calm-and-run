using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kcar.interfaces;

namespace kcar.model.interfaces
{
    public interface IReader
    {
        public Task Initialize(kcar.model.Settings settings );
        public Task<IEnumerable<IActivity>> ReadActivities(DateTime? before, DateTime? after, int skip, int pageSize);
        public Task<IActivity> ReadActivity(string id);
    }
}