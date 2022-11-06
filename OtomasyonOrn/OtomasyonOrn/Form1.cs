using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomasyonOrn
{
    public partial class Form1 : Form
    {
        Market market = new Market();

        public Form1()
        {
            InitializeComponent();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            Market_Urun market_urun = new Market_Urun();

            market_urun.ID = market.MaxUrunID;
            market.MaxUrunID += 1;
            market_urun.Name = textBox1.Text;
            market_urun.Katagori = comboBox1.SelectedItem.ToString();
            market_urun.Barkod =  market_urun.Katagori + RandomString(5);
            market_urun.Fiyat = Convert.ToDouble(textBox2.Text);
            market.urunler.Add(market_urun);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = market.urunler;

        }
    }
}
