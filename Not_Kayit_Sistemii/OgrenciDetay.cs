using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayit_Sistemii
{
    public partial class OgrenciDetay : Form
    {
        public OgrenciDetay()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-MMAHMVJ;Initial Catalog=DtbNotKayit;Integrated Security=True");
        //Data Source=DESKTOP-MMAHMVJ;Initial Catalog=DtbNotKayit;Integrated Security=True
        private void OgrenciDetay_Load(object sender, EventArgs e)
        {
            lblnu.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblnu.Text = dr[1].ToString();
                lbls1.Text = dr[4].ToString();
                lbls2.Text = dr[5].ToString();
                lbls3.Text = dr[6].ToString();
                lblort.Text = dr[7].ToString();
                lbldurum.Text = dr[8].ToString();
            }
            if (lbldurum.Text == "True")
            {
                lbldurum.Text = "Geçti";
            }
            else if (lbldurum.Text =="False")
            {
                lbldurum.Text = "Kaldı";
            }

            baglanti.Close();
        }
    }
}
