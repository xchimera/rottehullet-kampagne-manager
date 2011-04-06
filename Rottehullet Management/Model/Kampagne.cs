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

		public void TilføjSingleAttribut(string navn, Type type, int kampagneAttributID, int position)
		{
			KampagneAttribut attribut = new KampagneAttribut(navn, type, kampagneAttributID);
			attributter[position] = attribut;
		}

		public void TilføjMultiAttribut(string navn, Type type, List<string> valgmuligheder, int kampagneAttributID, int position)
		{
			KampagneMultiAttribut attribut = new KampagneMultiAttribut(navn, type, valgmuligheder, kampagneAttributID);
			attributter[position] = attribut;
		}

		public void RetSingleAttribut(string navn, Type type, int position)
		{
			KampagneAttribut attribut = FindAttribut(navn);
			attribut.Navn = navn;
			attribut.Type = type;
		}

		public void RetMultiAttribut(string navn, Type type, List<string> valgmuligheder, int position)
		{
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)FindAttribut(navn);
			attribut.Navn = navn;
			attribut.Type = type;
			attribut.Valgmuligheder = valgmuligheder;
		}

		public void SletAttribut(int position)
		{
			attributter.RemoveAt(position);
		}

		public void SletAttributter()
		{
			attributter.Clear();
		}
	}
}
