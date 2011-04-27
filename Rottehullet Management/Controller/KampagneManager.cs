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
		List<string[]> kampagneliste = new List<string[]>();
		BrugerCollection brugercollection;
		Kampagne kampagne;
		DBFacade dbFacade;
		KampagneAttribut nuværendeAttribut;
		Scenarie nuværendeScenarie;

		public KampagneManager()
		{
			dbFacade = new DBFacade(this);
			brugercollection = new BrugerCollection();
			nuværendeAttribut = null;
			nuværendeScenarie = null;
		}

		#region Bruger
		public System.Collections.IEnumerator GetBrugerIterator()
		{
			return brugercollection.GetBrugerIterator();
		}

		public bool Opretbruger(long brugerID, string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string andet, string allergi)
		{ //long brugerID, string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer
			if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi))
			{
				if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi))

					brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
				return true;
			}
			return false;
		}

		public void TilføjBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
		}
		#endregion

		#region KampagneListe
		public System.Collections.IEnumerable GetBrugersKampagneIterator()
		{
			return kampagneliste;
		}

		public System.Collections.IEnumerator GetBrugerKampagne()
		{
			return kampagneliste.GetEnumerator();
		}

		public void IndsætRettighed(string kampagneID, string navn, string type)
		{
			string[] kampagnearr = new string[3] { kampagneID, navn, type };
			kampagneliste.Add(kampagnearr);
		}

		public void RetKampagneliste(long kampagneID, string navn)
		{
			foreach (string[] kampagne in kampagneliste)
			{
				if (kampagne[0] == kampagneID.ToString())
				{
					kampagne[1] = navn;
				}
			}
		}
		#endregion

		#region Kampagne
		public bool GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, long topbrugerID, KampagneStatus status)
		{
			Bruger bruger;
			bruger = brugercollection.FindBruger(topbrugerID);
			if (bruger != null)
			{
				kampagne = new Kampagne(kamID, navn, beskrivelse, hjemmeside, bruger, status);
				//dbFacade.HentScenarierTilKampagne(kamID);
				return true;
			}
			return false;
		}

		public int GetAntalKampagner()
		{
			return kampagneliste.Count();
		}

		public bool HentKampagneFraDatabase(long kamID)
		{
			if (!dbFacade.HentBrugereTilKampagne(kamID))
			{
				return false;
			}

			if (dbFacade.HentKampagne(kamID) && dbFacade.HentAttributter(kamID))
			{
				return true;
			}
			return false;
		}

		public bool OpretKampagne(string navn, long topbrugerID)
		{
			long kampagneID = dbFacade.OpretKampagne(navn, topbrugerID);
			Bruger topbruger;
			if (kampagneID > 0)
			{
				topbruger = brugercollection.FindBruger(topbrugerID);
				if (topbruger != null)
				{
					kampagne = new Kampagne(navn, topbruger, kampagneID, KampagneStatus.Oprettet);
					return true;
				}
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

		public IEnumerator HentAttributter()
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
			long id = dbFacade.OpretKampagneSingleAttribut(navn, (int)type, kampagne.KampagneID, position);
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
			long id = dbFacade.OpretKampagneSingleAttribut(navn, (int)type, kampagne.KampagneID, position);
			if (id != -1)
			{
				kampagne.TilføjSingleAttribut(navn, type, id, position);
				return true;
			}
			return false;
		}

		#endregion

		#region Scenarie
		public bool TilføjScenarie(string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
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

			return brugerID;
		}
	}
}