using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;
using Enum;

namespace Model
{
	public class Kampagne : IKampagne
	{
		#region attributter
		private long kampagneID;
		private List<KampagneAttribut> attributter;
		private string navn, hjemmeside, beskrivelse;
		private Bruger topbruger;
		#endregion

		public Kampagne(string navn, Bruger topbruger, long kampagneID)
		{
			this.navn = navn;
			this.topbruger = topbruger;
			this.kampagneID = kampagneID;
			attributter = new List<KampagneAttribut>();
		}
		public Kampagne(long kampagneID, string navn, string beskrivelse, string hjemmeside, Bruger topbruger)
		{
			this.navn = navn;
			this.beskrivelse = beskrivelse;
			this.hjemmeside = hjemmeside;
			this.topbruger = topbruger;
			this.kampagneID = kampagneID;
			attributter = new List<KampagneAttribut>();
		}

		public KampagneAttribut FindAttribut(long id)
		{
			foreach (KampagneAttribut attribut in attributter)
			{
				if (attribut.KampagneAttributID == id)
				{
					return attribut;
				}
			}
			return null;
		}

		public IEnumerator HentAttributter()
		{
			return attributter.GetEnumerator();
		}

		/// <summary>
		/// Opretter en single attribut og tilføjer den til listen
		/// </summary>
		/// <param name="navn"></param>
		/// <param name="type"></param>
		/// <param name="kampagneAttributID"></param>
		/// <param name="position"></param>
		public void TilføjSingleAttribut(string navn, KampagneType type, long kampagneAttributID, int position)
		{
			KampagneAttribut attribut = new KampagneAttribut(navn, type, kampagneAttributID);
			attributter.Insert(position, attribut);
		}

		public void TilføjMultiAttribut(string navn, KampagneType type, List<string[]> valgmuligheder, long kampagneAttributID, int position)
		{
			KampagneMultiAttribut attribut = new KampagneMultiAttribut(navn, type, valgmuligheder, kampagneAttributID);
			attributter.Insert(position, attribut);
		}

		public void RetSingleAttribut(int id, KampagneType type, int position)
		{
			KampagneAttribut attribut = FindAttribut(id);
			attribut.Navn = navn;
			attribut.Type = type;
		}

		public void RetMultiAttribut(int id, KampagneType type, List<string[]> valgmuligheder, int position)
		{
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)FindAttribut(id);
			attribut.Navn = navn;
			attribut.Type = type;
			attribut.Valgmuligheder = valgmuligheder;
		}

		public void FlytAttribut(KampagneAttribut attribut, int position)
		{
			attributter.Remove(attribut);
			attributter.Insert(position, attribut);
		}

		/// <summary>
		/// Fjerner en attribut i listen udfra et id
		/// </summary>
		/// <param name="position"></param>
		public void SletAttribut(long id)
		{
			for (int i = 0; i < attributter.Count; i++)
			{
				if (attributter[i].KampagneAttributID == id)
				{
					attributter.RemoveAt(i);
					break;
				}
			}
		}

		/// <summary>
		/// Tømmer listen over attributter.
		/// </summary>
		public void SletAttributter()
		{
			attributter.Clear();
		}

		#region properties
		public long KampagneID
		{
			get { return kampagneID; }
		}

		public string Beskrivelse
		{
			get { return beskrivelse; }
			set { beskrivelse = value; }
		}

		public string Hjemmeside
		{
			get { return hjemmeside; }
			set { hjemmeside = value; }
		}

		public string Navn
		{
			get { return navn; }
			set { navn = value; }
		}

		public Bruger Topbruger
		{
			get { return topbruger; }
			set { topbruger = value; }
		}
		#endregion
	}
}
