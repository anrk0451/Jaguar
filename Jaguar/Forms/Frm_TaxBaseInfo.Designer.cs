namespace Jaguar.Forms
{
    partial class Frm_TaxBaseInfo
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
			this.sb_exit = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.txtedit_ver = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_cert = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_addr = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_bank = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.rg_invtype = new DevExpress.XtraEditors.RadioGroup();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.txt_skr = new DevExpress.XtraEditors.TextEdit();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.txt_shr = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_ver.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_cert.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_addr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_bank.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rg_invtype.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_skr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_shr.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sb_exit
			// 
			this.sb_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_exit.Location = new System.Drawing.Point(534, 369);
			this.sb_exit.Name = "sb_exit";
			this.sb_exit.Size = new System.Drawing.Size(94, 29);
			this.sb_exit.TabIndex = 70;
			this.sb_exit.Text = "取消";
			this.sb_exit.Click += new System.EventHandler(this.sb_exit_Click);
			// 
			// sb_ok
			// 
			this.sb_ok.Location = new System.Drawing.Point(382, 369);
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(146, 29);
			this.sb_ok.TabIndex = 69;
			this.sb_ok.Text = "确定";
			// 
			// txtedit_ver
			// 
			this.txtedit_ver.Location = new System.Drawing.Point(214, 223);
			this.txtedit_ver.Name = "txtedit_ver";
			this.txtedit_ver.Size = new System.Drawing.Size(415, 24);
			this.txtedit_ver.TabIndex = 68;
			// 
			// labelControl5
			// 
			this.labelControl5.Appearance.Image = null;
			this.labelControl5.AppearanceDisabled.Image = null;
			this.labelControl5.AppearanceHovered.Image = null;
			this.labelControl5.AppearancePressed.Image = null;
			this.labelControl5.Location = new System.Drawing.Point(54, 228);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(120, 18);
			this.labelControl5.TabIndex = 67;
			this.labelControl5.Text = "税收分类编码版本";
			// 
			// txtedit_cert
			// 
			this.txtedit_cert.Location = new System.Drawing.Point(214, 173);
			this.txtedit_cert.Name = "txtedit_cert";
			this.txtedit_cert.Size = new System.Drawing.Size(415, 24);
			this.txtedit_cert.TabIndex = 66;
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Image = null;
			this.labelControl4.AppearanceDisabled.Image = null;
			this.labelControl4.AppearanceHovered.Image = null;
			this.labelControl4.AppearancePressed.Image = null;
			this.labelControl4.Location = new System.Drawing.Point(54, 176);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(105, 18);
			this.labelControl4.TabIndex = 65;
			this.labelControl4.Text = "金税卡证书密码";
			// 
			// txtedit_addr
			// 
			this.txtedit_addr.Location = new System.Drawing.Point(214, 123);
			this.txtedit_addr.Name = "txtedit_addr";
			this.txtedit_addr.Size = new System.Drawing.Size(415, 24);
			this.txtedit_addr.TabIndex = 64;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(54, 126);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(105, 18);
			this.labelControl3.TabIndex = 63;
			this.labelControl3.Text = "销方地址、电话";
			// 
			// txtedit_bank
			// 
			this.txtedit_bank.Location = new System.Drawing.Point(214, 74);
			this.txtedit_bank.Name = "txtedit_bank";
			this.txtedit_bank.Size = new System.Drawing.Size(415, 24);
			this.txtedit_bank.TabIndex = 62;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(54, 77);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(90, 18);
			this.labelControl2.TabIndex = 61;
			this.labelControl2.Text = "销方银行账号";
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(54, 32);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(60, 18);
			this.labelControl1.TabIndex = 60;
			this.labelControl1.Text = "发票类型";
			// 
			// rg_invtype
			// 
			this.rg_invtype.EditValue = "0";
			this.rg_invtype.Location = new System.Drawing.Point(215, 24);
			this.rg_invtype.Name = "rg_invtype";
			this.rg_invtype.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.rg_invtype.Properties.Appearance.Options.UseBackColor = true;
			this.rg_invtype.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.rg_invtype.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "普通发票"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "专用发票")});
			this.rg_invtype.Size = new System.Drawing.Size(257, 34);
			this.rg_invtype.TabIndex = 59;
			// 
			// labelControl6
			// 
			this.labelControl6.Appearance.Image = null;
			this.labelControl6.AppearanceDisabled.Image = null;
			this.labelControl6.AppearanceHovered.Image = null;
			this.labelControl6.AppearancePressed.Image = null;
			this.labelControl6.Location = new System.Drawing.Point(54, 278);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(45, 18);
			this.labelControl6.TabIndex = 71;
			this.labelControl6.Text = "收款人";
			// 
			// txt_skr
			// 
			this.txt_skr.Location = new System.Drawing.Point(214, 273);
			this.txt_skr.Name = "txt_skr";
			this.txt_skr.Size = new System.Drawing.Size(415, 24);
			this.txt_skr.TabIndex = 72;
			// 
			// labelControl7
			// 
			this.labelControl7.Appearance.Image = null;
			this.labelControl7.AppearanceDisabled.Image = null;
			this.labelControl7.AppearanceHovered.Image = null;
			this.labelControl7.AppearancePressed.Image = null;
			this.labelControl7.Location = new System.Drawing.Point(54, 329);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(45, 18);
			this.labelControl7.TabIndex = 73;
			this.labelControl7.Text = "审核人";
			// 
			// txt_shr
			// 
			this.txt_shr.Location = new System.Drawing.Point(215, 323);
			this.txt_shr.Name = "txt_shr";
			this.txt_shr.Size = new System.Drawing.Size(415, 24);
			this.txt_shr.TabIndex = 74;
			// 
			// Frm_TaxBaseInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 419);
			this.Controls.Add(this.txt_shr);
			this.Controls.Add(this.labelControl7);
			this.Controls.Add(this.txt_skr);
			this.Controls.Add(this.labelControl6);
			this.Controls.Add(this.sb_exit);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.txtedit_ver);
			this.Controls.Add(this.labelControl5);
			this.Controls.Add(this.txtedit_cert);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.txtedit_addr);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.txtedit_bank);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.rg_invtype);
			this.Name = "Frm_TaxBaseInfo";
			this.Text = "税务发票基础信息";
			this.Load += new System.EventHandler(this.Frm_TaxBaseInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtedit_ver.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_cert.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_addr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_bank.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rg_invtype.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_skr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_shr.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private DevExpress.XtraEditors.SimpleButton sb_exit;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.XtraEditors.TextEdit txtedit_ver;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.TextEdit txtedit_cert;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.TextEdit txtedit_addr;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit txtedit_bank;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.RadioGroup rg_invtype;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.TextEdit txt_skr;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraEditors.TextEdit txt_shr;
	}
}