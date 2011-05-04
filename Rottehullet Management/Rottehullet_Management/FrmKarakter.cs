using System;
using System.Collections;
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
		IBruger bruger;
		IKarakter karakter;
		
		public FrmKarakter(KampagneManager kampagnemanager, IBruger bruger, IKarakter karakter)
		{
			InitializeComponent();
			this.kampagnemanager = kampagnemanager;
			this.bruger = bruger;
			this.karakter = karakter;
			txtNavn.Text = bruger.Navn;
			txtAlder.Text = (DateTime.Now.Year - bruger.Fødselsdag.Year).ToString();
			txtEmail.Text = bruger.Email;
			txtTelefon.Text = bruger.Tlf.ToString();
			txtKontaktperson.Text = bruger.NødTlf.ToString();
			this.Text = karakter["Navn"];

			SætAttributter();
		}

		public void SætAttributter()
		{
			IKampagneAttribut ikampagneattribut;
			string attributværdi;
            IKampagneMultiAttributValgmulighed valgmulighed;
            IEnumerator attributiterator = kampagnemanager.GetAttributIterator();
            int y = 200;
            int x = 25;
            attributiterator.Reset();
            while (attributiterator.MoveNext())
            {
                ikampagneattribut = (IKampagneAttribut) attributiterator.Current;
				attributværdi = karakter.FindAttributVærdi(ikampagneattribut.KampagneAttributID);

				if (ikampagneattribut.Type == Enum.KampagneAttributType.Singleline || ikampagneattribut.Type == Enum.KampagneAttributType.Combo)
                {
                    Label label = new Label();
                    label.Text = ikampagneattribut.Navn;
                    label.Location = new Point(x, y);
                    TextBox textbox = new TextBox();
					textbox.Location = new Point(100, y);
					textbox.Text = attributværdi;
					textbox.ReadOnly = true;
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                    y += textbox.Height + 5;
                }
                else if (ikampagneattribut.Type == Enum.KampagneAttributType.Multiline)
                {
					Label label = new Label();
					label.Text = ikampagneattribut.Navn;
					label.Location = new Point(x, y);
					TextBox textbox = new TextBox();
                    textbox.Location = new Point(100, y);
                    textbox.Multiline = true;
					textbox.Text = attributværdi;
                    textbox.Size = new System.Drawing.Size(150, 100);
					textbox.ReadOnly = true;
					y += textbox.Height + 5;
                    this.Controls.Add(textbox);
                    this.Controls.Add(label);
                }
				//else if (ikampagneattribut.Type == Enum.KampagneAttributType.Combo)
				//{
				//    List<long> valgIDer = new List<long>();
				//    IEnumerator valgmulighediterator =
				//        brugerklient.GetValgmulighederIterator(ikampagneattribut.KampagneAttributID,
				//                                               ikampagne.KampagneID);
				//    ComboBox combobox = new ComboBox();
				//    combobox.Location = new Point(x, y);
				//    while (valgmulighediterator.MoveNext())
				//    {
				//        valgmulighed = (IKampagneMultiAttributValgmulighed) valgmulighediterator.Current;
				//        combobox.Items.Add(valgmulighed.Værdi);
				//        valgIDer.Add(valgmulighed.Id);
				//    }
				//    combobox.Name = ikampagneattribut.KampagneAttributID.ToString();
				//    Label label = new Label();
				//    label.Text = ikampagneattribut.Navn;
				//    label.Location = new Point(x - combobox.Width, y);
				//    label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
				//    y += combobox.Height + 5;
				//    this.Controls.Add(combobox);
				//    this.Controls.Add(label);
                    
				//}
            }
		}
	}
}
