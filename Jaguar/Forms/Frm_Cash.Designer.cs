
namespace Jaguar.Forms
{
	partial class Frm_Cash
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
			this.te_cash = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_payer = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.te_billno = new DevExpress.XtraEditors.TextEdit();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.te_cash.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_payer.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_billno.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(38, 24);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(68, 17);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "押金金额";
			// 
			// te_cash
			// 
			this.te_cash.Location = new System.Drawing.Point(133, 21);
			this.te_cash.Name = "te_cash";
			this.te_cash.Properties.Appearance.Options.UseTextOptions = true;
			this.te_cash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_cash.Properties.Mask.EditMask = "n2";
			this.te_cash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_cash.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_cash.Size = new System.Drawing.Size(135, 24);
			this.te_cash.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(38, 71);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(51, 17);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "交款人";
			// 
			// te_payer
			// 
			this.te_payer.Location = new System.Drawing.Point(133, 68);
			this.te_payer.Name = "te_payer";
			this.te_payer.Size = new System.Drawing.Size(135, 24);
			this.te_payer.TabIndex = 3;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(38, 118);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(68, 17);
			this.labelControl3.TabIndex = 4;
			this.labelControl3.Text = "收据编号";
			// 
			// te_billno
			// 
			this.te_billno.Location = new System.Drawing.Point(133, 115);
			this.te_billno.Name = "te_billno";
			this.te_billno.Size = new System.Drawing.Size(135, 24);
			this.te_billno.TabIndex = 5;
			// 
			// b_exit
			// 
			this.b_exit.Appearance.BackColor = System.Drawing.Color.LimeGreen;
			this.b_exit.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_exit.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_exit.Appearance.Options.UseBackColor = true;
			this.b_exit.Appearance.Options.UseForeColor = true;
			this.b_exit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.b_exit.Location = new System.Drawing.Point(294, 61);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(133, 29);
			this.b_exit.TabIndex = 64;
			this.b_exit.Text = "退出";
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// b_ok
			// 
			this.b_ok.Appearance.BackColor = System.Drawing.Color.SteelBlue;
			this.b_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_ok.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_ok.Appearance.Options.UseBackColor = true;
			this.b_ok.Appearance.Options.UseForeColor = true;
			this.b_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_ok.Location = new System.Drawing.Point(294, 24);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(133, 29);
			this.b_ok.TabIndex = 65;
			this.b_ok.Text = "确定";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// Frm_Cash
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 158);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Controls.Add(this.te_billno);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.te_payer);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.te_cash);
			this.Controls.Add(this.labelControl1);
			this.Name = "Frm_Cash";
			this.Text = "预交押金";
			this.Load += new System.EventHandler(this.Frm_Cash_Load);
			((System.ComponentModel.ISupportInitialize)(this.te_cash.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_payer.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_billno.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit te_cash;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit te_payer;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit te_billno;
		private DevExpress.XtraEditors.SimpleButton b_exit;
		private DevExpress.XtraEditors.SimpleButton b_ok;
	}
}