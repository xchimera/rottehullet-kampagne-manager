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
		List<Karakter> deltagere;

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
			deltagere = new List<Karakter>();
		}

		public List<Karakter> HentDeltagere()
		{
			return deltagere;
		}

		#region Metoder
		internal void TilmedKarakter(Karakter karakter)
		{
			deltagere.Add(karakter);
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
		#endregion
	}
}
