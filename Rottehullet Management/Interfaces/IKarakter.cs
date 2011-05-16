using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Enum;

namespace Interfaces
{
    public interface IKarakter
    {
		long KarakterID { get; }
		IEnumerator GetVærdiIterator();
		IKampagne Kampagne { get; }
        IEnumerator HentVærdier();
		KarakterStatus Status { get; }
		IBruger Bruger { get; }
		string this[string attributNavn] { get; }
		string FindAttributVærdi(long kampagneattributID);
		string BrugersNavn { get; }
		string BrugerAllergi { get; }
		string BrugerVeganer { get; }
		string BrugerVegetar { get; }
		string BrugerAndetInfo { get; }
		int BrugerAlder { get; }
		long BrugerTlf { get; }
		long BrugerNødTlf { get; }
		string Navn { get; }
    }
}
