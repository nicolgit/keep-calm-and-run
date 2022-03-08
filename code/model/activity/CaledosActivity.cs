using System;
using kcar.interfaces;

namespace kcar.model.activity
{
    public class CaledosActivity : ActivityBase, IActivity
    {
        public CaledosActivity(string p, int pv, string ad) : base(p, pv, ad)
        {
        }
        
        public string Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public DateTime StartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float TotalCalories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}