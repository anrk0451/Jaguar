
namespace Jaguar.Forms
{
	partial class Frm_SingleSideRemoved
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
			this.te_fa004 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
			this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_code = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.te_num = new DevExpress.XtraEditors.TextEdit();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.te_fa004.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_code.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_num.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// te_fa004
			// 
			this.te_fa004.Location = new System.Drawing.Point(150, 23);
			this.te_fa004.Name = "te_fa004";
			this.te_fa004.Properties.Appearance.Options.UseTextOptions = true;
			this.te_fa004.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_fa004.Properties.Mask.EditMask = "N2";
			this.te_fa004.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_fa004.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_fa004.Size = new System.Drawing.Size(118, 24);
			this.te_fa004.TabIndex = 115;
			// 
			// labelControl9
			// 
			this.labelControl9.Appearance.Image = null;
			this.labelControl9.AppearanceDisabled.Image = null;
			this.labelControl9.AppearanceHovered.Image = null;
			this.labelControl9.AppearancePressed.Image = null;
			this.labelControl9.Location = new System.Drawing.Point(20, 29);
			this.labelControl9.Name = "labelControl9";
			this.labelControl9.Size = new System.Drawing.Size(35, 18);
			this.labelControl9.TabIndex = 114;
			this.labelControl9.Text = "金额:";
			// 
			// radioGroup1
			// 
			this.radioGroup1.EditValue = "F";
			this.radioGroup1.Location = new System.Drawing.Point(150, 72);
			this.radioGroup1.Name = "radioGroup1";
			this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
			this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.radioGroup1.Properties.Columns = 2;
			this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("F", "财政发票"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("T", "税务发票")});
			this.radioGroup1.Size = new System.Drawing.Size(250, 33);
			this.radioGroup1.TabIndex = 116;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(20, 80);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(65, 18);
			this.labelControl1.TabIndex = 117;
			this.labelControl1.Text = "发票类型:";
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(20, 131);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(65, 18);
			this.labelControl2.TabIndex = 118;
			this.labelControl2.Text = "发票代码:";
			// 
			// te_code
			// 
			this.te_code.Location = new System.Drawing.Point(150, 130);
			this.te_code.Name = "te_code";
			this.te_code.Size = new System.Drawing.Size(269, 24);
			this.te_code.TabIndex = 119;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(20, 181);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(50, 18);
			this.labelControl3.TabIndex = 120;
			this.labelControl3.Text = "发票号:";
			// 
			// te_num
			// 
			this.te_num.Location = new System.Drawing.Point(150, 179);
			this.te_num.Name = "te_num";
			this.te_num.Size = new System.Drawing.Size(269, 24);
			this.te_num.TabIndex = 121;
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
			this.b_exit.Location = new System.Drawing.Point(351, 224);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(63, 31);
			this.b_exit.TabIndex = 123;
			this.b_exit.Text = "退出";
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// b_ok
			// 
			this.b_ok.Appearance.BackColor = System.Drawing.Color.Red;
			this.b_ok.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_ok.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_ok.Appearance.Options.UseBackColor = true;
			this.b_ok.Appearance.Options.UseFont = true;
			this.b_ok.Appearance.Options.UseForeColor = true;
			this.b_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_ok.Location = new System.Drawing.Point(182, 224);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(162, 31);
			this.b_ok.TabIndex = 122;
			this.b_ok.Text = "作废";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// Frm_SingleSideRemoved
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 282);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Controls.Add(this.te_num);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.te_code);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.radioGroup1);
			this.Controls.Add(this.te_fa004);
			this.Controls.Add(this.labelControl9);
			this.Name = "Frm_SingleSideRemoved";
			this.Text = "作废单边发票";
			((System.ComponentModel.ISupportInitialize)(this.te_fa004.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_code.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_num.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraEditors.TextEdit te_fa004;
		private DevExpress.XtraEditors.LabelControl labelControl9;
		private DevExpress.XtraEditors.RadioGroup radioGroup1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit te_code;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit te_num;
		private DevExpress.XtraEditors.SimpleButton b_exit;
		private DevExpress.XtraEditors.SimpleButton b_ok;
	}
}