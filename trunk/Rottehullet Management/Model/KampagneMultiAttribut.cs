using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
	public class KampagneMultiAttribut : KampagneAttribut
	{
		private List<string[]> valgmuligheder;

		public KampagneMultiAttribut(string navn, KampagneAttributType type, List<string[]> valgmuligheder, long kampagneAttributID)
			: base(navn, type, kampagneAttributID)
		{
			this.valgmuligheder = valgmuligheder;
		}

        public KampagneMultiAttribut(string navn, KampagneAttributType type, long kampagneAttributID)
            : base(navn, type, kampagneAttributID)
        {
            valgmuligheder = new List<string[]>();
        }

		public void TilføjValgmulighed(string[] valgmulighed)
		{
			valgmuligheder.Add(valgmulighed);
		}

		public void FjernValgmulighed(long entryID)
		{
			for (int i = 0; i < valgmuligheder.Count; i++)
			{
				if (long.Parse(valgmuligheder[i][1]) == entryID)
				{
					valgmuligheder.RemoveAt(i);
					break;
				}
			}
		}

		public List<string[]> Valgmuligheder
		{
			get { return valgmuligheder; }
			set { valgmuligheder = value; }
		}
	}
}
