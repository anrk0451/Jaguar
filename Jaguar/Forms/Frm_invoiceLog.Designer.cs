namespace Jaguar.Forms
{
    partial class Frm_invoiceLog
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
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.te_fph = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.te_zch = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.te_pjlx = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.te_tax_ph = new DevExpress.XtraEditors.TextEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.te_tax_code = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_fa001 = new DevExpress.XtraEditors.TextEdit();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			this.te_fa003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.te_fin = new DevExpress.XtraEditors.TextEdit();
			this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
			this.te_tax = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_fph.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_zch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_pjlx.Properties)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_tax_ph.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_tax_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa001.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_tax.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Location = new System.Drawing.Point(11, 153);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(505, 190);
			this.xtraTabControl1.TabIndex = 2;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.te_fph);
			this.xtraTabPage1.Controls.Add(this.labelControl4);
			this.xtraTabPage1.Controls.Add(this.te_zch);
			this.xtraTabPage1.Controls.Add(this.labelControl3);
			this.xtraTabPage1.Controls.Add(this.te_pjlx);
			this.xtraTabPage1.Controls.Add(this.labelControl1);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(498, 154);
			this.xtraTabPage1.Text = "财政发票";
			// 
			// te_fph
			// 
			this.te_fph.Location = new System.Drawing.Point(143, 114);
			this.te_fph.Name = "te_fph";
			this.te_fph.Size = new System.Drawing.Size(241, 24);
			this.te_fph.TabIndex = 5;
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Image = null;
			this.labelControl4.AppearanceDisabled.Image = null;
			this.labelControl4.AppearanceHovered.Image = null;
			this.labelControl4.AppearancePressed.Image = null;
			this.labelControl4.Location = new System.Drawing.Point(43, 117);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(45, 18);
			this.labelControl4.TabIndex = 4;
			this.labelControl4.Text = "发票号";
			// 
			// te_zch
			// 
			this.te_zch.Location = new System.Drawing.Point(143, 69);
			this.te_zch.Name = "te_zch";
			this.te_zch.Size = new System.Drawing.Size(241, 24);
			this.te_zch.TabIndex = 3;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(43, 73);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(45, 18);
			this.labelControl3.TabIndex = 2;
			this.labelControl3.Text = "注册号";
			// 
			// te_pjlx
			// 
			this.te_pjlx.Location = new System.Drawing.Point(143, 24);
			this.te_pjlx.Name = "te_pjlx";
			this.te_pjlx.Size = new System.Drawing.Size(241, 24);
			this.te_pjlx.TabIndex = 1;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(43, 27);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(60, 18);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "票据类型";
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.te_tax_ph);
			this.xtraTabPage2.Controls.Add(this.labelControl6);
			this.xtraTabPage2.Controls.Add(this.te_tax_code);
			this.xtraTabPage2.Controls.Add(this.labelControl5);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(498, 154);
			this.xtraTabPage2.Text = "税务发票";
			// 
			// te_tax_ph
			// 
			this.te_tax_ph.Location = new System.Drawing.Point(165, 93);
			this.te_tax_ph.Name = "te_tax_ph";
			this.te_tax_ph.Size = new System.Drawing.Size(241, 24);
			this.te_tax_ph.TabIndex = 4;
			// 
			// labelControl6
			// 
			this.labelControl6.Appearance.Image = null;
			this.labelControl6.AppearanceDisabled.Image = null;
			this.labelControl6.AppearanceHovered.Image = null;
			this.labelControl6.AppearancePressed.Image = null;
			this.labelControl6.Location = new System.Drawing.Point(56, 95);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(45, 18);
			this.labelControl6.TabIndex = 3;
			this.labelControl6.Text = "发票号";
			// 
			// te_tax_code
			// 
			this.te_tax_code.Location = new System.Drawing.Point(165, 33);
			this.te_tax_code.Name = "te_tax_code";
			this.te_tax_code.Size = new System.Drawing.Size(241, 24);
			this.te_tax_code.TabIndex = 2;
			// 
			// labelControl5
			// 
			this.labelControl5.Appearance.Image = null;
			this.labelControl5.AppearanceDisabled.Image = null;
			this.labelControl5.AppearanceHovered.Image = null;
			this.labelControl5.AppearancePressed.Image = null;
			this.labelControl5.Location = new System.Drawing.Point(56, 37);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(60, 18);
			this.labelControl5.TabIndex = 0;
			this.labelControl5.Text = "发票代码";
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(13, 18);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(80, 18);
			this.labelControl2.TabIndex = 3;
			this.labelControl2.Text = "收费流水号:";
			// 
			// te_fa001
			// 
			this.te_fa001.Enabled = false;
			this.te_fa001.Location = new System.Drawing.Point(145, 14);
			this.te_fa001.Name = "te_fa001";
			this.te_fa001.Size = new System.Drawing.Size(118, 24);
			this.te_fa001.TabIndex = 4;
			// 
			// b_exit
			// 
			this.b_exit.Appearance.BackColor = System.Drawing.Color.Gray;
			this.b_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b_exit.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_exit.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_exit.Appearance.Options.UseBackColor = true;
			this.b_exit.Appearance.Options.UseFont = true;
			this.b_exit.Appearance.Options.UseForeColor = true;
			this.b_exit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.b_exit.Location = new System.Drawing.Point(453, 361);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(63, 31);
			this.b_exit.TabIndex = 107;
			this.b_exit.Text = "退出";
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// b_ok
			// 
			this.b_ok.Appearance.BackColor = System.Drawing.Color.Blue;
			this.b_ok.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_ok.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_ok.Appearance.Options.UseBackColor = true;
			this.b_ok.Appearance.Options.UseFont = true;
			this.b_ok.Appearance.Options.UseForeColor = true;
			this.b_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_ok.Location = new System.Drawing.Point(323, 361);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(123, 31);
			this.b_ok.TabIndex = 106;
			this.b_ok.Text = "确定";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// te_fa003
			// 
			this.te_fa003.Enabled = false;
			this.te_fa003.Location = new System.Drawing.Point(145, 58);
			this.te_fa003.Name = "te_fa003";
			this.te_fa003.Size = new System.Drawing.Size(370, 24);
			this.te_fa003.TabIndex = 109;
			// 
			// labelControl7
			// 
			this.labelControl7.Appearance.Image = null;
			this.labelControl7.AppearanceDisabled.Image = null;
			this.labelControl7.AppearanceHovered.Image = null;
			this.labelControl7.AppearancePressed.Image = null;
			this.labelControl7.Location = new System.Drawing.Point(10, 59);
			this.labelControl7.Name = "labelControl7";
			this.labelControl7.Size = new System.Drawing.Size(107, 18);
			this.labelControl7.TabIndex = 108;
			this.labelControl7.Text = "逝者或(交款人):";
			// 
			// labelControl8
			// 
			this.labelControl8.Appearance.Image = null;
			this.labelControl8.AppearanceDisabled.Image = null;
			this.labelControl8.AppearanceHovered.Image = null;
			this.labelControl8.AppearancePressed.Image = null;
			this.labelControl8.Location = new System.Drawing.Point(13, 105);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new System.Drawing.Size(65, 18);
			this.labelControl8.TabIndex = 110;
			this.labelControl8.Text = "财票金额:";
			// 
			// te_fin
			// 
			this.te_fin.Enabled = false;
			this.te_fin.Location = new System.Drawing.Point(145, 102);
			this.te_fin.Name = "te_fin";
			this.te_fin.Properties.Appearance.Options.UseTextOptions = true;
			this.te_fin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_fin.Properties.DisplayFormat.FormatString = "N2";
			this.te_fin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.te_fin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_fin.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_fin.Size = new System.Drawing.Size(118, 24);
			this.te_fin.TabIndex = 111;
			// 
			// labelControl9
			// 
			this.labelControl9.Appearance.Image = null;
			this.labelControl9.AppearanceDisabled.Image = null;
			this.labelControl9.AppearanceHovered.Image = null;
			this.labelControl9.AppearancePressed.Image = null;
			this.labelControl9.Location = new System.Drawing.Point(323, 105);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new System.Drawing.Size(65, 18);
			this.labelControl9.TabIndex = 112;
			this.labelControl9.Text = "税票金额:";
			// 
			// te_tax
			// 
			this.te_tax.Enabled = false;
			this.te_tax.Location = new System.Drawing.Point(398, 102);
			this.te_tax.Name = "te_tax";
			this.te_tax.Properties.Appearance.Options.UseTextOptions = true;
			this.te_tax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_tax.Properties.Mask.EditMask = "N2";
			this.te_tax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_tax.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_tax.Size = new System.Drawing.Size(118, 24);
			this.te_tax.TabIndex = 113;
			// 
			// Frm_invoiceLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 405);
			this.Controls.Add(this.te_tax);
			this.Controls.Add(this.labelControl9);
			this.Controls.Add(this.te_fin);
			this.Controls.Add(this.labelControl8);
			this.Controls.Add(this.te_fa003);
			this.Controls.Add(this.labelControl7);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Controls.Add(this.te_fa001);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.xtraTabControl1);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Frm_invoiceLog";
			this.Text = "发票日志维护";
			this.Load += new System.EventHandler(this.Frm_invoiceLog_Load);
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_fph.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_zch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_pjlx.Properties)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			this.xtraTabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_tax_ph.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_tax_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa001.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_tax.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit te_fph;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit te_zch;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit te_pjlx;
        private DevExpress.XtraEditors.TextEdit te_fa001;
        private DevExpress.XtraEditors.SimpleButton b_exit;
        private DevExpress.XtraEditors.SimpleButton b_ok;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit te_tax_code;
        private DevExpress.XtraEditors.TextEdit te_tax_ph;
        private DevExpress.XtraEditors.TextEdit te_fa003;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit te_fin;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit te_tax;
    }
}