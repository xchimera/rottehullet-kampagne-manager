using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IKarakter
    {
		long KarakterID { get; }
		IEnumerator GetGetVærdiIterator();
		IKampagne Kampagne { get; }
		
    }
}
