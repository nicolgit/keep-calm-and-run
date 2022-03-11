using System;
using System.Collections.Generic;
using kcar.interfaces;

namespace kcar.model.interfaces
{
    public interface IReader
    {
        public void Initialize(kcar.model.Settings settings );
        public IEnumerable<IActivity> ReadActivities(DateTime? before, DateTime? after, int page, int pageSize);
        public IActivity ReadActivity(string id);
        public int Count();
    }
}