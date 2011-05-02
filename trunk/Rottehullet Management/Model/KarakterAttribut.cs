using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Model
{
    public abstract class KarakterAttribut
    {
        KampagneAttribut kampagneattribut;
		long id;

        public KarakterAttribut(KampagneAttribut kampagneattribut, long id)
        {
            this.kampagneattribut = kampagneattribut;
        }
    }
}
