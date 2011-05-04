using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controller;
using Interfaces;

namespace Rottehullet_Management
{
	public partial class FrmKarakter : Form
	{
		KampagneManager kampagnemanager;
		
		public FrmKarakter(KampagneManager kampagnemanager, IBruger bruger, IKarakter karakter)
		{
			InitializeComponent();
			this.kampagnemanager = kampagnemanager;
			txtNavn.Text = bruger.Navn;
			txtAlder.Text = (DateTime.Now.Year - bruger.Fødselsdag.Year).ToString();
			txtEmail.Text = bruger.Email;
			txtTelefon.Text = bruger.Tlf.ToString();
			txtKontaktperson.Text = bruger.NødTlf.ToString();
		}

	}
}
