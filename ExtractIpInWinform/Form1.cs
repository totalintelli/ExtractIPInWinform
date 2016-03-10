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
        InternetProtocal ip = new InternetProtocal();
        string[] lines;
        List<string> ipDatas;
        string openFilePosition;

        public Form1()
        {
            InitializeComponent();

            lv_ipResult.Columns.Add("IP");
            lv_ipResult.Columns.Add("IP의 개수");


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListViewItem lvi ; // 둘째 열부터 들어갈 데이터들을 담는 객체

            lv_ipResult.View = View.Details;

            if(openFilePosition != null)
            {

                // IP 목록을 표시한다.
                for (int i = 0; i < ipDatas.Count; i++)
                {
                    if (i % 2 == 0)
                        listBox1.Items.Add(ipDatas[i]);
                }

                // 결과를 List View에 표시
                for (int i = 0; i < ipDatas.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        lvi = new ListViewItem(ipDatas[i - 1]);
                        lvi.SubItems.Add(ipDatas[i]);
                        lv_ipResult.Items.Add(lvi);
                    }
                }
            }
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
                openFilePosition = openFileDlg.FileName;

                if (openFilePosition != null)
                {
                    lines = ip.Load(openFilePosition);
                    ip.ExtractIp(lines, out ipDatas);
                }

                this.Form1_Load(sender, e);

            }

        }



        public string GetOpenFilePosition()
        {
            return this.openFilePosition;
        }
    }
}
