namespace ExtractIpInWinform
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lb_IpList = new System.Windows.Forms.Label();
            this.lb_result = new System.Windows.Forms.Label();
            this.lv_ipResult = new System.Windows.Forms.ListView();
            this.btn_FileOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 580);
            this.listBox1.TabIndex = 0;
            // 
            // lb_IpList
            // 
            this.lb_IpList.AutoSize = true;
            this.lb_IpList.Location = new System.Drawing.Point(12, 22);
            this.lb_IpList.Name = "lb_IpList";
            this.lb_IpList.Size = new System.Drawing.Size(44, 12);
            this.lb_IpList.TabIndex = 1;
            this.lb_IpList.Text = "IP 목록";
            this.lb_IpList.Click += new System.EventHandler(this.lb_ip_Click);
            // 
            // lb_result
            // 
            this.lb_result.AutoSize = true;
            this.lb_result.Location = new System.Drawing.Point(209, 22);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(29, 12);
            this.lb_result.TabIndex = 2;
            this.lb_result.Text = "결과";
            // 
            // lv_ipResult
            // 
            this.lv_ipResult.Location = new System.Drawing.Point(211, 38);
            this.lv_ipResult.Name = "lv_ipResult";
            this.lv_ipResult.Size = new System.Drawing.Size(318, 234);
            this.lv_ipResult.TabIndex = 3;
            this.lv_ipResult.UseCompatibleStateImageBehavior = false;
            // 
            // btn_FileOpen
            // 
            this.btn_FileOpen.Location = new System.Drawing.Point(536, 22);
            this.btn_FileOpen.Name = "btn_FileOpen";
            this.btn_FileOpen.Size = new System.Drawing.Size(75, 23);
            this.btn_FileOpen.TabIndex = 4;
            this.btn_FileOpen.Text = "파일 열기";
            this.btn_FileOpen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 627);
            this.Controls.Add(this.btn_FileOpen);
            this.Controls.Add(this.lv_ipResult);
            this.Controls.Add(this.lb_result);
            this.Controls.Add(this.lb_IpList);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "IP 파싱 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lb_IpList;
        private System.Windows.Forms.Label lb_result;
        private System.Windows.Forms.ListView lv_ipResult;
        private System.Windows.Forms.Button btn_FileOpen;
    }
}

