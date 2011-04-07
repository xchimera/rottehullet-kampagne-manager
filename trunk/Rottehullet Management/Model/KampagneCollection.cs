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

		public void OpretKampagne(string navn, Bruger topbruger, int kampagneID)
		{
			Kampagne kampagne = new Kampagne(navn, topbruger, kampagneID);
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
