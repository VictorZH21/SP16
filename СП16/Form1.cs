using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace СП16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string address;
        public void pingne()
        {
            Ping png= new Ping();
            PingReply replict = png.Send(address);
            if (replict.Status == IPStatus.Success)
            {
                label2.Text = "Ping OK";
                richTextBox1.AppendText("Start log...\n\n" + "Адрес: " + replict.Address.ToString() +
                    "\n Время: " + replict.RoundtripTime + "\n Время жизни пакета: " + replict.Options.Ttl +
                    "\n Фрагмент: " + replict.Options.DontFragment + "\n Размер пакета: " + replict.Buffer.Length +
                    "\n END log...");
            }
            else
            {
                label2.Text = "Ping False";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                address= textBox1.Text;
                pingne();
            }
            else
            {
                label2.Text = "Error!";
                MessageBox.Show("Не заполнено поле 'IP Address:'!", "Ошибка!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("log.txt", richTextBox1.Text);
            label2.Text = "File save:";
        }
    }
}
