using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
	public class Tilmelding : ITilmelding
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
			scenarie.TilføjTilmelding(this);
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

		public IKarakter Karakter
		{
			get { return karakter; }
		}

		public string KarakterNavn
		{
			get { return karakter["Navn"]; }
		}

		public string BrugerNavn
		{
			get { return karakter.Bruger.Navn; }
		}

		public long BrugerTlf
		{
			get { return karakter.Bruger.Tlf; }
		}

		public long BrugerNødTlf
		{
			get { return karakter.Bruger.NødTlf; }
		}

		public string BrugerInfo
		{
			get { return karakter.Bruger.Andet; }
		}

		public string BrugerAllergi
		{
			get { return karakter.Bruger.Allergi; }
		}
	}
}
