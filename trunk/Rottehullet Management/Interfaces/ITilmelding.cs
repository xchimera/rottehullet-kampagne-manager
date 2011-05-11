using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
	public interface ITilmelding
	{
		int AntalOvernatninger { get; }
		bool Spiser { get; }
		IKarakter Karakter { get; }
		string KarakterNavn { get; }
		string BrugerNavn { get; }
		long BrugerTlf { get; }
		long BrugerNødTlf { get; }
		string BrugerInfo { get; }
		string BrugerAllergi { get; }
	}
}
