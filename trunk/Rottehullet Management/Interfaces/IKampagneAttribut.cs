using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enum;

namespace Interfaces
{
	public interface IKampagneAttribut
	{
		KampagneType Type { get; }
		long KampagneAttributID { get; }
		string Navn { get; }

	}
}
