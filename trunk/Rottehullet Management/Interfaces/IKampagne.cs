using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Enum;

namespace Interfaces
{
	public interface IKampagne
	{
		long KampagneID { get; }
		string Navn { get; set; }
		string Beskrivelse { get; }
		string Hjemmeside { get; }
        KampagneStatus Status { get; }
        IEnumerator HentAttributter();
        IScenarie HentNæsteScenarie();

	}
}
