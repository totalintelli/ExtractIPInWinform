using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                IpResult(OpenFileDlg.FileName);
            }

        }



        /*
        함수 이름 : IpResult
        기    능 : 로그 파일에서 IP 값과 IP 개수를 추출하여 폼에 출력한다.
        입    력 : 로그 파일 이름
        출    력 : 없음
        */
        private void IpResult(string FileName)
        {
            ListViewItem Lvi; // 둘째 열부터 들어갈 데이터들을 담는 객체
            string[] Lines; // 로그 한 줄씩 담은 배열
            List<InternetProtocol> IpDatas; // IP와 IP 개수를 담은 리스트

            Lines = System.IO.File.ReadAllLines(FileName);
            IpDatas = ExtractIp(Lines);

            // IP 목록을 초기화한다.
            if (listBox1.Items.Count != 0)
                listBox1.Items.Clear();

            // IP 목록을 표시한다.
            for (int i = 0; i < IpDatas.Count; i++)
            {
              listBox1.Items.Add(IpDatas[i].Ip);
            }

            // 결과를 초기화한다.
            if (lv_ipResult.Items.Count != 0)
                lv_ipResult.Items.Clear();

            // 결과를 List View에 표시
            for (int i = 0; i < IpDatas.Count; i++)
            {
                Lvi = new ListViewItem(IpDatas[i].Ip);
                Lvi.SubItems.Add(IpDatas[i].Count);
                lv_ipResult.Items.Add(Lvi);
            }
        }

        /*
        함수 이름 : ExtractIp
        기    능 : IP를 추출하고 추출한 Ip들의 개수를 센다.
        입    력 : 한 줄 로그들
        출    력 : IP 데이터들 
        */
        public List<InternetProtocol> ExtractIp(string[] Lines)
        {
            List<InternetProtocol> IpDatas = new List<InternetProtocol>(); // IP에 대한 데이터들 - IP 값, IP의 개수
            string Pattern = @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}";
            List<string> TmpIpValues = new List<string>(); // IP 형식에 맞는 IP들
            List<string> IpValues = new List<string>(); // IP 값들
            int SameCount = 0; // 같은 IP의 개수
            List<string> SingleIps = new List<string>(); // IP 목록
            int k = 0; // IP 형식에 맞는 IP들에서의 위치

            foreach (string line in Lines)
            {
                Match m = Regex.Match(line, Pattern);

                while (m.Success)
                {
                    TmpIpValues.Add(m.Value);
                    m = m.NextMatch();
                }
            }

            while (k < TmpIpValues.Count)
            {
                if (k % 2 == 0)
                {
                    IpValues.Add(TmpIpValues[k]);
                }

                k++;
            }

            // IP 목록을 구한다.
            SingleIps = IpValues.Distinct().ToList();

            // 배열의 개수만큼 반복한다.
            for (int i = 0; i < SingleIps.Count; i++)
            {

                // 배열의 첫 번째 값과 같은 IP의 개수를 센다.
                for (int j = 0; j < IpValues.Count; j++)
                {
                    if (IpValues[j].Equals(SingleIps[i]))
                    {
                        SameCount++;
                    }
                }
                // 자기 자신의 개수로 하나를 더한다.
                SameCount++;
                // IP에 대한 데이터들을 구한다.
                IpDatas.Add(new InternetProtocol() {Ip= SingleIps[i], Count = SameCount.ToString() + "개" });
                // 중복 개수를 초기화한다.
                SameCount = 0;
            }


            return IpDatas;
        }

    }
    public class InternetProtocol
    {
        public string Ip { get; set; }
        public string Count { get; set; }
    }

}
