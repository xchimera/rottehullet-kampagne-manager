using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
	public class KampagneAttribut
	{
		private long kampagneAttributID;
		private string navn;
		private KampagneType type;

		public KampagneAttribut(string navn, KampagneType type, long kampagneAttributID)
		{
			this.navn = navn;
			this.type = type;
			this.kampagneAttributID = kampagneAttributID;
		}

		public KampagneType Type
		{
			get { return type; }
			set { type = value; }
		}

		public string Navn
		{
			get { return navn; }
			set { navn = value; }
		}

		public long KampagneAttributID
		{
			get { return kampagneAttributID; }
		}
	}
}
