﻿using System;
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
		KampagneCollection kampagnecollection;
		DBFacade dbFacade;
		Kampagne nuværendeKampagne;
		KampagneAttribut nuværendeAttribut;
		Scenarie nuværendeScenarie;

		public KampagneManager()
		{
			dbFacade = new DBFacade(this);
			brugercollection = new BrugerCollection();
			kampagnecollection = new KampagneCollection();
			nuværendeKampagne = null;
			nuværendeAttribut = null;
		}

		public void IndsætRettighed(string kampagneID, string navn, string type)
		{
			string[] rettighed = new string[3] { kampagneID, navn, type };
			kampagneliste.Add(rettighed);
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

        public void TilføjBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
		}

		public long Login(string email, string kodeord)
		{
			kodeord = KrypterKodeord(kodeord);
			long brugerID = dbFacade.Login(email, kodeord);

			return brugerID;
		}

		public bool OpretKampagne(string navn, long topbrugerID)
		{
			long kampagneID = dbFacade.OpretKampagne(navn, topbrugerID);
			Bruger bruger;
			if (kampagneID > 0)
			{
				bruger = brugercollection.FindBruger(topbrugerID);
				if (bruger != null)
				{
					kampagnecollection.OpretKampagne(navn, bruger, kampagneID);
					return true;
				}
			}
			return false;
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

        public bool HentAttributterFraDatabase(long kamID)
        {

            return false;
        }

        public KampagneAttribut GenopretAttribut(long kamID, long attributID, string navn, KampagneType type, int position)
        {
            return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type);
        }

        public KampagneMultiAttribut GenopretMultiAttribut(long kamID, long attributID, string navn, KampagneType type,  int position)
        {
            return nuværendeKampagne.GenopretMultiAttribut(attributID, navn, type);
            //return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type, valgmuligheder);
        }

		public bool GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, long topbrugerID)
		{
			Bruger bruger;
			bruger = brugercollection.FindBruger(topbrugerID);
			if (bruger != null)
			{
				nuværendeKampagne = kampagnecollection.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, bruger);
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

		public bool RetKampagneNavn(string navn, long kampagneID)
		{
			if (dbFacade.RetKampagneNavn(navn, kampagneID))
			{
				return true;
			}
			return false;
		}

		public bool RetKampagneBeskrivelse(string beskrivelse, long kampagneID)
		{
			if (dbFacade.RetKampagneBeskrivelse(beskrivelse, kampagneID))
			{
				return true;
			}
			return false;
		}

		public bool RetKampagneHjemmeside(string hjemmeside, long kampagneID)
		{
			if (dbFacade.RetKampagneHjemmeside(hjemmeside, kampagneID))
			{
				nuværendeKampagne.Hjemmeside = hjemmeside;
			}
			return false;
		}

		public IKampagne FindKampagne(string navn)
		{
			nuværendeKampagne = kampagnecollection.FindKampagne(navn);
			return nuværendeKampagne;
		}

		public IKampagneAttribut FindKampagneAttribut(long id)
		{
			nuværendeAttribut = nuværendeKampagne.FindAttribut(id);
			return nuværendeAttribut;
		}

		public bool TilføjSingleAttribut(string navn, KampagneType type, int position)
		{
			long id = dbFacade.OpretKampagneSingleAttribut(navn, (int)type, nuværendeKampagne.KampagneID, position);
			if (id != -1)
			{
				nuværendeKampagne.TilføjSingleAttribut(navn, type, id, position);
				return true;
			}
			return false;
		}

		public System.Collections.IEnumerator GetBrugerIterator()
		{
			return brugercollection.GetBrugerIterator();
		}

        public System.Collections.IEnumerator GetKampagneIterator()
        {
            return kampagnecollection.GetKampagneIterator();
        }

		public bool TilføjMultiAttribut(string navn, KampagneType type, int position, List<string> valgmuligheder)
		{
			long id = dbFacade.OpretKampagneSingleAttribut(navn, (int)type, nuværendeKampagne.KampagneID, position);
			List<string[]> valgmulighedsListe = new List<string[]>();
			string[] valgmulighed;
			foreach (string værdi in valgmuligheder)
			{
				long entryID = dbFacade.OpretKampagneMultiAttributEntry(id, værdi);
				valgmulighed = new string[2] { værdi, entryID.ToString() };
				valgmulighedsListe.Add(valgmulighed);
			}
			if (id != -1)
			{
				nuværendeKampagne.TilføjMultiAttribut(navn, type, valgmulighedsListe, nuværendeKampagne.KampagneID, position);
				return true;
			}
			return false;
		}

		public long TilføjMultiAttributEntry(string værdi)
		{
			long entryID = dbFacade.OpretKampagneMultiAttributEntry(nuværendeAttribut.KampagneAttributID, værdi);
			if (entryID != -1)
			{
				string[] valgmulighed = new string[2] { værdi, entryID.ToString() };
				((KampagneMultiAttribut)nuværendeAttribut).TilføjValgmulighed(valgmulighed);
				return entryID;
			}
			return -1;
		}

		public System.Collections.IEnumerable GetBrugersKampagneIterator()
		{
			return kampagneliste;
		}

        public System.Collections.IEnumerator GetBrugerKampagne()
        {
            return kampagneliste.GetEnumerator();
        }

		public IEnumerator HentAttributter()
		{
			return nuværendeKampagne.HentAttributter();
		}

		public IEnumerator HentValgmuligheder()
		{
			if (nuværendeAttribut.Type == KampagneType.Combo)
			{
				KampagneMultiAttribut attribut = (KampagneMultiAttribut)nuværendeAttribut;
				return attribut.Valgmuligheder.GetEnumerator();
			}
			return null;
		}

		public int GetAntalKampagner()
		{
			return kampagneliste.Count();
		}

		public string KrypterKodeord(string kodeord)
		{
			//Declarations
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			//Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
			md5 = new MD5CryptoServiceProvider();
			originalBytes = ASCIIEncoding.Default.GetBytes(kodeord);
			encodedBytes = md5.ComputeHash(originalBytes);

			//Convert encoded bytes back to a 'readable' string
			return BitConverter.ToString(encodedBytes);
		}

		public bool RetKampagneMultiAttributEntry(long id, long attributID, string værdi)
		{
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)nuværendeKampagne.FindAttribut(id);
			if (dbFacade.RetKampagneMultiAttributEntry(id, attributID, værdi))
			{
				for (int i = 0; i < attribut.Valgmuligheder.Count; i++)
				{
					if (long.Parse(attribut.Valgmuligheder[i][1]) == id)
					{
						attribut.Valgmuligheder[i][0] = værdi;
						break;
					}
				}
				return true;
			}
			
			return false;
		}

		public bool RetAttribut(string navn, KampagneType type, int position)
		{
			if (dbFacade.RetAttribut(nuværendeAttribut.KampagneAttributID, navn, (int)type, nuværendeKampagne.KampagneID, position))
			{
				nuværendeAttribut.Navn = navn;
				nuværendeAttribut.Type = type;

				return true;
			}
			return false;
		}

		public bool SletAttribut(long attID)
		{
			if (dbFacade.SletAttribut(attID))
			{
				nuværendeKampagne.SletAttribut(attID);
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

		public void TilføjScenarie(string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningValgfri, bool overnatningValgfri, string andetInfo)
		{
			long id = dbFacade.TilføjScenarie(titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningValgfri, overnatningValgfri, andetInfo, nuværendeKampagne.KampagneID);
			if (id != -1)
			{
				nuværendeKampagne.TilføjScenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningValgfri, overnatningValgfri, andetInfo);
			}
		}
	}
}
