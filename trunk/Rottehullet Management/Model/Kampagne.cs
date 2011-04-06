using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	class Kampagne
	{
		private List<KampagneAttribut> attributter;

		public KampagneAttribut FindAttribut(string navn) {
			foreach (KampagneAttribut attribut in attributter)
			{
				if (attribut.Navn == navn)
				{
					return attribut;
				}
			}
			return null;
		}

		public void TilføjAttribut(string navn, Type type, int kampagneAttributID)
		{
			KampagneAttribut attribut = new KampagneAttribut(navn, type, kampagneAttributID);
			attributter.Add(attribut);
		}

		public void TilføjMultiAttribut(string navn, Type type, List<string> valgmuligheder, int kampagneAttributID)
		{
			KampagneMultiAttribut attribut = new KampagneMultiAttribut(navn, type, valgmuligheder, kampagneAttributID);
			attributter.Add(attribut);
		}

		public void 
	}
}
