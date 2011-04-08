using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
	class KampagneMultiAttribut : KampagneAttribut
	{
		private List<string[]> valgmuligheder;

		public KampagneMultiAttribut(string navn, KampagneType type, List<string[]> valgmuligheder, long kampagneAttributID)
			: base(navn, type, kampagneAttributID)
		{
			this.valgmuligheder = valgmuligheder;
		}

		public List<string[]> Valgmuligheder
		{
			get { return valgmuligheder; }
			set { valgmuligheder = value; }
		}
	}
}
