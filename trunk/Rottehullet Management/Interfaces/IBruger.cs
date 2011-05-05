using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IBruger
    {
        long BrugerID {get;}
        string Email {get; set;}
        string Navn {get;}
        DateTime Fødselsdag {get;}
        long Tlf {get; set;}
        long NødTlf {get; set;}
        bool Vegetar {get; set;}
		bool Veganer { get; set; }
		IEnumerator FindGamleKarakterer(IKarakter karakterInd);
    }
}
