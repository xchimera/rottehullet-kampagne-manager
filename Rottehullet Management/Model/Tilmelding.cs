using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	class Tilmelding
	{
		#region attributter
		Karakter karakter;
		Scenarie scenarie;
		bool spiser;
		bool overnatter;
		#endregion

		public Tilmelding(Karakter karakter, Scenarie scenarie, bool spiser, bool overnatter)
		{
			this.karakter = karakter;
			this.scenarie = scenarie;
			this.spiser = spiser;
			this.overnatter = overnatter;
		}
	}
}
