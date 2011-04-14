using System;
using System.Collections.Generic;
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

        public BrugerKlient()
        {
            brugerdbfacade = new BrugerDBFacade(this);
            brugercollection = new BrugerCollection();
            kampagnecollection = new KampagneCollection();
        }

        public bool Opretbruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer, string allergi, string andet)
        {
            long brugerID = brugerdbfacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer, allergi, andet);
            
            if (brugerID>0)
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
                kampagnecollection.GenopretKampagne(kamID, navn, beskrivelse, hjemmeside, bruger, status);
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

        public System.Collections.IEnumerator GetKampagneIterator()
        {
            return kampagnecollection.GetKampagneIterator();
        }

		public string KrypterKodeord(string originalPassword)
		{
			//Declarations
			Byte[] originalBytes;
			Byte[] encodedBytes;
			MD5 md5;

			//Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
			md5 = new MD5CryptoServiceProvider();
			originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
			encodedBytes = md5.ComputeHash(originalBytes);

			//Convert encoded bytes back to a 'readable' string
			return BitConverter.ToString(encodedBytes);
		}
    }

    
}
