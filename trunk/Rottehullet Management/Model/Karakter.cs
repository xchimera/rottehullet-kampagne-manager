using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    public class Karakter : IKarakter
    {
		Dictionary<string, KarakterAttribut> værdier;
        long karakterID;
		Kampagne kampagne;
		List<Scenarie> tilmeld

        public Karakter(long karakterID, Kampagne kampagne)
        {
            this.karakterID = karakterID;
            this.kampagne = kampagne;
			værdier = new Dictionary<string, KarakterAttribut>();
        }
		#region metoder
		/// <summary>
		/// Tilføjer en single attribut til karakteren.
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="værdi"></param>
        public void TilføjVærdi(KampagneAttribut kampagneAttribut, string værdi)
        {
			KarakterSingleAttribut attribut = new KarakterSingleAttribut(værdi, kampagneAttribut);
            værdier.Add(kampagneAttribut.Navn, attribut);
        }

		/// <summary>
		/// Tilføjer en multi attribut til karakteren.
		/// </summary>
		/// <param name="kampagneAttribut"></param>
		/// <param name="valg"></param>
		public void TilføjVærdi(KampagneAttribut kampagneAttribut, KampagneMultiAttributValgmulighed valg)
		{
			KarakterMultiAttribut attribut = new KarakterMultiAttribut(valg, kampagneAttribut);
			værdier.Add(kampagneAttribut.Navn, attribut);
		}

		public void TilmedTilScenarie()
		#endregion

		#region Properties
		public IEnumerator GetVærdiIterator()
		{
			return værdier.GetEnumerator();
		}

		public long KarakterID
		{
			get { return karakterID; }
		}

		public IKampagne Kampagne
		{
			get { return kampagne; }
		}

		public string this[string navn]
		{
			get
			{
				KarakterAttribut værdi = værdier[navn];
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
