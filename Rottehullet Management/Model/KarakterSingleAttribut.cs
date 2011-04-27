﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	class KarakterSingleAttribut : KarakterAttribut
	{
		string værdi;

		public KarakterSingleAttribut(string værdi, KampagneAttribut attribut)
			: base(attribut)
		{
			this.værdi = værdi;
		}

		public string Værdi
		{
			get { return værdi; }
			set { værdi = value; }
		}
	}
}