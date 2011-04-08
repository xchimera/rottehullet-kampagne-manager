using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
	public interface IKampagne
	{
		long KampagneID { get; }
		string Navn { get; set; }
		string Beskrivelse { get; set; }
		string Hjemmeside { get; set; }
		//Bruger Topbruger { get; set; }
	}
}
