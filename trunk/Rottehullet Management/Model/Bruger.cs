using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    public class Bruger : IBruger
    {
        private long brugerID;
        private string email;
        private string navn;
        private DateTime fødselsdag;
        private long tlf;
        private long nød_tlf;
        private string allergi;
        private string andet;
        private bool vegetar;
        private bool veganer;
        private List<Karakter> karakterer;
        

        // constructor en Bruger
        public Bruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string andet,string allergi)
        {
            this.brugerID = brugerID;
            this.email = email;
            this.navn = navn;
            this.fødselsdag = fødselsdag;
            this.tlf = tlf;
            this.nød_tlf = nød_tlf;
            this.vegetar = vegetar;
            this.veganer = veganer;
            this.allergi = allergi;
            this.andet = andet;
            karakterer = new List<Karakter>();
        }

        public Karakter TilføjKarakter(long karakterID, Kampagne kampagne)
        {
            karakterer.Add(new Karakter(karakterID, kampagne));
			return karakterer[karakterer.Count() - 1];
        }

		public Karakter GenopretKarakter(long karakterID, Kampagne kampagne)
		{
			Karakter karakter = new Karakter(karakterID, kampagne);
			karakterer.Add(karakter);
			return karakter;
		}

		public void TilføjAttribut(long karakterID, KampagneAttribut attribut, string værdi, long id)
        {
            Karakter karakter = FindKarakter(karakterID);
            karakter.TilføjVærdi(attribut, værdi, id);
        }

        public void TilføjAttribut(long karakterID, KampagneAttribut attribut, KampagneMultiAttributValgmulighed valg, long id)
        {
            Karakter karakter = FindKarakter(karakterID);
            karakter.TilføjVærdi(attribut, valg, id);
        }

		public void TilmeldKarakterTilScenarie(long karakterID, Scenarie scenarie, bool spiser, bool overnatter)
		{
			Karakter karakter = FindKarakter(karakterID);
			karakter.TilmedTilScenarie(scenarie, spiser, overnatter);
		}
		
        public Karakter FindKarakter(long karakterID)
        {
            foreach (Karakter karakter in karakterer)
            {
                if (karakter.KarakterID == karakterID)
                {
                    return karakter;
                }
            }
            return null;
        }

        public IEnumerator GetVærdiIterator(long karakterID)
        {
            Karakter karakter = FindKarakter(karakterID);
            if (karakter != null)
            {
                return karakter.GetVærdiIterator();
            }
            return null;
        }

        public IEnumerator GetKarakterIterator()
        {
            return karakterer.GetEnumerator();
        }

        public IKarakter GetKarakter(long karakterID)
        {
            IKarakter karakter = (IKarakter)FindKarakter(karakterID);
            return karakter;
        }

		#region properties
		public bool Veganer
        {
            get { return veganer; }
            set { veganer = value; }
        }

        public bool Vegetar
        {
            get { return vegetar; }
            set { vegetar = value; }
        }

        public long NødTlf
        {
            get { return nød_tlf; }
            set { nød_tlf = value; }
        }

        public long Tlf
        {
            get { return tlf; }
            set { tlf = value; }
        }

        public DateTime Fødselsdag
        {
            get { return fødselsdag; }
            set { fødselsdag = value; }
        }

        public string Navn
        {
            get { return navn; }
            set { navn = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public long BrugerID
        {
            get { return brugerID; }
        }

        public string Allergi
        {
            get { return allergi; }
            set { allergi = value; }
        }

        public string Andet
        {
            get { return andet; }
            set { andet = value; }
		}
		#endregion
    }
}
