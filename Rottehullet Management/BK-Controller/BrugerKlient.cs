using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
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
		Scenarie nuværendeScenarie;

		public BrugerKlient()
		{
			brugerdbfacade = new BrugerDBFacade(this);
			brugercollection = new BrugerCollection();
			kampagnecollection = new KampagneCollection();
			nuværendeKampagne = null;
			nuværendeScenarie = null;
		}

		public bool Connect()
		{
			return brugerdbfacade.Connect();
		}

		//Lavet af Denny
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

		//Thorbjørn
		public bool RetBruger(string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer,
								string allergi, string andet)
		{
			if (brugerdbfacade.RetBruger(bruger.BrugerID,navn,fødselsdag,tlf,nød_tlf,vegetar,veganer,allergi,andet))
			{
				bruger.RetBruger(navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
				return true;
			}
			return false;
		}

		//Lavet af Thorbjørn og René
		public long Login(string email, string kodeord, bool hashedAdgangskode)
		{
			if (!hashedAdgangskode)
				kodeord = KrypterKodeord(kodeord);
			long brugerID = brugerdbfacade.Login(email, kodeord);
			if (brugerID > 0)
				brugerdbfacade.HentTilmeldingerTilBruger(bruger);
			return brugerID;
		}

		//Lavet af Søren
		public void GenopretBruger(long brugerID, string email, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
		{
			bruger = new Bruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, andet, allergi);
		}

		//Lavet af René
		public bool TilmeldKarakterTilScenarie(long karakterID, long scenarieID, int antalOvernatninger, bool spiser)
		{
			long id = brugerdbfacade.TilmeldKarakterTilScenarie(karakterID, scenarieID, antalOvernatninger, spiser);
			if (id != -1)
			{
				Scenarie scenarie = nuværendeKampagne.FindScenarie(scenarieID);
				bruger.TilmeldKarakterTilScenarie(karakterID, scenarie, spiser, antalOvernatninger);
				return true;
			}
			return false;
		}

		//Lavet af René
		public void GenopretScenarie(long id, string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
		{
			nuværendeScenarie = nuværendeKampagne.TilføjScenarie(id, titel, beskrivelse, tid, sted, pris, overnatning, spisning, spisningTvungen, overnatningTvungen, andetInfo);
		}

		//Lavet af René
		public IScenarie HentNuværendeScenarie()
		{
			return nuværendeScenarie;
		}

		//Lavet af René
		internal Scenarie FindScenarie(long scenarieID)
		{
			return kampagnecollection.FindScenarie(scenarieID);
		}

		//Lavet af Søren
		public void GenopretKarakter(long karakterID, long kampagneID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			bruger.TilføjKarakter(karakterID, kampagne);
		}

		//Lavet af Søren
        public void GenopretKarakter(long karakterID, long kampagneID, KarakterStatus status)
        {
            Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
            bruger.GenopretKarakter(karakterID, kampagne, status);
        }

		//Lavet af René
		public void GenopretAttributVærdi(long karakterID, long kampagneID, long attributID, string værdi, long karakterattributID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			KampagneAttribut attribut = kampagne.FindAttribut(attributID);

            bruger.TilføjAttribut(karakterID, attribut, værdi, karakterattributID);
		}

		//Lavet af René
		public void GenopretMultiattributVærdi(long karakterID, long kampagneID, long attributID, long multientryID, long karakterattributID)
		{
			Kampagne kampagne = kampagnecollection.FindKampagne(kampagneID);
			KampagneMultiAttribut attribut = (KampagneMultiAttribut)kampagne.FindAttribut(attributID);
			KampagneMultiAttributValgmulighed valg = attribut.FindValgmulighed(multientryID);
			bruger.TilføjAttribut(karakterID, attribut, valg, karakterattributID);
		}

		//Lavet af Søren
		public KampagneAttribut GenopretAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagnecollection.GenopretAttribut(kamID, attributID, navn, type);
		}

		//Lavet af Søren
		public KampagneMultiAttribut GenopretMultiAttribut(long kamID, long attributID, string navn, KampagneAttributType type, int position)
		{
			return kampagnecollection.GenopretMultiAttribut(kamID, attributID, navn, type);
		}

		//Lavet af Søren
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

		//Lavet af Søren
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

        public IKarakter GetKarakter(long karakterID)
        {
            return bruger.GetKarakter(karakterID);
        }

		public IEnumerator GetVærdiIterator(long karakterID)
		{
			return bruger.GetVærdiIterator(karakterID);
		}

		public IEnumerator GetValgmulighederIterator(long attributID, long kampagneID)
		{
			return kampagnecollection.GetValgmulighederIterator(kampagneID, attributID);
		}

		//Lavet af Søren
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

        public bool NyKarakter(IEnumerator værdi, IEnumerator valgID, KarakterStatus status)
        {
            if (brugerdbfacade.OpretKarakter(værdi, valgID, nuværendeKampagne.KampagneID, bruger.BrugerID, status))
            {
                return true;
            }
            return false;
        }

        public bool OpdaterKarakter(IEnumerator værdi, IEnumerator valgID, long gammelkarakterID, KarakterStatus status)
        {
            if (brugerdbfacade.OpdaterKarakter(værdi, valgID, nuværendeKampagne.KampagneID, bruger.BrugerID, gammelkarakterID, status))
            {
                return true;
            }
            return false;
        }

		/// <summary>
		/// Henter en kampagne og returnere den. (Bruges kun i DBFacaden)
		/// Lavet af René
		/// </summary>
		/// <param name="kampagneID"></param>
		/// <returns></returns>
		internal Kampagne HentKampagne(long kampagneID)
		{
			return kampagnecollection.FindKampagne(kampagneID);
		}

		public bool hentLoginData(out string brugernavn, out string password)
		{
			try
			{
				StreamReader hentdata = File.OpenText("DATA1");
				brugernavn = hentdata.ReadLine();
				password = hentdata.ReadLine();
				hentdata.Dispose();
				hentdata.Close();
				return true;
			}
			catch (FileNotFoundException)
			{
				brugernavn = "";
				password = "";
				return false;
			}
		}

		//Lavet af René
		public void GemLoginData(string brugernavn, string password)
		{
			//Laver en ny tom fil, så der ikke opstår problemer med gamle data
			File.Create("DATA1").Dispose();

			StreamWriter skrivTilFil = File.CreateText("DATA1");
			skrivTilFil.WriteLine(brugernavn);
			skrivTilFil.WriteLine(KrypterKodeord(password));
			skrivTilFil.Dispose();
			skrivTilFil.Close();
		}

		//Lavet af René
		public void GemLoginData(string brugernavn)
		{
			//Laver en ny tom fil, så der ikke opstår problemer med gamle data
			File.Create("DATA1").Dispose();

			StreamWriter skrivTilFil = File.CreateText("DATA1");
			skrivTilFil.WriteLine(brugernavn);
			skrivTilFil.Dispose();
			skrivTilFil.Close();
		}

		//Lavet af Søren
        public IKampagne FindKampagne(long kampagneID)
        {
            nuværendeKampagne = kampagnecollection.FindKampagne(kampagneID);
			nuværendeScenarie = nuværendeKampagne.HentNuværendeScenarie();
            return nuværendeKampagne;
        }

		//Lavet af Thorbjørn
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

		//Lavet af Thorbjørn
		public string Dekrypt(string streng)
		{
			byte[] resultat;
			UTF8Encoding utf8 = new UTF8Encoding();

			//Laver vores nøgle "detteErEnNøgle" om til en 128 bit nøgle ved at lave den om til et MD5 hash
			MD5CryptoServiceProvider hash = new MD5CryptoServiceProvider();
			byte[] nøgle = hash.ComputeHash(utf8.GetBytes("detteErEnNøgle"));
			nøgle = utf8.GetBytes("4D92199549E0F2EF009B4160");

			TripleDESCryptoServiceProvider algoritme = new TripleDESCryptoServiceProvider();
			algoritme.Key = nøgle;
			algoritme.Mode = CipherMode.ECB;//Vi vil kun kode en gang
			algoritme.Padding = PaddingMode.PKCS7;//padding for extra bytes i hver blok

			byte[] data = Convert.FromBase64String(streng);

			try
			{
				ICryptoTransform dekryption = algoritme.CreateDecryptor();
				resultat = dekryption.TransformFinalBlock(data, 0, data.Length);
			}
			finally
			{
				algoritme.Clear();
				hash.Clear();
			}
			return utf8.GetString(resultat);
		}

		//Lavet af René
		public bool TjekOmBrugerErTilmeldtNuværendeScenarie()
		{
			if (bruger.TjekOmTilmeldtTilScenarie(nuværendeScenarie))
				return true;
			return false;
		}

		public IBruger Bruger
		{
			get { return (IBruger)bruger; }
		}
	}
}