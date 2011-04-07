using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
    public class KampagneAttribut
    {
		private int kampagneAttributID;
		private string navn;
		private Type type;

		public KampagneAttribut(string navn, Type type, int kampagneAttributID)
		{
			this.navn = navn;
			this.type = type;
			this.kampagneAttributID = kampagneAttributID;
		}

		public Type Type
		{
			get { return type; }
			set { type = value; }
		}

		public string Navn
		{
			get { return navn; }
			set { navn = value; }
		}

		public int KampagneAttributID
		{
			get { return kampagneAttributID; }
		}
    }
}
