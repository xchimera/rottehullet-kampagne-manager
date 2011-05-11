using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IBruger
    {
		long BrugerID { get; }
		string Email { get; }
		string Navn { get; }
		DateTime Fødselsdag { get; }
		long Tlf { get; }
		long NødTlf { get; }
		bool Vegetar { get; }
		bool Veganer { get; }
		string Andet { get; }
		string Allergi { get; }
		IEnumerator FindGamleKarakterer(IKarakter karakterInd);
    }
}
