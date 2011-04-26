using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Model
{
    public class Karakter
    {
        List<KampagneAttribut> attributter;
        Dictionary<long, string> værdier;
        long karakterID;
        long kampagneID;

        public Karakter(long karakterID, long kampagneID)
        {
            this.karakterID = karakterID;
            this.kampagneID = kampagneID;
            attributter = new List<KampagneAttribut>();
            værdier = new Dictionary<long, string>();
        }

        public void TilføjVærdi(long kampagneattributID, string værdi)
        {
            værdier.Add(kampagneattributID, værdi);
        }

        public IEnumerator GetVærdiIterator()
        {
            return værdier.GetEnumerator();
        }



        public long KarakterID
        {
            get { return karakterID; }
        }
    }
}
