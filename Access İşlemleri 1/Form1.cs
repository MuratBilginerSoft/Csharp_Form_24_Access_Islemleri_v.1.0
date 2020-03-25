using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Access_İşlemleri_1
{
    public partial class Form1 : Form
    {
        #region Tanımlamalar

        OleDbCommand Komut;
        OleDbDataAdapter Kayıt;
        DataTable Tablo1 = new DataTable();

        DataLayer Veritabanıİşlemleri = new DataLayer();
        #endregion

        #region Değişkenler

        string Sorgu1;

        #endregion

        #region Metodlar

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sorgu1="Select * from "+comboBox1.SelectedItem.ToString()+"";
            Veritabanıİşlemleri.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo1);
            dataGridView1.DataSource = Tablo1;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
