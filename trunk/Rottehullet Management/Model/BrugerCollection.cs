using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BrugerCollection
    {
        private List<Bruger> ListBrugere;

        public BrugerCollection()
        {
            ListBrugere = new List<Bruger>();
        }

        #region Tilføj


        public void OpretBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            ListBrugere.Add(new Bruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer)); // smider den nye bruger i en liste (collection af brugere)
        }

        public Bruger FindBruger(long brugerID)
        {
            foreach (Bruger bruger in ListBrugere)
            {
                if (brugerID == bruger.BrugerID)
                {
                    return bruger;
                }
            }
            return null;
        }

        #endregion
    }
}
