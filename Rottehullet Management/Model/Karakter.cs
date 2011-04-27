using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    public class Karakter
    {
        List<KampagneAttribut> attributter;
		Dictionary<string, KarakterAttribut> værdier;
        long karakterID;
		Kampagne kampagne;

        public Karakter(long karakterID, Kampagne kampagne)
        {
            this.karakterID = karakterID;
            this.kampagne = kampagne;
			værdier = new Dictionary<string, KarakterAttribut>();
        }

        public void TilføjVærdi(KampagneAttribut kampagneAttribut, string værdi)
        {
			KarakterAttribut attribut = new KarakterAttribut(værdi, kampagneAttribut);
            værdier.Add(kampagneAttribut.Navn, attribut);
        }

        public IEnumerator GetVærdiIterator()
        {
            return værdier.GetEnumerator();
        }

        public long KarakterID
        {
            get { return karakterID; }
        }

		public IKampagne Kampagne
		{
			get { return kampagne; }
		}
    }
}
