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
		int antalOvernatninger;
		#endregion

		public Tilmelding(Karakter karakter, Scenarie scenarie, bool spiser, int antalOvernatninger)
		{
			this.karakter = karakter;
			this.scenarie = scenarie;
			this.spiser = spiser;
			this.antalOvernatninger = antalOvernatninger;
		}

		public int AntalOvernatninger
		{
			get { return antalOvernatninger; }
			set { antalOvernatninger = value; }
		}

		public bool Spiser
		{
			get { return spiser; }
			set { spiser = value; }
		}
		public Scenarie Scenarie
		{
			get { return scenarie; }
		}
	}
}
