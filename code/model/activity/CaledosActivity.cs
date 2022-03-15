using System;
using System.Linq;
using kcar.interfaces;

namespace kcar.model.activity
{
    public class CaledosActivity : ActivityBase, IActivity
    {
        private static (int,string)[] types = new (int,string)[]
        {
            (TYPEID_RUNNING, TYPE_RUNNING),
            (TYPEID_CYCLING, TYPE_CYCLING),
            (TYPEID_MOUNTAIN_BIKING, TYPE_MOUNTAIN_BIKING),
            (TYPEID_WALKING, TYPE_WALKING),
            (TYPEID_HIKING,  TYPE_HIKING),
            (TYPEID_DOWNHILL_SKIING, TYPE_DOWNHILL_SKIING),
            (TYPEID_CROSSCOUNTRH_SKIING, TYPE_CROSSCOUNTRH_SKIING),
            (TYPEID_SNOWBOARDING, TYPE_SNOWBOARDING),
            (TYPEID_SKATING, TYPE_SKATING),
            (TYPEID_SMIMMING, TYPE_SMIMMING),
            (TYPEID_WHEELCHAIR, TYPE_WHEELCHAIR),
            (TYPEID_ROWING, TYPE_ROWING),
            (TYPEID_ELLIPTICAL, TYPE_ELLIPTICAL),
            (TYPEID_YOGA, TYPE_YOGA),
            (TYPEID_PILATES, TYPE_PILATES),
            (TYPEID_CROSSFIT, TYPE_CROSSFIT),
            (TYPEID_SPINNING, TYPE_SPINNING),
            (TYPEID_ZUMBA, TYPE_ZUMBA),
            (TYPEID_BARRE, TYPE_BARRE),
            (TYPEID_GROUP_WORKKOUT, TYPE_GROUP_WORKKOUT),
            (TYPEID_DANCE, TYPE_DANCE),
            (TYPEID_BOOTCAMP, TYPE_BOOTCAMP),
            (TYPEID_BOXING, TYPE_BOXING),
            (TYPEID_MEDITATION, TYPE_MEDITATION),
            (TYPEID_STRENGTH_TRAINING, TYPE_STRENGTH_TRAINING),
            (TYPEID_CIRCUIT_TRAINING, TYPE_CIRCUIT_TRAINING),
            (TYPEID_CORE_STRENGTHENING, TYPE_CORE_STRENGTHENING),
            (TYPEID_ARC_TRAINER, TYPE_ARC_TRAINER), 
            (TYPEID_STAIRMASTER, TYPE_STAIRMASTER),
            (TYPEID_SPORTS, TYPE_SPORTS),
            (TYPEID_OTHER, TYPE_OTHER)
        };
    
        public CaledosActivity(string p, int pv, string ad) : base(p, pv, ad)
        {

        }
        
        public string Id { get =>  jActivityData.SelectToken("Id")!.ToString();}
        override public DateTime StartDate { get => jActivityData.SelectToken("StartDate")!.ToObject<DateTime>();} 
        public float Duration { get => jActivityData.SelectToken("TotalSeconds")!.ToObject<float>();} 
        public float Calories { get => jActivityData.SelectToken("TotalCalories")!.ToObject<float>();} 
        public float Distance { get => jActivityData.SelectToken("TotalDistance")!.ToObject<float>();}
        override public string Type { get => types.Where(a => a.Item1 == jActivityData.SelectToken("FitnessActivityTypeId")!.ToObject<int>() ).FirstOrDefault().Item2; }

        private const string TYPE_RUNNING = "Running";
        private const string TYPE_CYCLING = "Cycling";
        private const string TYPE_MOUNTAIN_BIKING = "Mountain Biking";
        private const string TYPE_WALKING = "Walking";
        private const string TYPE_HIKING = "Hiking";
        private const string TYPE_DOWNHILL_SKIING = "Downhill Skiing";
        private const string TYPE_CROSSCOUNTRH_SKIING = "Cross-Country Skiing";
        private const string TYPE_SNOWBOARDING = "Snowboarding";
        private const string TYPE_SKATING = "Skating";
        private const string TYPE_SMIMMING = "Swimming";
        private const string TYPE_WHEELCHAIR = "Wheelchair";
        private const string TYPE_ROWING = "Rowing";
        private const string TYPE_ELLIPTICAL = "Elliptical";
        
        private const string TYPE_YOGA = "Yoga";
        private const string TYPE_PILATES = "Pilates";
        private const string TYPE_CROSSFIT = "CrossFit";
        private const string TYPE_SPINNING = "Spinning";
        private const string TYPE_ZUMBA = "Zumba";
        private const string TYPE_BARRE = "Barre";
        private const string TYPE_GROUP_WORKKOUT = "Group Workout";
        private const string TYPE_DANCE = "Dance";
        private const string TYPE_BOOTCAMP = "Bootcamp";
        private const string TYPE_BOXING = "Boxing / MMA";
        private const string TYPE_MEDITATION = "Meditation";
        private const string TYPE_STRENGTH_TRAINING = "Strength Training";
        private const string TYPE_CIRCUIT_TRAINING = "Circuit Training";
        private const string TYPE_CORE_STRENGTHENING = "Core Strengthening";
        private const string TYPE_ARC_TRAINER = "Arc Trainer";
        private const string TYPE_STAIRMASTER = "Stairmaster / Stepwell";
        private const string TYPE_SPORTS = "Sports";
        private const string TYPE_NORDIC_WALKING = "Nordic Walking";

        private const string TYPE_OTHER = "Other";

        private const int TYPEID_RUNNING = 0;
        private const int TYPEID_CYCLING = 1;
        private const int TYPEID_MOUNTAIN_BIKING = 2;
        private const int TYPEID_WALKING = 3;
        private const int TYPEID_HIKING = 4;
        private const int TYPEID_DOWNHILL_SKIING = 5;
        private const int TYPEID_CROSSCOUNTRH_SKIING = 6;
        private const int TYPEID_SNOWBOARDING = 7;
        private const int TYPEID_SKATING = 8;
        private const int TYPEID_SMIMMING = 9;
        private const int TYPEID_WHEELCHAIR = 10;
        private const int TYPEID_ROWING = 11;
        private const int TYPEID_ELLIPTICAL = 12;
        
        private const int TYPEID_YOGA = 31;
        private const int TYPEID_PILATES = 13;
        private const int TYPEID_CROSSFIT = 14;
        private const int TYPEID_SPINNING = 15;
        private const int TYPEID_ZUMBA = 16;
        private const int TYPEID_BARRE = 17;
        private const int TYPEID_GROUP_WORKKOUT = 18;
        private const int TYPEID_DANCE = 19;
        private const int TYPEID_BOOTCAMP = 20;
        private const int TYPEID_BOXING = 21;
        private const int TYPEID_MEDITATION = 22;
        private const int TYPEID_STRENGTH_TRAINING = 23;
        private const int TYPEID_CIRCUIT_TRAINING = 24;
        private const int TYPEID_CORE_STRENGTHENING = 25;
        private const int TYPEID_ARC_TRAINER = 26;
        private const int TYPEID_STAIRMASTER = 27;
        private const int TYPEID_SPORTS = 28;
        private const int TYPEID_NORDIC_WALKING = 29;
        private const int TYPEID_OTHER = 30;
    }


}