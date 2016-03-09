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
        List<string> ipDatas;

        public Form1()
        {
            InitializeComponent();

            lines = ip.Load();
            ip.ExtractIp(lines, out ipDatas);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // IP 목록을 표시한다.
            for(int i = 0; i < ipDatas.Count; i++)
            {
                if(i % 2 == 0)
                listBox1.Items.Add(ipDatas[i]);
            }

            // 결과를 List View에 표시
            

            
        }
        
    }
}
