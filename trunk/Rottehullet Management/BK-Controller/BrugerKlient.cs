﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using Model;
using Controller;
using Enum;
using Interfaces;

namespace BK_Controller
{
	public class BrugerKlient
	{
		/// <summary>
		/// bruger her en anden databasefacade og controller da dette er brugerklienten
		/// og ikke skal have så mange rettigheder som en superbruger eller admin.
		/// normalt skulle der kun bruges en anden controller, men da dbfacaden for kampagnemanageren's constructor
		/// forventer at det en kompagnemanager af objectet KampagneManager, blev vi nødt til at lave en separat controller og dbfacade.
		/// </summary>
		BrugerDBFacade brugerdbfacade;
		BrugerCollection brugercollection;
		KampagneCollection kampagnecollection;
		Bruger bruger;
		Kampagne nuværendeKampagne;

		public BrugerKlient()
		{
			brugerdbfacade = new BrugerDBFacade(this);
			brugercollection = new BrugerCollection();
			kampagnecollection = new KampagneCollection();
			nuværendeKampagne = null;
		}

		public bool Opretbruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			long brugerID = brugerdbfacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);

			if (brugerID > 0)
			{
				brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
				return true;
			}
			return false;
		}



		public long Login(string email, string kodeord)
		{
			kodeord = KrypterKodeord(kodeord);
			long brugerID = brugerdbfacade.Login(email, kodeord);

			return brugerID;
		}

		public void GenopretBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			bruger = new Bruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
		}

		public bool TilmeldKarakterTilScenarie(long karakterID, long scenarieID, bool spiser, bool overnatter)
		{
			if (true)
			{
				Scenarie scenarie = nuværendeKampagne.FindScenarie(scenarieID);
				bruger.TilmeldKarakterTilScenarie(karakterID, scenarie, spiser, overnatter);
			}
			return false;
		}

		public void GenopretKarakter(long karakterID, long kampagneID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			bruger.TilføjKarakter(karakterID, kampagne);
		}

		public void GenopretAttributVærdi(long karakterID, long kampagneID, long attributID, string værdi, long karakterattributID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			KampagneAttribut attribut = kampagne.FindAttribut(attributID);

            bruger.TilføjAttribut(karakterID, attribut, værdi, karakterattributID);
		}

		public void GenopretMultiattributVærdi(long karakterID, long kampagneID, long attributID, long multientryID, long karakterattributID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)kampagne.FindAttribut(attributID);
			KampagneMultiAttributValgmulighed valg = attribut.FindValgmulighed(multientryID);
			bruger.TilføjAttribut(karakterID, attribut, valg, karakterattributID);
		}

		public KampagneAttribut GenopretAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type);
		}

		public KampagneMultiAttribut GenopretMultiAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagnecollection.GenopretMultiAttribut(kamID, attributID, navn, type);
			//return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type, valgmuligheder);
		}

		public bool GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, long topbrugerID, KampagneStatus status)
		{
			Bruger bruger;
			bruger = brugercollection.FindBruger(topbrugerID);
			if (bruger != null)
			{
				kampagnecollection.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, status);
				return true;
			}
			return false;
		}

		public bool GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, KampagneStatus status)
		{
			if (kampagnecollection.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, status) != null)
			{
				return true;
			}
			return false;
		}

		public IEnumerator GetKampagneIterator()
		{
			return kampagnecollection.GetKampagneIterator();
		}

		public IEnumerator GetKarakterIterator()
		{
			return bruger.GetKarakterIterator();
		}

		public IEnumerator GetVærdiIterator(long karakterID)
		{
			return bruger.GetVærdiIterator(karakterID);
		}

		public System.Collections.IEnumerator GetValgmulighederIterator(long attributID, long kampagneID)
		{
			return kampagnecollection.GetValgmulighederIterator(kampagneID, attributID);
		}

		public IEnumerator GetAttributIterator(long kampagneID)
		{
			IEnumerator kampagne = kampagnecollection.GetKampagneIterator();
			while (kampagne.MoveNext())
			{
				IKampagne ikampagne = (IKampagne)kampagne.Current;
				if (kampagneID == ikampagne.KampagneID)
				{
					return ikampagne.HentAttributter();
				}
			}
			return null;
		}

        public bool NyKarakter(IEnumerator værdi)
        {
            if (brugerdbfacade.NyKarakter(værdi, nuværendeKampagne.KampagneID, bruger.BrugerID))
            {
                return true;
            }
            return false;
        }


        public IKampagne FindKampagne(long kampagneID)
        {
            nuværendeKampagne = kampagnecollection.FindKampagne(kampagneID);
            return nuværendeKampagne;
        }

		public string KrypterKodeord(string kodeord)
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
	}
}