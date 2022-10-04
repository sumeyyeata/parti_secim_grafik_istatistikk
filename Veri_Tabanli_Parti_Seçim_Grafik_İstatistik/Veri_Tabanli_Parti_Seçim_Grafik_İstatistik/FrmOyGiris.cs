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

namespace Veri_Tabanli_Parti_Seçim_Grafik_İstatistik
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }


        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-5FU8Q6M;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values(@p1,@p2,@p3,@p4,@p5,@p6)" ,bgl);
            komut.Parameters.AddWithValue("@p1", TxtİlceAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtAParti.Text);
            komut.Parameters.AddWithValue("@p3", TxtBParti.Text);
            komut.Parameters.AddWithValue("@p4", TxtCParti.Text);
            komut.Parameters.AddWithValue("@p5", TxtDParti.Text);
            komut.Parameters.AddWithValue("@p6", TxtEParti.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
