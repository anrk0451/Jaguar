
namespace Jaguar.Forms
{
	partial class Frm_SetAvoid
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
			this.te_ac003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.lookup_ac070 = new DevExpress.XtraEditors.LookUpEdit();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.te_ac003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookup_ac070.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(26, 25);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(68, 17);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "逝者姓名";
			// 
			// te_ac003
			// 
			this.te_ac003.Location = new System.Drawing.Point(136, 22);
			this.te_ac003.Name = "te_ac003";
			this.te_ac003.Properties.ReadOnly = true;
			this.te_ac003.Size = new System.Drawing.Size(167, 24);
			this.te_ac003.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(26, 73);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(68, 17);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "减免类型";
			// 
			// lookup_ac070
			// 
			this.lookup_ac070.Location = new System.Drawing.Point(136, 70);
			this.lookup_ac070.Name = "lookup_ac070";
			this.lookup_ac070.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookup_ac070.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ST001", "名称1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ST003", "")});
			this.lookup_ac070.Properties.DisplayMember = "ST003";
			this.lookup_ac070.Properties.NullText = "";
			this.lookup_ac070.Properties.ValueMember = "ST001";
			this.lookup_ac070.Size = new System.Drawing.Size(167, 24);
			this.lookup_ac070.TabIndex = 3;
			// 
			// b_exit
			// 
			this.b_exit.Appearance.BackColor = System.Drawing.Color.LimeGreen;
			this.b_exit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b_exit.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_exit.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_exit.Appearance.Options.UseBackColor = true;
			this.b_exit.Appearance.Options.UseFont = true;
			this.b_exit.Appearance.Options.UseForeColor = true;
			this.b_exit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.b_exit.Location = new System.Drawing.Point(330, 63);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(119, 29);
			this.b_exit.TabIndex = 107;
			this.b_exit.Text = "退出";
			this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
			// 
			// b_ok
			// 
			this.b_ok.Appearance.BackColor = System.Drawing.Color.SteelBlue;
			this.b_ok.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.b_ok.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.b_ok.Appearance.Options.UseBackColor = true;
			this.b_ok.Appearance.Options.UseFont = true;
			this.b_ok.Appearance.Options.UseForeColor = true;
			this.b_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.b_ok.Location = new System.Drawing.Point(330, 25);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(119, 29);
			this.b_ok.TabIndex = 106;
			this.b_ok.Text = "确定";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// Frm_SetAvoid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 118);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Controls.Add(this.lookup_ac070);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.te_ac003);
			this.Controls.Add(this.labelControl1);
			this.Name = "Frm_SetAvoid";
			this.Text = "减免设置";
			this.Load += new System.EventHandler(this.Frm_SetAvoid_Load);
			((System.ComponentModel.ISupportInitialize)(this.te_ac003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookup_ac070.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit te_ac003;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LookUpEdit lookup_ac070;
		private DevExpress.XtraEditors.SimpleButton b_exit;
		private DevExpress.XtraEditors.SimpleButton b_ok;
	}
}