namespace Brown.Forms
{
    partial class Frm_FinBaseInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.te_pjlx = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_title = new DevExpress.XtraEditors.TextEdit();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.te_region_code = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.te_agency_code = new DevExpress.XtraEditors.TextEdit();
			this.te_agency_name = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.te_url = new DevExpress.XtraEditors.TextEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.te_appid = new DevExpress.XtraEditors.TextEdit();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.te_appkey = new DevExpress.XtraEditors.TextEdit();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.te_code = new DevExpress.XtraEditors.TextEdit();
			this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
			this.te_batch_code = new DevExpress.XtraEditors.TextEdit();
			this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
			this.te_bill_name = new DevExpress.XtraEditors.TextEdit();
			this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
			this.te_version = new DevExpress.XtraEditors.TextEdit();
			this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.te_pjlx.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_title.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_region_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_agency_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_agency_name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_url.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_appid.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_appkey.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_batch_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_bill_name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_version.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(326, 491);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(65, 18);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "票据类型:";
			// 
			// te_pjlx
			// 
			this.te_pjlx.Location = new System.Drawing.Point(447, 488);
			this.te_pjlx.Name = "te_pjlx";
			this.te_pjlx.Size = new System.Drawing.Size(200, 24);
			this.te_pjlx.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(326, 526);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(95, 18);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "发票题头名称:";
			// 
			// te_title
			// 
			this.te_title.Location = new System.Drawing.Point(447, 523);
			this.te_title.Name = "te_title";
			this.te_title.Size = new System.Drawing.Size(200, 24);
			this.te_title.TabIndex = 3;
			// 
			// b_exit
			// 
			this.b_exit.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.b_exit.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_exit.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_exit.Appearance.Options.UseBackColor = true;
			this.b_exit.Appearance.Options.UseForeColor = true;
			this.b_exit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.b_exit.Location = new System.Drawing.Point(374, 407);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(63, 31);
			this.b_exit.TabIndex = 14;
			this.b_exit.Text = "取消";
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// b_ok
			// 
			this.b_ok.Appearance.BackColor = System.Drawing.Color.Lime;
			this.b_ok.Appearance.ForeColor = System.Drawing.Color.DimGray;
			this.b_ok.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_ok.Appearance.Options.UseBackColor = true;
			this.b_ok.Appearance.Options.UseForeColor = true;
			this.b_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_ok.Location = new System.Drawing.Point(225, 407);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(143, 31);
			this.b_ok.TabIndex = 13;
			this.b_ok.Text = "确定";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(38, 33);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(65, 18);
			this.labelControl3.TabIndex = 15;
			this.labelControl3.Text = "区划编码:";
			// 
			// te_region_code
			// 
			this.te_region_code.Location = new System.Drawing.Point(127, 30);
			this.te_region_code.Name = "te_region_code";
			this.te_region_code.Size = new System.Drawing.Size(312, 24);
			this.te_region_code.TabIndex = 16;
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Image = null;
			this.labelControl4.AppearanceDisabled.Image = null;
			this.labelControl4.AppearanceHovered.Image = null;
			this.labelControl4.AppearancePressed.Image = null;
			this.labelControl4.Location = new System.Drawing.Point(38, 70);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(65, 18);
			this.labelControl4.TabIndex = 17;
			this.labelControl4.Text = "单位编码:";
			// 
			// te_agency_code
			// 
			this.te_agency_code.Location = new System.Drawing.Point(127, 67);
			this.te_agency_code.Name = "te_agency_code";
			this.te_agency_code.Size = new System.Drawing.Size(312, 24);
			this.te_agency_code.TabIndex = 18;
			// 
			// te_agency_name
			// 
			this.te_agency_name.Location = new System.Drawing.Point(127, 104);
			this.te_agency_name.Name = "te_agency_name";
			this.te_agency_name.Size = new System.Drawing.Size(312, 24);
			this.te_agency_name.TabIndex = 20;
			// 
			// labelControl5
			// 
			this.labelControl5.Appearance.Image = null;
			this.labelControl5.AppearanceDisabled.Image = null;
			this.labelControl5.AppearanceHovered.Image = null;
			this.labelControl5.AppearancePressed.Image = null;
			this.labelControl5.Location = new System.Drawing.Point(38, 107);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(65, 18);
			this.labelControl5.TabIndex = 19;
			this.labelControl5.Text = "单位名称:";
			// 
			// te_url
			// 
			this.te_url.Location = new System.Drawing.Point(127, 141);
			this.te_url.Name = "te_url";
			this.te_url.Size = new System.Drawing.Size(312, 24);
			this.te_url.TabIndex = 22;
			// 
			// labelControl6
			// 
			this.labelControl6.Appearance.Image = null;
			this.labelControl6.AppearanceDisabled.Image = null;
			this.labelControl6.AppearanceHovered.Image = null;
			this.labelControl6.AppearancePressed.Image = null;
			this.labelControl6.Location = new System.Drawing.Point(38, 144);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(61, 18);
			this.labelControl6.TabIndex = 21;
			this.labelControl6.Text = "服务URL:";
			// 
			// te_appid
			// 
			this.te_appid.Location = new System.Drawing.Point(127, 178);
			this.te_appid.Name = "te_appid";
			this.te_appid.Size = new System.Drawing.Size(312, 24);
			this.te_appid.TabIndex = 24;
			// 
			// labelControl7
			// 
			this.labelControl7.Appearance.Image = null;
			this.labelControl7.AppearanceDisabled.Image = null;
			this.labelControl7.AppearanceHovered.Image = null;
			this.labelControl7.AppearancePressed.Image = null;
			this.labelControl7.Location = new System.Drawing.Point(38, 181);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(46, 18);
			this.labelControl7.TabIndex = 23;
			this.labelControl7.Text = "APPID:";
			// 
			// te_appkey
			// 
			this.te_appkey.Location = new System.Drawing.Point(127, 215);
			this.te_appkey.Name = "te_appkey";
			this.te_appkey.Size = new System.Drawing.Size(312, 24);
			this.te_appkey.TabIndex = 26;
			// 
			// labelControl8
			// 
			this.labelControl8.Appearance.Image = null;
			this.labelControl8.AppearanceDisabled.Image = null;
			this.labelControl8.AppearanceHovered.Image = null;
			this.labelControl8.AppearancePressed.Image = null;
			this.labelControl8.Location = new System.Drawing.Point(38, 218);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new System.Drawing.Size(57, 18);
			this.labelControl8.TabIndex = 25;
			this.labelControl8.Text = "APPKEY:";
			// 
			// te_code
			// 
			this.te_code.Location = new System.Drawing.Point(127, 252);
			this.te_code.Name = "te_code";
			this.te_code.Size = new System.Drawing.Size(312, 24);
			this.te_code.TabIndex = 28;
			// 
			// labelControl9
			// 
			this.labelControl9.Appearance.Image = null;
			this.labelControl9.AppearanceDisabled.Image = null;
			this.labelControl9.AppearanceHovered.Image = null;
			this.labelControl9.AppearancePressed.Image = null;
			this.labelControl9.Location = new System.Drawing.Point(38, 255);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new System.Drawing.Size(65, 18);
			this.labelControl9.TabIndex = 27;
			this.labelControl9.Text = "票据编码:";
			// 
			// te_batch_code
			// 
			this.te_batch_code.Location = new System.Drawing.Point(127, 289);
			this.te_batch_code.Name = "te_batch_code";
			this.te_batch_code.Size = new System.Drawing.Size(312, 24);
			this.te_batch_code.TabIndex = 30;
			// 
			// labelControl10
			// 
			this.labelControl10.Appearance.Image = null;
			this.labelControl10.AppearanceDisabled.Image = null;
			this.labelControl10.AppearanceHovered.Image = null;
			this.labelControl10.AppearancePressed.Image = null;
			this.labelControl10.Location = new System.Drawing.Point(38, 292);
			this.labelControl10.Name = "labelControl10";
			this.labelControl10.Size = new System.Drawing.Size(65, 18);
			this.labelControl10.TabIndex = 29;
			this.labelControl10.Text = "票据代码:";
			// 
			// te_bill_name
			// 
			this.te_bill_name.Location = new System.Drawing.Point(127, 326);
			this.te_bill_name.Name = "te_bill_name";
			this.te_bill_name.Size = new System.Drawing.Size(312, 24);
			this.te_bill_name.TabIndex = 32;
			// 
			// labelControl11
			// 
			this.labelControl11.Appearance.Image = null;
			this.labelControl11.AppearanceDisabled.Image = null;
			this.labelControl11.AppearanceHovered.Image = null;
			this.labelControl11.AppearancePressed.Image = null;
			this.labelControl11.Location = new System.Drawing.Point(38, 329);
			this.labelControl11.Name = "labelControl11";
			this.labelControl11.Size = new System.Drawing.Size(65, 18);
			this.labelControl11.TabIndex = 31;
			this.labelControl11.Text = "票据名称:";
			// 
			// te_version
			// 
			this.te_version.Location = new System.Drawing.Point(127, 364);
			this.te_version.Name = "te_version";
			this.te_version.Size = new System.Drawing.Size(312, 24);
			this.te_version.TabIndex = 34;
			// 
			// labelControl12
			// 
			this.labelControl12.Appearance.Image = null;
			this.labelControl12.AppearanceDisabled.Image = null;
			this.labelControl12.AppearanceHovered.Image = null;
			this.labelControl12.AppearancePressed.Image = null;
			this.labelControl12.Location = new System.Drawing.Point(38, 367);
			this.labelControl12.Name = "labelControl12";
			this.labelControl12.Size = new System.Drawing.Size(35, 18);
			this.labelControl12.TabIndex = 33;
			this.labelControl12.Text = "版本:";
			// 
			// Frm_FinBaseInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 449);
			this.Controls.Add(this.te_version);
			this.Controls.Add(this.labelControl12);
			this.Controls.Add(this.te_bill_name);
			this.Controls.Add(this.labelControl11);
			this.Controls.Add(this.te_batch_code);
			this.Controls.Add(this.labelControl10);
			this.Controls.Add(this.te_code);
			this.Controls.Add(this.labelControl9);
			this.Controls.Add(this.te_appkey);
			this.Controls.Add(this.labelControl8);
			this.Controls.Add(this.te_appid);
			this.Controls.Add(this.labelControl7);
			this.Controls.Add(this.te_url);
			this.Controls.Add(this.labelControl6);
			this.Controls.Add(this.te_agency_name);
			this.Controls.Add(this.labelControl5);
			this.Controls.Add(this.te_agency_code);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.te_region_code);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Controls.Add(this.te_title);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.te_pjlx);
			this.Controls.Add(this.labelControl1);
			this.Name = "Frm_FinBaseInfo";
			this.Text = "财政发票基础信息";
			this.Load += new System.EventHandler(this.Frm_FinBaseInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.te_pjlx.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_title.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_region_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_agency_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_agency_name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_url.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_appid.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_appkey.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_batch_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_bill_name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_version.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit te_pjlx;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit te_title;
        private DevExpress.XtraEditors.SimpleButton b_exit;
        private DevExpress.XtraEditors.SimpleButton b_ok;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit te_region_code;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.TextEdit te_agency_code;
		private DevExpress.XtraEditors.TextEdit te_agency_name;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.TextEdit te_url;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.TextEdit te_appid;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraEditors.TextEdit te_appkey;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.TextEdit te_code;
		private DevExpress.XtraEditors.LabelControl labelControl9;
		private DevExpress.XtraEditors.TextEdit te_batch_code;
		private DevExpress.XtraEditors.LabelControl labelControl10;
		private DevExpress.XtraEditors.TextEdit te_bill_name;
		private DevExpress.XtraEditors.LabelControl labelControl11;
		private DevExpress.XtraEditors.TextEdit te_version;
		private DevExpress.XtraEditors.LabelControl labelControl12;
	}
}