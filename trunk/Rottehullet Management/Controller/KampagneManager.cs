using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Interfaces;

namespace Controller
{
    public class KampagneManager
    {
        List<string[]> rettigheder;
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

        public bool Login(string email, string kodeord)
        {
            if (dbFacade.Login(email, kodeord))
            {
                return true;
            }
            return false;
        }

        public bool OpretKampagne(string navn, long topbrugerID)
        {
            int kampagneID = dbFacade.OpretKampagne(navn, topbrugerID);
            if (kampagneID > 0)
            {//TODO: opret kampagne her
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

		public bool TilføjSingleAttribut(string navn, Type type)
		{
			if (true)
			{
				
			}
			return false;
		}
    }
}
