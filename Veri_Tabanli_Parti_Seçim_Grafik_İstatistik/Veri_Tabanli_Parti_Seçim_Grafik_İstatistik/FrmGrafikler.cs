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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-5FU8Q6M;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {

            //İlçe Adlarını Combobox'a Çekme
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select ILCEAD From TBLILCE", bgl);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbIlceSec.Items.Add(dr2[0]);  //Yukarıdaki sorgudan 1 başlık(Ilçe Ad) döneceği için 0. index
            }
            bgl.Close();

            //Grafiğe Toplam Sonuçları Getirme
            bgl.Open();
            SqlCommand komut3 = new SqlCommand("Select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE", bgl);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr3[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr3[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr3[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr3[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr3[4]);
            }
            bgl.Close();

        }

        private void CmbIlceSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            bgl.Open();
            
            SqlCommand komut3 = new SqlCommand("Select * From TBLILCE where ILCEAD=@p1", bgl);
            komut3.Parameters.AddWithValue("@p1", CmbIlceSec.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                progressBar1.Value = int.Parse(dr3[2].ToString());
                progressBar2.Value = int.Parse(dr3[3].ToString());
                progressBar3.Value = int.Parse(dr3[4].ToString());
                progressBar4.Value = int.Parse(dr3[5].ToString());
                progressBar5.Value = int.Parse(dr3[6].ToString());

                LblA.Text=  dr3[2].ToString();
                LblB.Text = dr3[3].ToString();
                LblC.Text = dr3[4].ToString();
                LblD.Text = dr3[5].ToString();
                LblE.Text = dr3[6].ToString();


            }
            bgl.Close();
        }
    }
}
