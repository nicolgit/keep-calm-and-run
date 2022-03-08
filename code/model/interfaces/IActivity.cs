using System;

namespace kcar.interfaces
{
   public interface IActivity
   {
       public string Id { get; set; }
       public DateTime StartDate { get; set; }
       public float Duration { get; set; } 
       public float TotalCalories { get; set; }
   }
}

