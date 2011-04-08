using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class KampagneCollection
	{
		List<Kampagne> kampagner;

		public KampagneCollection()
		{
			kampagner = new List<Kampagne>();
		}

		public void OpretKampagne(string navn, Bruger topbruger, long kampagneID)
		{
			Kampagne kampagne = new Kampagne(navn, topbruger, kampagneID);
			kampagner.Add(kampagne);
		}

		public void GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, Bruger bruger)
		{
			Kampagne kampagne = new Kampagne(kamID, navn, beskrivelse, hjemmeside, bruger);
			kampagner.Add(kampagne);
		}

		public Kampagne FindKampagne(string navn)
		{
			foreach (Kampagne kampagne in kampagner)
			{
				if (kampagne.Navn == navn)
					return kampagne;
			}
			return null;
		}
	}
}
