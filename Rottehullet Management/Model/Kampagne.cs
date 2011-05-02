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
		private List<Scenarie> scenarier;
		private string navn, hjemmeside, beskrivelse;
		private Bruger topbruger;
        private KampagneStatus status;
		private List<Karakter> karaktererPåKampagne;

		#endregion

		public Kampagne(string navn, Bruger topbruger, long kampagneID, KampagneStatus status)
		{
			this.navn = navn;
			this.topbruger = topbruger;
			this.kampagneID = kampagneID;
			attributter = new List<KampagneAttribut>();
			scenarier = new List<Scenarie>();
			karaktererPåKampagne = new List<Karakter>();
		}

		public Kampagne(long kampagneID, string navn, string beskrivelse, string hjemmeside, KampagneStatus status)
		{
			this.navn = navn;
			this.beskrivelse = beskrivelse;
			this.hjemmeside = hjemmeside;
			this.topbruger = null;
			this.kampagneID = kampagneID;
			this.status = status;
			attributter = new List<KampagneAttribut>();
			scenarier = new List<Scenarie>();
		}

		public Kampagne(long kampagneID, string navn, string beskrivelse, string hjemmeside, Bruger topbruger, KampagneStatus status)
		{
			this.navn = navn;
			this.beskrivelse = beskrivelse;
			this.hjemmeside = hjemmeside;
			this.topbruger = topbruger;
			this.kampagneID = kampagneID;
            this.status = status;
			attributter = new List<KampagneAttribut>();
			scenarier = new List<Scenarie>();
			karaktererPåKampagne = new List<Karakter>();
		}

		/// <summary>
		/// Tilføjer et scenarie til den pågældende Kampagne
		/// </summary>
		/// <param name="titel"></param>
		/// <param name="beskrivelse"></param>
		/// <param name="tid"></param>
		/// <param name="sted"></param>
		/// <param name="overnatning"></param>
		/// <param name="spisning"></param>
		/// <param name="spisningTvungen"></param>
		/// <param name="overnatningTvungen"></param>
		public Scenarie TilføjScenarie(long id, string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
		{
			Scenarie scenarie = new Scenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
			scenarier.Add(scenarie);
			return scenarie;
		}

		public Scenarie FindScenarie(long scenarieID)
		{
			foreach (Scenarie scenarie in scenarier)
			{
				if (scenarie.Id == scenarieID)
					return scenarie;
			}
			return null;
		}

        public KampagneAttribut GenopretAttribut(long attributID, string navn, KampagneAttributType type)
        {
            KampagneAttribut singleattribut = new KampagneAttribut(navn, type, attributID);
            attributter.Add(singleattribut);
            return singleattribut;
        }

        public KampagneMultiAttribut GenopretMultiAttribut(long attributID, string navn, KampagneAttributType type)
        {
            KampagneMultiAttribut multiattribut = new KampagneMultiAttribut(navn, type, attributID);
            attributter.Add(multiattribut);
            return multiattribut;
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

        public IEnumerator GetValgmulighederIterator(long attributID)
        {
            KampagneMultiAttribut kampagnemultiattribut = (KampagneMultiAttribut)FindAttribut(attributID);
            return kampagnemultiattribut.GetValgmulighederIterator();
        }

		/// <summary>
		/// Opretter en single attribut og tilføjer den til listen
		/// </summary>
		/// <param name="navn"></param>
		/// <param name="type"></param>
		/// <param name="kampagneAttributID"></param>
		/// <param name="position"></param>
		public void TilføjSingleAttribut(string navn, KampagneAttributType type, long kampagneAttributID, int position)
		{
			KampagneAttribut attribut = new KampagneAttribut(navn, type, kampagneAttributID);
			attributter.Insert(position, attribut);
		}

		public void TilføjMultiAttribut(string navn, KampagneAttributType type, List<KampagneMultiAttributValgmulighed> valgmuligheder, long kampagneAttributID, int position)
		{
			KampagneMultiAttribut attribut = new KampagneMultiAttribut(navn, type, valgmuligheder, kampagneAttributID);
			attributter.Insert(position, attribut);
		}

		public void RetSingleAttribut(int id, KampagneAttributType type, int position)
		{
			KampagneAttribut attribut = FindAttribut(id);
			attribut.Navn = navn;
			attribut.Type = type;
		}

		public void RetMultiAttribut(int id, KampagneAttributType type, List<KampagneMultiAttributValgmulighed> valgmuligheder, int position)
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

		public IBruger Topbruger
		{
			get { return topbruger; }
		
		}

        public KampagneStatus Status
        {
            get { return status; }
            set { status = value; }
        }
		#endregion
	}
}
