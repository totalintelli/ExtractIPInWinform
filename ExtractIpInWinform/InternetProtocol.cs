//만든이: 송용단
//직급: 수습사원
//작성일: 2016.03.08
//목적: 로그 파일에서 IP만 추출
//특이 사항: 없음
//버전 1

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractIP
{
    class InternetProtocal
    {
        /*
        함수 이름 : ExtractIp
        기    능 : IP를 추출하고 추출한 Ip들의 개수를 센다.
        입    력 : 한 줄 로그들
        출    력 : IP 데이터들 
        */
        public SortedList ExtractIp(string[] Lines)
        {
            SortedList IpDatas = new SortedList(); // IP에 대한 데이터들 - IP 값, IP의 개수
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
                IpDatas.Add(SingleIps[i], SameCount.ToString() + "개");
                // 중복 개수를 초기화한다.
                SameCount = 0;
            }


            return IpDatas;
        }



        /*
        함수 이름 : Load
        기    능 : 파일을 읽어서 한 줄 로그들을 만든다.
        입    력 : 없음
        출    력 : 한 줄 로그들
        */
        public string[] Load(string openFilePath)
        {
            string[] Lines = null;

            Lines = System.IO.File.ReadAllLines(openFilePath);

            return Lines;
        }
    }
}
