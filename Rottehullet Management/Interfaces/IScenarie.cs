using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
	public interface IScenarie
	{
		long Id { get; }
		string Sted { get; }
		string Beskrivelse { get; }
		string Titel { get; }
		double Pris { get; }
		DateTime Tid { get; }
		int Overnatning { get; }
		bool OvernatningTvungen { get; }
		bool SpisningTvungen { get; }
		bool Spisning { get; }
		string AndetInfo { get; }
	}
}
