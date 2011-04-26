using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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


       
    }
}
