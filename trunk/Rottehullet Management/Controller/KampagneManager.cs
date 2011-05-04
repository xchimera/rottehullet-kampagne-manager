using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Model;
using Interfaces;
using Enum;

namespace Controller
{
	public class KampagneManager
	{
		List<string[]> nuværendeBrugersRettigheder = new List<string[]>();
		BrugerCollection brugercollection;
		Kampagne kampagne;
		DBFacade dbFacade;
		KampagneAttribut nuværendeAttribut;
		Scenarie nuværendeScenarie;
	    private long nuværendebrugerID;
		BrugerRettighed nuværendeRettighed;

		public KampagneManager()
		{
			dbFacade = new DBFacade(this);
			brugercollection = new BrugerCollection();
			nuværendeAttribut = null;
			nuværendeScenarie = null;
		}

		#region Bruger
		public Bruger FindBruger(long brugerID)
		{
			return brugercollection.FindBruger(brugerID);
		}

		public IBruger FindKaraktersBruger(long karakterID)
		{
			return (IBruger)brugercollection.FindKaraktersBruger(karakterID);
		}

		public IEnumerator GetBrugerIterator()
		{
			return brugercollection.GetBrugerIterator();
		}

		public bool Opretbruger(long brugerID, string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string andet, string allergi)
		{
			if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi))
			{
				if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi))

					brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
				return true;
			}
			return false;
		}

        public void OpretBruger(long brugerID, string navn)
        {
            brugercollection.OpretBruger(brugerID, navn);
        }

		public Bruger TilføjBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			return brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
		}

        public bool HentBrugereTilAdmin()
        {
            return dbFacade.HentBrugereTilAdmin();
        }
		#endregion

		#region Karakter
		//
		public IEnumerator AlleKaraktererEnumerator()
		{
			return brugercollection.HentAlleKarakterer().GetEnumerator();
		}

		public IEnumerator AlleKaraktererPåKampagneEnumerator(long kampagneID)
		{
			return brugercollection.HentAlleKaraktererPåKampagne(kampagneID).GetEnumerator();
		}

		public IKarakter FindKarakter(long karakterID)
		{
			return (IKarakter)brugercollection.FindKarakter(karakterID);
		}

		public Karakter TilføjKarakter(Bruger bruger, long karakterID)
		{
			return brugercollection.TilføjKarakter(bruger, karakterID, kampagne);
		}
		#endregion

		#region Login/Logout
		public IEnumerable GetBrugersKampagneIterator()
		{
			return nuværendeBrugersRettigheder;
		}

		public IEnumerator GetBrugerKampagne()
		{
			return nuværendeBrugersRettigheder.GetEnumerator();
		}

		public void IndsætRettighed(string kampagneID, string navn, string type)
		{
			string[] kampagnearr = new string[3] { kampagneID, navn, type };
			nuværendeBrugersRettigheder.Add(kampagnearr);
		}

		public void RetKampagneliste(long kampagneID, string navn)
		{
			foreach (string[] kampagne in nuværendeBrugersRettigheder)
			{
				if (kampagne[0] == kampagneID.ToString())
				{
					kampagne[1] = navn;
				}
			}
		}

		//Bruges når en bruger skifter kampagne, så karakterer fra en kampagne ikke stadig er i modelen
		//når den nye kampagne bliver åbnet
		public void TømKarakterer()
		{
			brugercollection.TømKarakterer();
		}
		#endregion

		#region Kampagne
		public Kampagne GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, KampagneStatus status)
		{
			kampagne = new Kampagne(kamID, navn, beskrivelse, hjemmeside, status);
			return kampagne;
		}

		public int GetAntalKampagner()
		{
			return nuværendeBrugersRettigheder.Count();
		}

		public bool HentKampagneFraDatabase(long kamID)
		{
			if (dbFacade.HentKampagne(kamID) && dbFacade.HentAttributter(kamID) && dbFacade.HentBrugereOgKaraktererTilKampagne(kampagne) && dbFacade.HentMultiAttributterTilKarakterer(brugercollection.HentAlleKarakterer(), kampagne))
			{
				return true;
			}
			return false;
		}

		public bool OpretKampagne(string navn, long topbrugerID)
		{
			long kampagneID = dbFacade.OpretKampagne(navn, topbrugerID);
			if (kampagneID > 0)
			{
				kampagne = new Kampagne(navn, kampagneID, KampagneStatus.Oprettet);
				return true;
			}
			return false;
		}

		public bool RetKampagneBeskrivelse(string beskrivelse, long kampagneID)
		{
			if (dbFacade.RetKampagneBeskrivelse(beskrivelse, kampagneID))
			{
				kampagne.Beskrivelse = beskrivelse;
				return true;
			}
			return false;
		}

		public bool RetKampagneHjemmeside(string hjemmeside, long kampagneID)
		{
			if (dbFacade.RetKampagneHjemmeside(hjemmeside, kampagneID))
			{
				kampagne.Hjemmeside = hjemmeside;
				return true;
			}
			return false;
		}

		public bool RetKampagneNavn(string navn, long kampagneID)
		{
			if (dbFacade.RetKampagneNavn(navn, kampagneID))
			{
				kampagne.Navn = navn;
				return true;
			}
			return false;
		}

		public bool RetKampagneStatus(long kampagneID, KampagneStatus status)
		{
			if (dbFacade.RetKampagneStatus(kampagneID, status))
			{
				kampagne.Status = status;
				return true;
			}
			return false;
		}

		public bool TilknytSuperbruger(long brugerID, long kampagneID)
		{
			if (dbFacade.TilknytSuperbruger(brugerID, kampagneID))
			{
				return true;
			}
			return false;
		}

		public IKampagne Kampagne
		{
			get { return kampagne; }
		}

	    public long NuværendebrugerId
	    {
	        get { return nuværendebrugerID; }
	    }

	    #endregion

		#region Attributter
		public IKampagneAttribut FindKampagneAttribut(long id)
		{
			nuværendeAttribut = kampagne.FindAttribut(id);
			return nuværendeAttribut;
		}

		public KampagneAttribut GenopretAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagne.GenopretAttribut(attributID, navn, type);
		}

		public KampagneMultiAttribut GenopretMultiAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagne.GenopretMultiAttribut(attributID, navn, type);
			//return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type, valgmuligheder);
		}

        public IEnumerator GetAttributIterator()
		{
            return kampagne.HentAttributter();
		}

		public IEnumerator HentValgmuligheder()
		{
			if (nuværendeAttribut.Type == KampagneAttributType.Combo)
			{
				KampagneMultiAttribut attribut = (KampagneMultiAttribut)nuværendeAttribut;
				return attribut.Valgmuligheder.GetEnumerator();
			}
			return null;
		}

		public bool RetAttribut(string navn, KampagneAttributType type, int position)
		{
			if (dbFacade.RetAttribut(nuværendeAttribut.KampagneAttributID, navn, (int)type, kampagne.KampagneID, position))
			{
				nuværendeAttribut.Navn = navn;
				nuværendeAttribut.Type = type;

				return true;
			}
			return false;
		}

		public bool RetKampagneMultiAttributEntry(long id, long attributID, string værdi)
		{
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)kampagne.FindAttribut(id);
			if (dbFacade.RetKampagneMultiAttributEntry(id, attributID, værdi))
			{
				foreach (KampagneMultiAttributValgmulighed valgmulighed in attribut.Valgmuligheder)
				{
					if (valgmulighed.Id == id)
					{
						valgmulighed.Værdi = værdi;
						break;
					}
				}
				return true;
			}

			return false;
		}

		public bool SletAttribut(long attID)
		{
			if (dbFacade.SletAttribut(attID))
			{
				kampagne.SletAttribut(attID);
				return true;
			}
			return false;
		}

		public bool SletMultiAttributValgmulighed(long entryID)
		{
			if (dbFacade.SletMultiAttributEntry(entryID))
			{
				((KampagneMultiAttribut)nuværendeAttribut).FjernValgmulighed(entryID);
				return true;
			}
			return false;
		}

		/* TODO:
		 * lav en out string, der beskriver, hvad for en fejl, der sker
		 */
		public bool TilføjMultiAttribut(string navn, KampagneAttributType type, int position, List<string> valgmuligheder)
		{
			long id = dbFacade.OpretKampagneAttribut(navn, (int)type, kampagne.KampagneID, position);
			List<KampagneMultiAttributValgmulighed> valgmulighedsListe = new List<KampagneMultiAttributValgmulighed>();
			KampagneMultiAttributValgmulighed valgmulighed;
			foreach (string værdi in valgmuligheder)
			{
				long entryID = dbFacade.OpretKampagneMultiAttributEntry(id, værdi);
				if (entryID != -1)
				{
					valgmulighed = new KampagneMultiAttributValgmulighed(entryID, værdi);
					valgmulighedsListe.Add(valgmulighed);
				}
				else
					return false;
			}
			if (id != -1)
			{
				kampagne.TilføjMultiAttribut(navn, type, valgmulighedsListe, kampagne.KampagneID, position);
				return true;
			}
			return false;
		}

		public long TilføjMultiAttributEntry(string værdi)
		{
			long entryID = dbFacade.OpretKampagneMultiAttributEntry(nuværendeAttribut.KampagneAttributID, værdi);
			if (entryID != -1)
			{
				KampagneMultiAttributValgmulighed valgmulighed = new KampagneMultiAttributValgmulighed(entryID, værdi);
				((KampagneMultiAttribut)nuværendeAttribut).TilføjValgmulighed(valgmulighed);
				return entryID;
			}
			return -1;
		}

		public bool TilføjSingleAttribut(string navn, KampagneAttributType type, int position)
		{
			long id = dbFacade.OpretKampagneAttribut(navn, (int)type, kampagne.KampagneID, position);
			if (id != -1)
			{
				kampagne.TilføjSingleAttribut(navn, type, id, position);
				return true;
			}
			return false;
		}

		#endregion

		#region Scenarie
		public bool TilføjScenarie(string titel, string beskrivelse, DateTime tid, string sted, float pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
		{
			long id = dbFacade.TilføjScenarie(titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo, kampagne.KampagneID);
			if (id != -1)
			{
				nuværendeScenarie = kampagne.TilføjScenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
				return true;
			}
			return false;
		}

		public void GenopretScenarie(long id, string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
		{
			nuværendeScenarie = kampagne.TilføjScenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
		}

		public bool RetScenarie(string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningValgfri, bool overnatningValgfri, string andetInfo)
		{
			if (dbFacade.RetScenarie(titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningValgfri, overnatningValgfri, andetInfo, nuværendeScenarie.Id))
			{
				nuværendeScenarie.Titel = titel;
				nuværendeScenarie.Beskrivelse = beskrivelse;
				nuværendeScenarie.Tid = tid;
				nuværendeScenarie.Sted = sted;
				nuværendeScenarie.Pris = pris;
				nuværendeScenarie.Overnatning = overnatning;
				nuværendeScenarie.Spisning = spisning;
				nuværendeScenarie.SpisningTvungen = spisningValgfri;
				nuværendeScenarie.OvernatningTvungen = overnatningValgfri;
				nuværendeScenarie.AndetInfo = andetInfo;
				return true;
			}
			return false;
		}

		public IScenarie HentNuværendeScenarie()
		{
			return nuværendeScenarie;
		}
		#endregion

		public static string KrypterKodeord(string kodeord)
		{
			byte[] tekstIBytes = Encoding.Default.GetBytes(kodeord);
			try
			{
				System.Security.Cryptography.MD5CryptoServiceProvider kryptograf;
				kryptograf = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] hash = kryptograf.ComputeHash(tekstIBytes);
				string ret = "";
				foreach (byte a in hash)
				{
					if (a < 16)
						ret += "0" + a.ToString("x");
					else
						ret += a.ToString("x");
				}
				return ret;
			}
			catch
			{
				
				throw;
			}
		}

		public long Login(string email, string kodeord)
		{
			kodeord = KrypterKodeord(kodeord);
			long brugerID = dbFacade.Login(email, kodeord);
		    nuværendebrugerID = brugerID;
			return brugerID;
		}

		public BrugerRettighed SætNuværendeRettighed()
		{
			foreach (string[] item in nuværendeBrugersRettigheder)
			{
				if (Kampagne.KampagneID == Convert.ToInt64(item[0]))
				{
					if (item[2] == "0")
					{
						nuværendeRettighed = BrugerRettighed.Topbruger;
					}
					else
					{
						nuværendeRettighed = BrugerRettighed.Superbruger;
					}
				}
			}
			return nuværendeRettighed;
		}

		public BrugerRettighed NuværendeRettighed
		{
			get { return nuværendeRettighed; }
		}
	}
}