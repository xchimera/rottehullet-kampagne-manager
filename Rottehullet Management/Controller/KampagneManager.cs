using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Controller
{
    public class KampagneManager
    {
        List<string[]> rettigheder;
        BrugerCollection brugercollection;
		DBFacade dbFacade;

        public KampagneManager()
        {
			dbFacade = new DBFacade(this);
            brugercollection = new BrugerCollection();
        }


        public void IndsætRettighed(string kampagneID, string navn, string type)
        {
            string[] rettighed = new string[3] {kampagneID, navn, type};
            rettigheder.Add(rettighed);
        }

        //TODO: der skal laves C# til DBFacade til tilføj bruger
        public bool Opretbruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            if (dbFacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer) == null)
            {
                brugercollection.OpretBruger(email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
                return true;
            }
            return false;
        }

    }
}
