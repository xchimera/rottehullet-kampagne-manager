using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
	public class KampagneMultiAttribut : KampagneAttribut
	{
		private List<KampagneMultiAttributValgmulighed> valgmuligheder;

		public KampagneMultiAttribut(string navn, KampagneAttributType type, List<KampagneMultiAttributValgmulighed> valgmuligheder, long kampagneAttributID)
			: base(navn, type, kampagneAttributID)
		{
			this.valgmuligheder = valgmuligheder;
		}

        public KampagneMultiAttribut(string navn, KampagneAttributType type, long kampagneAttributID)
            : base(navn, type, kampagneAttributID)
        {
            valgmuligheder = new List<KampagneMultiAttributValgmulighed>();
        }

		public void TilføjValgmulighed(KampagneMultiAttributValgmulighed valgmulighed)
		{
			valgmuligheder.Add(valgmulighed);
		}

		public void FjernValgmulighed(long entryID)
		{
			foreach (KampagneMultiAttributValgmulighed valgmulighed in valgmuligheder)
			{
				if (valgmulighed.Id == entryID)
				{
					valgmuligheder.Remove(valgmulighed);
					break;
				}
			}
		}

		public List<KampagneMultiAttributValgmulighed> Valgmuligheder
		{
			get { return valgmuligheder; }
			set { valgmuligheder = value; }
		}
	}
}
