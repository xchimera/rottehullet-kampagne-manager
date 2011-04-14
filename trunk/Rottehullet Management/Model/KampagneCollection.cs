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

		public void OpretKampagne(string navn, Bruger topbruger, long kampagneID)
		{
			Kampagne kampagne = new Kampagne(navn, topbruger, kampagneID, KampagneStatus.Oprettet);
			kampagner.Add(kampagne);
		}

		public Kampagne GenopretKampagne(long kamID, string navn, string beskrivelse, string hjemmeside, Bruger bruger, KampagneStatus status)
		{
			Kampagne kampagne = new Kampagne(kamID, navn, beskrivelse, hjemmeside, bruger, status);
			kampagner.Add(kampagne);
			return kampagner[kampagner.Count - 1];
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
	}
}
