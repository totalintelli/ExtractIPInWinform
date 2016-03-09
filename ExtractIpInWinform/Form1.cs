using ExtractIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractIpInWinform
{
    public partial class Form1 : Form
    {
        InternetProtocal ip = new InternetProtocal();
        string[] lines;
        List<string> ipValues;

        public Form1()
        {
            InitializeComponent();



            lines = ip.Load();
            ip.ExtractIp(lines, out ipValues);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < ipValues.Count; i++)
            {
                listBox1.Items.Add(ipValues[i]);
            }
        }
    }
}
