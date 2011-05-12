using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class KarakterMultiAttribut : KarakterAttribut
	{
		//Klasse lavet af René

		KampagneMultiAttributValgmulighed valg;

		public KarakterMultiAttribut(KampagneMultiAttributValgmulighed valg, KampagneAttribut attribut, long id)
			: base(attribut, id)
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
