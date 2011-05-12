using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
	public class Scenarie : IScenarie
	{
		private long id;
		private string titel, beskrivelse, sted, andetInfo;
		private double pris;
		private DateTime tid;
		private int overnatning;
		private bool spisning, spisningTvungen, overnatningTvungen;
		List<Tilmelding> tilmeldinger;

		public Scenarie(long id, string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningTvungen, bool overnatningTvungen, string andetInfo)
		{
			this.id = id;
			this.titel = titel;
			this.beskrivelse = beskrivelse;
			this.tid = tid;
			this.sted = sted;
			this.pris = pris;
			this.overnatning = overnatning;
			this.spisning = spisning;
			this.spisningTvungen = spisningTvungen;
			this.overnatningTvungen = overnatningTvungen;
			this.andetInfo = andetInfo;
			tilmeldinger = new List<Tilmelding>();
		}

		#region Metoder
		//Lavet af René
		public List<IKarakter> HentDeltagere()
		{
			List<IKarakter> karakterer = new List<IKarakter>();

			foreach (Tilmelding tilmelding in tilmeldinger)
			{
				karakterer.Add(tilmelding.Karakter);
			}

			return karakterer;
		}

		//Lavet af René
		public List<Tilmelding> HentTilmeldinger()
		{
			return tilmeldinger;
		}

		//Lavet af René
		internal void TilføjTilmelding(Tilmelding tilmelding)
		{
			tilmeldinger.Add(tilmelding);
		}
		#endregion

		#region properties
		public long Id
		{
			get { return id; }
		}

		public string Sted
		{
			get { return sted; }
			set { sted = value; }
		}

		public string Beskrivelse
		{
			get { return beskrivelse; }
			set { beskrivelse = value; }
		}

		public string Titel
		{
			get { return titel; }
			set { titel = value; }
		}

		public double Pris
		{
			get { return pris; }
			set { pris = value; }
		}

		public DateTime Tid
		{
			get { return tid; }
			set { tid = value; }
		}

		public int Overnatning
		{
			get { return overnatning; }
			set { overnatning = value; }
		}

		public bool OvernatningTvungen
		{
			get { return overnatningTvungen; }
			set { overnatningTvungen = value; }
		}

		public bool SpisningTvungen
		{
			get { return spisningTvungen; }
			set { spisningTvungen = value; }
		}

		public bool Spisning
		{
			get { return spisning; }
			set { spisning = value; }
		}

		public string AndetInfo
		{
			get { return andetInfo; }
			set { andetInfo = value; }
		}

		public int AntalDeltagere
		{
			get { return tilmeldinger.Count; }
		}

		public int AntalVegetarer
		{
			get
			{
				int antal = 0;

				foreach (Tilmelding tilmelding in tilmeldinger)
				{
					if (tilmelding.Karakter.Bruger.Vegetar == true)
					{
						antal++;
					}
				}

				return antal;
			}
		}

		public int AntalVeganere
		{
			get
			{
				int antal = 0;

				foreach (Tilmelding tilmelding in tilmeldinger)
				{
					if (tilmelding.Karakter.Bruger.Veganer == true)
					{
						antal++;
					}
				}

				return antal;
			}
		}
		#endregion
	}
}
