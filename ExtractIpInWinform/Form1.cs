using ExtractIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractIpInWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


            lv_ipResult.View = View.Details;
            lv_ipResult.Columns.Add("IP");
            lv_ipResult.Columns.Add("IP의 개수");
        }

        private void btn_FileOpen_Clicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            openFileDlg.Title = "파일 열기";
            openFileDlg.InitialDirectory = "C:\\";
            openFileDlg.DefaultExt = "*.*";
            openFileDlg.Filter = "All Files (*.*) | *.*";

            if(openFileDlg.ShowDialog() == DialogResult.OK)
            {
                InternetProtocal Ip = new InternetProtocal();
                IpResult(Ip.ExtractIp(Ip.Load(openFileDlg.FileName)));
            }

        }

      
        private void IpResult(List<string> IpDatas)
        {
            ListViewItem lvi; // 둘째 열부터 들어갈 데이터들을 담는 객체

            if (listBox1.Items.Count != 0)
                listBox1.Items.Clear();

            // IP 목록을 표시한다.
            for (int i = 0; i < IpDatas.Count; i++)
            {
                if (i % 2 == 0)
                    listBox1.Items.Add(IpDatas[i]);
            }

            if (lv_ipResult.Items.Count != 0)
                lv_ipResult.Items.Clear();

            // 결과를 List View에 표시
            for (int i = 0; i < IpDatas.Count; i++)
            {
                if (i % 2 == 1)
                {
                    lvi = new ListViewItem(IpDatas[i - 1]);
                    lvi.SubItems.Add(IpDatas[i]);
                    lv_ipResult.Items.Add(lvi);
                }
            }
        }



    }
}
