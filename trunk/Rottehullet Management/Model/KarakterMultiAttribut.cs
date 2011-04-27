using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class KarakterMultiAttribut : KarakterAttribut
	{
		KampagneMultiAttributValgmulighed valg;

		public KarakterMultiAttribut(KampagneMultiAttributValgmulighed valg, KampagneAttribut attribut)
			: base(attribut)
		{
			this.valg = valg;
		}

		public KampagneMultiAttributValgmulighed Valg
		{
			get { return valg; }
			set { valg = value; }
		}

		public string Værdi
		{
			get { return valg.Værdi; }
		}
	}
}
