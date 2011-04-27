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

        public KarakterAttribut(KampagneAttribut kampagneattribut)
        {
            this.kampagneattribut = kampagneattribut;
        }
    }
}
