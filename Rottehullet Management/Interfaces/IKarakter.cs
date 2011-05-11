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
    }
}
