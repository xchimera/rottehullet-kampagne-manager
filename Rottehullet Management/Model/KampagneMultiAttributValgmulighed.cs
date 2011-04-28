using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
	public class KampagneMultiAttributValgmulighed : IKampagneMultiAttributValgmulighed
	{
		long id;
		string værdi;

		public KampagneMultiAttributValgmulighed(long id, string værdi)
		{
			this.id = id;
			this.værdi = værdi;
		}



		public long Id
		{
			get { return id; }
		}

		public string Værdi
		{
			get { return værdi; }
			set { værdi = value; }
		}
	}
}
