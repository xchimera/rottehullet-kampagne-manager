using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
    class KarakterAttribut
    {
		string værdi;
        KampagneAttribut kampagneattribut;

        public KarakterAttribut(string værdi, KampagneAttribut kampagneattribut)
        {
            this.værdi = værdi;
            this.kampagneattribut = kampagneattribut;
        }

		public string Værdi
		{
			get { return værdi; }
			set { værdi = value; }
		}
    }
}
