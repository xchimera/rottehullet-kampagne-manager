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
        public bool Tilføjbruger(string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            if (DBFacade.Tilføjbruger(email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer) == null)
            {
                brugercollection.Tilføjbruger(email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
                return true;
            }
            return false;
        }

    }
}
