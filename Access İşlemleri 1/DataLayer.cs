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
    public class DataLayer
    {
        #region Tanımlamalar

        OleDbConnection bağlantı;

        #endregion 

        public void VeriTabanıBağlan()
        {
            bağlantı = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=VeriTabanı.accdb"); // Veri Tabanı Bağlatısı

            if (bağlantı.State == ConnectionState.Closed)  // Bağlantı Açıkmı Kontrolü 
            {
                bağlantı.Open(); // Bağlantı Açtık
            }

            else
            {
                bağlantı.Close(); // Açık bağlantı varsa kapattık.
                bağlantı.Open();  // Bağlatıyı Açtık
            }
        
        
        }

        public void GenelVeriÇek(string sorgux, OleDbCommand komutx, OleDbDataAdapter kayıtx, DataTable tablox)
        {
            VeriTabanıBağlan(); // Databasebağlan metodu çağrıldı.
            tablox.Clear(); // Tablo Verilerini Temizledik
            komutx = new OleDbCommand(sorgux, bağlantı);  // Sorgumuzun komutunu çalıştırdık.
            kayıtx = new OleDbDataAdapter(komutx); // Komutla çağrılan değerler kayda alındı.
            kayıtx.Fill(tablox); // Kayıda gelen değerler tabloya aktarıldı.
            kayıtx.Dispose(); // Kayıt Temizlendi.
            bağlantı.Dispose(); // Bağlantı Temizlendi.
            bağlantı.Close(); // Bağlantı Kapatıldı.
        }
    }
}
