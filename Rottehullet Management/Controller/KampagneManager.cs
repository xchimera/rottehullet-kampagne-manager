using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Interfaces;
using Enum;

namespace Controller
{
    public class KampagneManager
    {
        List<string[]> rettigheder = new List<string[]>();
        BrugerCollection brugercollection;
		KampagneCollection kampagnecollection;
		DBFacade dbFacade;
		Kampagne nuværendeKampagne;

        public KampagneManager()
        {
			dbFacade = new DBFacade(this);
            brugercollection = new BrugerCollection();
			kampagnecollection = new KampagneCollection();
			nuværendeKampagne = null;
        }


        public void IndsætRettighed(string kampagneID, string navn, string type)
        {
            string[] rettighed = new string[3] {kampagneID, navn, type};
            rettigheder.Add(rettighed);
        }

        public bool Opretbruger(long brugerID, string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer))
            {
                brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
                return true;
            }
            return false;
        }

        public void TilføjBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
        }

        public long Login(string email, string kodeord)
        {
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
			return (dbFacade.HentKampagne(kamID));
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
            if(dbFacade.RetKampagneBeskrivelse(beskrivelse, kampagneID))
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


		public bool TilføjMultiAttribut(string navn, KampagneType type, int position, List<string> valgmuligheder)
		{
			long id = dbFacade.OpretKampagneSingleAttribut(navn, (int)type, nuværendeKampagne.KampagneID, position);
			foreach (string valgmulighed in valgmuligheder)
			{
				//dbFacade.
			}
			if (id != -1)
			{
				nuværendeKampagne.TilføjMultiAttribut(navn, type, valgmuligheder, nuværendeKampagne.KampagneID, position);
			}
			return false;
		}


		public System.Collections.IEnumerable GetRettigheder()
		{
			return rettigheder;
		}
    }
}
