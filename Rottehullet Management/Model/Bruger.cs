using System;
using System.Collections.Generic;
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
        private bool vegetar;
        private bool veganer;

        // constructor en Bruger
        public Bruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            this.brugerID = brugerID;
            this.email = email;
            this.navn = navn;
            this.fødselsdag = fødselsdag;
            this.tlf = tlf;
            this.nød_tlf = nød_tlf;
            this.vegetar = vegetar;
            this.veganer = veganer;
        }


        // Properties
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
    }
}
