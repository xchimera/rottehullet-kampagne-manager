using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class Scenarie
	{
		private long id;
		private string titel, beskrivelse, sted, andetInfo;
		private double pris;
		private DateTime tid;
		private int overnatning;
		private bool spisning, spisningValgfri, overnatningValgfri;
		List<string> deltagere;

		public Scenarie(long id, string titel, string beskrivelse, DateTime tid, string sted, double pris, int overnatning, bool spisning, bool spisningValgfri, bool overnatningValgfri, string andetInfo)
		{
			this.id = id;
			this.titel = titel;
			this.beskrivelse = beskrivelse;
			this.tid = tid;
			this.sted = sted;
			this.pris = pris;
			this.overnatning = overnatning;
			this.spisning = spisning;
			this.spisningValgfri = spisningValgfri;
			this.overnatningValgfri = overnatningValgfri;
			this.andetInfo = andetInfo;
			deltagere = new List<string>();
		}

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

		public bool OvernatningValgfri
		{
			get { return overnatningValgfri; }
			set { overnatningValgfri = value; }
		}

		public bool SpisningValgfri
		{
			get { return spisningValgfri; }
			set { spisningValgfri = value; }
		}

		public bool Spisning
		{
			get { return spisning; }
			set { spisning = value; }
		}
		#endregion
	}
}
