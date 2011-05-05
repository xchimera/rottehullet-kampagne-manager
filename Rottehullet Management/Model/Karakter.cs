using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;
using Enum;

namespace Model
{
    public class Karakter : IKarakter
    {
        Dictionary<string, KarakterAttribut> attributter;   //string er karakterattributID
        long karakterID;
		Kampagne kampagne;
		List<Tilmelding> scenarieTilmeldinger;
		KarakterStatus status;

		public Karakter(long karakterID, Kampagne kampagne)
        {
            this.karakterID = karakterID;
            this.kampagne = kampagne;
			attributter = new Dictionary<string, KarakterAttribut>();
			scenarieTilmeldinger = new List<Tilmelding>();
        }
		#region metoder
		/// <summary>
		/// Tilføjer en single attribut til karakteren.
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="værdi"></param>
        public void TilføjVærdi(KampagneAttribut kampagneAttribut, string værdi, long id)
        {
			KarakterSingleAttribut attribut = new KarakterSingleAttribut(værdi, kampagneAttribut, id);
            attributter.Add(kampagneAttribut.Navn, attribut);
        }

		/// <summary>
		/// Tilføjer en multi attribut til karakteren.
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="valg"></param>
		public void TilføjVærdi(KampagneAttribut kampagneAttribut, KampagneMultiAttributValgmulighed valg, long id)
		{
			KarakterMultiAttribut attribut = new KarakterMultiAttribut(valg, kampagneAttribut, id);
			attributter.Add(kampagneAttribut.Navn, attribut);
		}

		public void TilmedTilScenarie(Scenarie scenarie, bool spiser, bool overnatter)
		{
			Tilmelding tilmelding = new Tilmelding(this, scenarie, spiser, overnatter);
			scenarieTilmeldinger.Add(tilmelding);
		}

		public string FindAttributVærdi(long kampagneattributID)
		{
			foreach (KarakterAttribut attribut in attributter.Values)
			{
				if(attribut.Kampagneattribut.KampagneAttributID == kampagneattributID)
				{
					if (attribut.Kampagneattribut.Type == KampagneAttributType.Singleline || attribut.Kampagneattribut.Type == KampagneAttributType.Multiline)
					{
						KarakterSingleAttribut singleattribut = (KarakterSingleAttribut)attribut;
						return singleattribut.Værdi;
					}
					else
					{
						KarakterMultiAttribut multiattribut = (KarakterMultiAttribut)attribut;
						return multiattribut.Valg.Værdi;
					}
				}
			}
			return null;
		}

        public IEnumerator HentVærdier()
        {
            List<string> returliste = new List<string>();
            foreach (KarakterAttribut karakterAttribut in attributter.Values)
            {
                if (karakterAttribut.Kampagneattribut.Type == KampagneAttributType.Singleline || karakterAttribut.Kampagneattribut.Type == KampagneAttributType.Multiline)
                {
                    KarakterSingleAttribut singleattribut = (KarakterSingleAttribut)karakterAttribut;
                    returliste.Add(singleattribut.Værdi);
                }
                else
                {
                    KarakterMultiAttribut multiattribut = (KarakterMultiAttribut)karakterAttribut;
                    returliste.Add(multiattribut.Valg.Værdi);
                }
            }
            return returliste.GetEnumerator();
        }

		#endregion

		#region Properties
		public IEnumerator GetVærdiIterator()
		{
            List<KarakterAttribut> karakterAttributter = new List<KarakterAttribut>();
            foreach (KarakterAttribut karakterAttribut in attributter.Values)
            {
                karakterAttributter.Add(karakterAttribut);
            }
		    return karakterAttributter.GetEnumerator();
		}

		public long KarakterID
		{
			get { return karakterID; }
		}

		public KarakterStatus Status
		{
			get { return status; }
			set { status = value; }
		}

		public IKampagne Kampagne
		{
			get { return kampagne; }
		}

		public string this[string attributNavn]
		{
			get
			{
				KarakterAttribut værdi = attributter[attributNavn];
				if (værdi is KarakterMultiAttribut)
				{
					return ((KarakterMultiAttribut)værdi).Værdi;
				}
				else if (værdi is KarakterSingleAttribut)
				{
					return ((KarakterSingleAttribut)værdi).Værdi;
				}
				return null;
			}
		}
		#endregion
    }
}
