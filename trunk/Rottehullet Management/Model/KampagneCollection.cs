using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;
namespace Model
{
	public class KampagneCollection
	{
		List<Kampagne> kampagner;

		public KampagneCollection()
		{
			kampagner = new List<Kampagne>();
		}

		public void OpretKampagne(string navn, long kampagneID, KampagneStatus status)
		{
			Kampagne kampagne = new Kampagne(navn, kampagneID, KampagneStatus.Oprettet);
			kampagner.Add(kampagne);
		}

		public Kampagne GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, KampagneStatus status)
		{
			Kampagne kampagne = new Kampagne(kamID, navn, beskrivelse, hjemmeside, status);
			kampagner.Add(kampagne);
            return kampagne;
		}

        /// <summary>
        /// genopret single attribut
        /// </summary>
        /// <param name="kamID">kampagne ID</param>
        /// <param name="attributID">attributtens ID</param>
        /// <param name="navn">attributtens navn</param>
        /// <param name="type">attributtens type</param>
        public KampagneAttribut GenopretAttribut(long kamID, long attributID, string navn, KampagneAttributType type)
        {
            Kampagne kampagne = FindKampagne(kamID);
            if (kampagne != null)
            {
                return kampagne.GenopretAttribut(attributID, navn, type);
                
            }
            return null;
        }

        public KampagneMultiAttribut GenopretMultiAttribut(long kamID, long attributID, string navn, KampagneAttributType type)
        {
            Kampagne kampagne = FindKampagne(kamID);
            if (kampagne != null)
            {
                return kampagne.GenopretMultiAttribut(attributID, navn, type);
            }
            return null;
        }

        public Kampagne FindKampagne(long kampagneID)
        {
            foreach (Kampagne kampagne in kampagner)
            {
                if (kampagne.KampagneID == kampagneID)
                {
                    return kampagne;
                }
            }
            return null;
        }

		public Kampagne FindKampagne(string navn)
		{
			foreach (Kampagne kampagne in kampagner)
			{
				if (kampagne.Navn == navn)
					return kampagne;
			}
			return null;
		}

        public IEnumerator GetKampagneIterator()
        {
            return kampagner.GetEnumerator();
        }

        public IEnumerator GetValgmulighederIterator(long kampagneID, long attributID)
        {
            Kampagne kampagne = FindKampagne(kampagneID);
            return kampagne.GetValgmulighederIterator(attributID);
        }
	}
}
