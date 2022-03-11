using System;

namespace kcar.interfaces
{
   public interface IActivity
   {
       public string Provider { get; }
       public int ProviderVersion { get; }


       public string Id { get; }
       public string Type { get; }
       public DateTime StartDate { get; }
       public float Duration { get;  } 
       public float Calories { get; }
       public float Distance { get; }
   }
}

