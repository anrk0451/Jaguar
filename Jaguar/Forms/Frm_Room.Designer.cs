
namespace Jaguar.Forms
{
	partial class Frm_Room
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
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txt_rg003 = new DevExpress.XtraEditors.TextEdit();
			this.ck_rg055 = new DevExpress.XtraEditors.CheckEdit();
			((System.ComponentModel.ISupportInitialize)(this.txt_rg003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ck_rg055.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton2
			// 
			this.simpleButton2.Appearance.BackColor = System.Drawing.Color.LimeGreen;
			this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
			this.simpleButton2.Appearance.Options.UseBackColor = true;
			this.simpleButton2.Appearance.Options.UseForeColor = true;
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(341, 61);
			this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(110, 31);
			this.simpleButton2.TabIndex = 41;
			this.simpleButton2.Text = "取消";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.SteelBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(341, 22);
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(110, 31);
			this.sb_ok.TabIndex = 40;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(31, 27);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(50, 18);
			this.labelControl1.TabIndex = 39;
			this.labelControl1.Text = "寄存室:";
			// 
			// txt_rg003
			// 
			this.txt_rg003.Location = new System.Drawing.Point(135, 24);
			this.txt_rg003.Name = "txt_rg003";
			this.txt_rg003.Size = new System.Drawing.Size(178, 24);
			this.txt_rg003.TabIndex = 38;
			// 
			// ck_rg055
			// 
			this.ck_rg055.EditValue = true;
			this.ck_rg055.Location = new System.Drawing.Point(31, 73);
			this.ck_rg055.Name = "ck_rg055";
			this.ck_rg055.Properties.Caption = "允许选号";
			this.ck_rg055.Size = new System.Drawing.Size(94, 22);
			this.ck_rg055.TabIndex = 49;
			// 
			// Frm_Room
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 118);
			this.Controls.Add(this.ck_rg055);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txt_rg003);
			this.Name = "Frm_Room";
			this.Text = "寄存室";
			this.Load += new System.EventHandler(this.Frm_Room_Load);
			((System.ComponentModel.ISupportInitialize)(this.txt_rg003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ck_rg055.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit txt_rg003;
		private DevExpress.XtraEditors.CheckEdit ck_rg055;
	}
}