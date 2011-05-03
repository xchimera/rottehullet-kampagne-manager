using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;
using Interfaces;

namespace Model
{
    public abstract class KarakterAttribut : IKarakterAttribut
    {
        private KampagneAttribut kampagneattribut;
		long id;

        public KarakterAttribut(KampagneAttribut kampagneattribut, long id)
        {
            this.kampagneattribut = kampagneattribut;
        }

        public IKampagneAttribut Kampagneattribut
        {
            get { return kampagneattribut; }
        }
    }
}
