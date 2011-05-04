using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BrugerCollection
    {
		private List<Bruger> listBrugere;

		public BrugerCollection()
        {
            listBrugere = new List<Bruger>();
        }

        #region Metoder


        public Bruger OpretBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string andet, string allergi)
        {
            listBrugere.Add(new Bruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi)); // smider den nye bruger i en liste (collection af brugere)
			return listBrugere[listBrugere.Count() - 1];
        }

        //til brug af admin da der kun skal bruges brugerID og navn
        public void OpretBruger(long brugerID, string navn)
        {
            listBrugere.Add(new Bruger(brugerID, "", navn, DateTime.Now, 0, 0, false, false, "", ""));
        }

        public Bruger FindBruger(long brugerID)
        {
            foreach (Bruger bruger in listBrugere)
            {
                if (brugerID == bruger.BrugerID)
                {
                    return bruger;
                }
            }
            return null;
        }

		public Karakter FindKarakter(long karakterID)
		{
			Karakter karakter;
			
			foreach (Bruger bruger in ListBrugere)
			{
				karakter = bruger.FindKarakter(karakterID);
				if (karakter != null)
				{
					return karakter;
				}
			}
			return null;
		}

		public Bruger FindKaraktersBruger(long karakterID)
		{
			Karakter karakter;

			foreach (Bruger bruger in ListBrugere)
			{
				karakter = bruger.FindKarakter(karakterID);
				if (karakter != null)
				{
					return bruger;
				}
			}
			return null;
		}

		public IEnumerator GetBrugerIterator()
        {
            return listBrugere.GetEnumerator();
        }

		public List<Karakter> HentAlleKarakterer()
		{
			List<Karakter> karakterliste = new List<Karakter>();
			IEnumerator karakteriterator;

			foreach (Bruger bruger in ListBrugere)
			{
				karakteriterator = bruger.GetKarakterIterator();
				karakteriterator.Reset();
				while (karakteriterator.MoveNext())
				{
					karakterliste.Add((Karakter)karakteriterator.Current);
				}
			}
			return karakterliste;
		}

		public List<Karakter> HentAlleKaraktererPåKampagne(long kampagneID)
		{
			List<Karakter> karakterliste = new List<Karakter>();
			IEnumerator karakteriterator;

			foreach (Bruger bruger in ListBrugere)
			{
				karakteriterator = bruger.GetKampagnesKarakterIterator(kampagneID);
				karakteriterator.Reset();
				while (karakteriterator.MoveNext())
				{
					karakterliste.Add((Karakter)karakteriterator.Current);
				}
			}
			return karakterliste;
		}

		public Karakter TilføjKarakter(Bruger bruger, long karakterID, Kampagne kampagne)
		{
			return bruger.TilføjKarakter(karakterID, kampagne);
		}

		public void TømKarakterer()
		{
			foreach (Bruger bruger in listBrugere)
			{
				bruger.TømKarakterer();
			}
		}
        #endregion

		public List<Bruger> ListBrugere
		{
			get { return listBrugere; }
		}
    }
}
