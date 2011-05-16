using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;
using Enum;

namespace Model
{
	public class Karakter : IKarakter
	{
		Dictionary<string, KarakterAttribut> attributter;   //string er karakterattributID
		long karakterID;
		Kampagne kampagne;
		List<Tilmelding> scenarieTilmeldinger;
		KarakterStatus status;
		Bruger bruger;

		public Karakter(long karakterID, Kampagne kampagne, KarakterStatus status, Bruger bruger)
		{
			this.karakterID = karakterID;
			this.kampagne = kampagne;
			this.status = status;
			this.bruger = bruger;
			attributter = new Dictionary<string, KarakterAttribut>();
			scenarieTilmeldinger = new List<Tilmelding>();
			kampagne.TilføjKarakter(this);
		}

		#region metoder
		/// <summary>
		/// Tilføjer en single attribut til karakteren.
		/// Lavet af René
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="værdi"></param>
		public void TilføjVærdi(KampagneAttribut kampagneAttribut, string værdi, long id)
		{
			KarakterSingleAttribut attribut = new KarakterSingleAttribut(værdi, kampagneAttribut, id);
			attributter.Add(kampagneAttribut.Navn, attribut);
		}

		/// <summary>
		/// Tilføjer en multi attribut til karakteren.
		/// Lavet af René
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="valg"></param>
		public void TilføjVærdi(KampagneAttribut kampagneAttribut, KampagneMultiAttributValgmulighed valg, long id)
		{
			KarakterMultiAttribut attribut = new KarakterMultiAttribut(valg, kampagneAttribut, id);
			attributter.Add(kampagneAttribut.Navn, attribut);
		}

		//Lavet af René
		public void TilmeldTilScenarie(Scenarie scenarie, bool spiser, int antalOvernatninger)
		{
			Tilmelding tilmelding = new Tilmelding(this, scenarie, spiser, antalOvernatninger);
			scenarieTilmeldinger.Add(tilmelding);
		}

		//Lavet af René
		public bool ErTilmeldtTilScenarie(Scenarie scenarie)
		{
			foreach (Tilmelding tilmelding in scenarieTilmeldinger)
			{
				if (tilmelding.Scenarie == scenarie)
				{
					return true;
				}
			}
			return false;
		}

		//Lavet af Thorbjørn
		public string FindAttributVærdi(long kampagneattributID)
		{
			foreach (KarakterAttribut attribut in attributter.Values)
			{
				if (attribut.Kampagneattribut.KampagneAttributID == kampagneattributID)
				{
					if (attribut.Kampagneattribut.Type == KampagneAttributType.Singleline || attribut.Kampagneattribut.Type == KampagneAttributType.Multiline)
					{
						KarakterSingleAttribut singleattribut = (KarakterSingleAttribut)attribut;
						return singleattribut.Værdi;
					}
					else
					{
						KarakterMultiAttribut multiattribut = (KarakterMultiAttribut)attribut;
						return multiattribut.Valg.Værdi;
					}
				}
			}
			return null;
		}

		//Lavet af Søren
		public IEnumerator HentVærdier()
		{
			List<string> returliste = new List<string>();
			foreach (KarakterAttribut karakterAttribut in attributter.Values)
			{
				if (karakterAttribut.Kampagneattribut.Type == KampagneAttributType.Singleline || karakterAttribut.Kampagneattribut.Type == KampagneAttributType.Multiline)
				{
					KarakterSingleAttribut singleattribut = (KarakterSingleAttribut)karakterAttribut;
					returliste.Add(singleattribut.Værdi);
				}
				else if (karakterAttribut.Kampagneattribut.Type == KampagneAttributType.Combo)
				{
					KarakterMultiAttribut multiattribut = (KarakterMultiAttribut)karakterAttribut;
					returliste.Add(multiattribut.Valg.Værdi);
				}
			}
			return returliste.GetEnumerator();
		}

		#endregion

		#region Properties
		public IEnumerator GetVærdiIterator()
		{
			List<KarakterAttribut> karakterAttributter = new List<KarakterAttribut>();
			foreach (KarakterAttribut karakterAttribut in attributter.Values)
			{
				karakterAttributter.Add(karakterAttribut);
			}
			return karakterAttributter.GetEnumerator();
		}

		public long KarakterID
		{
			get { return karakterID; }
		}

		public KarakterStatus Status
		{
			get { return status; }
			set { status = value; }
		}

		public IKampagne Kampagne
		{
			get { return kampagne; }
		}

		public IBruger Bruger
		{
			get { return bruger; }
		}

		public string Navn
		{
			get { return this["Navn"]; }
		}

		public string this[string attributNavn]
		{
			get
			{
				KarakterAttribut værdi = attributter[attributNavn];
				if (værdi is KarakterMultiAttribut)
				{
					return ((KarakterMultiAttribut)værdi).Værdi;
				}
				else if (værdi is KarakterSingleAttribut)
				{
					return ((KarakterSingleAttribut)værdi).Værdi;
				}
				return null;
			}
		}

		public string BrugersNavn
		{
			get { return bruger.Navn; }
		}

		public string BrugerAllergi
		{
			get { return bruger.Allergi; }
		}

		public string BrugerVeganer
		{
			get
			{
				if (bruger.Veganer == true)
					return "Ja";
				return "Nej";
			}
		}

		public string BrugerVegetar
		{
			get
			{
				if (bruger.Vegetar == true)
					return "Ja";
				return "Nej";
			}
		}

		public long BrugerTlf
		{
			get { return bruger.Tlf; }
		}

		public long BrugerNødTlf
		{
			get { return bruger.NødTlf; }
		}

		public string BrugerAndetInfo
		{
			get { return bruger.Andet; }
		}

		public int BrugerAlder
		{
			get { return bruger.Alder; }
		}
		#endregion
	}
}
