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
        Dictionary<long, string> singleværdier;
        Dictionary<long[], string> multiværdier;
        long karakterID;
        long kampagneID;

        public Karakter(long karakterID, long kampagneID)
        {
            this.karakterID = karakterID;
            this.kampagneID = kampagneID;
            attributter = new List<KampagneAttribut>();
            singleværdier = new Dictionary<long, string>();
        }

        public void TilføjVærdi(long kampagneattributID, string værdi)
        {
            singleværdier.Add(kampagneattributID, værdi);
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
