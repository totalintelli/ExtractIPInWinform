using ExtractIP;
using System;
using System.Collections;
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
            OpenFileDialog OpenFileDlg = new OpenFileDialog();

            OpenFileDlg.Title = "파일 열기";
            OpenFileDlg.InitialDirectory = "C:\\";
            OpenFileDlg.DefaultExt = "*.*";
            OpenFileDlg.Filter = "All Files (*.*) | *.*";

            if(OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                InternetProtocal Ip = new InternetProtocal();
                IpResult(Ip.ExtractIp(Ip.Load(OpenFileDlg.FileName)));
            }

        }

      
        private void IpResult(SortedList IpDatas)
        {
            ListViewItem Lvi; // 둘째 열부터 들어갈 데이터들을 담는 객체
            IList IpList = IpDatas.GetKeyList();
            IList CountList = IpDatas.GetValueList();

            // IP 목록을 초기화한다.
            if (listBox1.Items.Count != 0)
                listBox1.Items.Clear();


            // IP 목록을 표시한다.
            for (int i = 0; i < IpDatas.Count; i++)
            {
              listBox1.Items.Add(IpList[i]);
            }

            // 결과를 초기화한다.
            if (lv_ipResult.Items.Count != 0)
                lv_ipResult.Items.Clear();

            // 결과를 List View에 표시
            for (int i = 0; i < IpDatas.Count; i++)
            {
                Lvi = new ListViewItem(IpList[i].ToString());
                Lvi.SubItems.Add(CountList[i].ToString());
                lv_ipResult.Items.Add(Lvi);
            }
        }



    }
}
