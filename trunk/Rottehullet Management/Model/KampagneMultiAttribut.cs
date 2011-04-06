using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	class KampagneMultiAttribut : KampagneAttribut
	{
		private List<string> valgmuligheder;

		public KampagneMultiAttribut(string navn, Type type, List<string> valgmuligheder, int kampagneAttributID)
			: base(navn, type, kampagneAttributID)
		{
			this.valgmuligheder = valgmuligheder;
		}

		public List<string> Valgmuligheder
		{
			get { return valgmuligheder; }
			set { valgmuligheder = value; }
		}
	}
}
