using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;
using Interfaces;

namespace Model
{
	public class KampagneAttribut : IKampagneAttribut
	{
		private long kampagneAttributID;
		private string navn;
		private KampagneAttributType type;

		public KampagneAttribut(string navn, KampagneAttributType type, long kampagneAttributID)
		{
			this.navn = navn;
			this.type = type;
			this.kampagneAttributID = kampagneAttributID;
		}

		public KampagneAttributType Type
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
