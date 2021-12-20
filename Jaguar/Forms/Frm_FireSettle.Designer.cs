namespace Jaguar.Forms
{
    partial class Frm_FireSettle
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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.b_exit = new DevExpress.XtraEditors.SimpleButton();
			this.b_ok = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.te_ysje = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_yj = new DevExpress.XtraEditors.TextEdit();
			this.te_cash = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
			this.te_precash = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.te_reg_precash = new DevExpress.XtraEditors.TextEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_ysje.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_yj.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_cash.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_precash.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_reg_precash.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gridControl1.Location = new System.Drawing.Point(0, 64);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(634, 385);
			this.gridControl1.TabIndex = 61;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
			this.gridView1.DetailHeight = 273;
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.IndicatorWidth = 39;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "销售编号";
			this.gridColumn1.FieldName = "SA001";
			this.gridColumn1.MinWidth = 17;
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowShowHide = false;
			this.gridColumn1.Width = 66;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "商品或服务名";
			this.gridColumn2.FieldName = "SA003";
			this.gridColumn2.MinWidth = 17;
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			this.gridColumn2.Width = 162;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "单价";
			this.gridColumn3.DisplayFormat.FormatString = "N2";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "PRICE";
			this.gridColumn3.MinWidth = 17;
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 79;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "数量";
			this.gridColumn4.DisplayFormat.FormatString = "N1";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "NUMS";
			this.gridColumn4.MinWidth = 17;
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 74;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "销售金额";
			this.gridColumn5.DisplayFormat.FormatString = "N2";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn5.FieldName = "SA007";
			this.gridColumn5.MinWidth = 17;
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SA007", "{0:N2}")});
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 3;
			this.gridColumn5.Width = 87;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "预减免金额";
			this.gridColumn6.DisplayFormat.FormatString = "N2";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn6.FieldName = "AVOIDFEE";
			this.gridColumn6.MinWidth = 22;
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AVOIDFEE", "{0:N2}")});
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 4;
			this.gridColumn6.Width = 80;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "实际应收";
			this.gridColumn7.DisplayFormat.FormatString = "N2";
			this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn7.FieldName = "ACTUALFEE";
			this.gridColumn7.MinWidth = 22;
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ACTUALFEE", "{0:N2}")});
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 5;
			this.gridColumn7.Width = 94;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "gridColumn8";
			this.gridColumn8.FieldName = "SA002";
			this.gridColumn8.MinWidth = 22;
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Width = 82;
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
			this.b_exit.Location = new System.Drawing.Point(648, 70);
			this.b_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.b_exit.Name = "b_exit";
			this.b_exit.Size = new System.Drawing.Size(112, 24);
			this.b_exit.TabIndex = 62;
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
			this.b_ok.Location = new System.Drawing.Point(648, 39);
			this.b_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.b_ok.Name = "b_ok";
			this.b_ok.Size = new System.Drawing.Size(112, 24);
			this.b_ok.TabIndex = 63;
			this.b_ok.Text = "确定";
			this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(9, 14);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(52, 14);
			this.labelControl1.TabIndex = 64;
			this.labelControl1.Text = "费用合计:";
			// 
			// te_ysje
			// 
			this.te_ysje.Location = new System.Drawing.Point(69, 11);
			this.te_ysje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.te_ysje.Name = "te_ysje";
			this.te_ysje.Properties.Appearance.Options.UseTextOptions = true;
			this.te_ysje.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_ysje.Properties.Mask.EditMask = "N2";
			this.te_ysje.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_ysje.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_ysje.Properties.ReadOnly = true;
			this.te_ysje.Size = new System.Drawing.Size(76, 20);
			this.te_ysje.TabIndex = 65;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(155, 14);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(52, 14);
			this.labelControl2.TabIndex = 66;
			this.labelControl2.Text = "押金余额:";
			// 
			// te_yj
			// 
			this.te_yj.Location = new System.Drawing.Point(216, 11);
			this.te_yj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.te_yj.Name = "te_yj";
			this.te_yj.Properties.Appearance.Options.UseTextOptions = true;
			this.te_yj.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_yj.Properties.Mask.EditMask = "N2";
			this.te_yj.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_yj.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_yj.Properties.ReadOnly = true;
			this.te_yj.Size = new System.Drawing.Size(76, 20);
			this.te_yj.TabIndex = 67;
			// 
			// te_cash
			// 
			this.te_cash.Location = new System.Drawing.Point(550, 11);
			this.te_cash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.te_cash.Name = "te_cash";
			this.te_cash.Properties.Appearance.Options.UseTextOptions = true;
			this.te_cash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_cash.Properties.Mask.EditMask = "N2";
			this.te_cash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_cash.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_cash.Properties.ReadOnly = true;
			this.te_cash.Size = new System.Drawing.Size(76, 20);
			this.te_cash.TabIndex = 69;
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.Appearance.Options.UseFont = true;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(484, 14);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(56, 14);
			this.labelControl3.TabIndex = 68;
			this.labelControl3.Text = "应缴现金:";
			// 
			// checkEdit1
			// 
			this.checkEdit1.Enabled = false;
			this.checkEdit1.Location = new System.Drawing.Point(9, 42);
			this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkEdit1.Name = "checkEdit1";
			this.checkEdit1.Properties.Caption = "减免确认";
			this.checkEdit1.Size = new System.Drawing.Size(82, 20);
			this.checkEdit1.TabIndex = 70;
			this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
			// 
			// te_precash
			// 
			this.te_precash.Location = new System.Drawing.Point(392, 10);
			this.te_precash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.te_precash.Name = "te_precash";
			this.te_precash.Properties.Appearance.Options.UseTextOptions = true;
			this.te_precash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_precash.Properties.Mask.EditMask = "N2";
			this.te_precash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_precash.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_precash.Properties.ReadOnly = true;
			this.te_precash.Size = new System.Drawing.Size(76, 20);
			this.te_precash.TabIndex = 74;
			// 
			// labelControl5
			// 
			this.labelControl5.Appearance.Image = null;
			this.labelControl5.AppearanceDisabled.Image = null;
			this.labelControl5.AppearanceHovered.Image = null;
			this.labelControl5.AppearancePressed.Image = null;
			this.labelControl5.Location = new System.Drawing.Point(301, 13);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(76, 14);
			this.labelControl5.TabIndex = 73;
			this.labelControl5.Text = "火化减免预收:";
			// 
			// checkEdit2
			// 
			this.checkEdit2.Location = new System.Drawing.Point(155, 42);
			this.checkEdit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkEdit2.Name = "checkEdit2";
			this.checkEdit2.Properties.Caption = "办理寄存";
			this.checkEdit2.Size = new System.Drawing.Size(82, 20);
			this.checkEdit2.TabIndex = 75;
			this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
			// 
			// labelControl4
			// 
			this.labelControl4.Appearance.Image = null;
			this.labelControl4.AppearanceDisabled.Image = null;
			this.labelControl4.AppearanceHovered.Image = null;
			this.labelControl4.AppearancePressed.Image = null;
			this.labelControl4.Location = new System.Drawing.Point(301, 42);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(76, 14);
			this.labelControl4.TabIndex = 76;
			this.labelControl4.Text = "寄存减免预收:";
			// 
			// te_reg_precash
			// 
			this.te_reg_precash.Enabled = false;
			this.te_reg_precash.Location = new System.Drawing.Point(392, 38);
			this.te_reg_precash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.te_reg_precash.Name = "te_reg_precash";
			this.te_reg_precash.Properties.Appearance.Options.UseTextOptions = true;
			this.te_reg_precash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_reg_precash.Properties.Mask.EditMask = "N2";
			this.te_reg_precash.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_reg_precash.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_reg_precash.Properties.ReadOnly = true;
			this.te_reg_precash.Size = new System.Drawing.Size(76, 20);
			this.te_reg_precash.TabIndex = 77;
			this.te_reg_precash.EditValueChanged += new System.EventHandler(this.te_reg_precash_EditValueChanged);
			// 
			// labelControl6
			// 
			this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelControl6.Appearance.Image = null;
			this.labelControl6.Appearance.Options.UseFont = true;
			this.labelControl6.AppearanceDisabled.Image = null;
			this.labelControl6.AppearanceHovered.Image = null;
			this.labelControl6.AppearancePressed.Image = null;
			this.labelControl6.Location = new System.Drawing.Point(484, 42);
			this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(52, 14);
			this.labelControl6.TabIndex = 78;
			this.labelControl6.Text = "支付方式:";
			// 
			// comboBoxEdit1
			// 
			this.comboBoxEdit1.EditValue = "现金";
			this.comboBoxEdit1.Location = new System.Drawing.Point(550, 38);
			this.comboBoxEdit1.Name = "comboBoxEdit1";
			this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "现金",
            "扫码"});
			this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.comboBoxEdit1.Size = new System.Drawing.Size(76, 20);
			this.comboBoxEdit1.TabIndex = 79;
			// 
			// Frm_FireSettle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 450);
			this.Controls.Add(this.comboBoxEdit1);
			this.Controls.Add(this.labelControl6);
			this.Controls.Add(this.te_reg_precash);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.checkEdit2);
			this.Controls.Add(this.te_precash);
			this.Controls.Add(this.labelControl5);
			this.Controls.Add(this.checkEdit1);
			this.Controls.Add(this.te_cash);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.te_yj);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.te_ysje);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.b_exit);
			this.Controls.Add(this.b_ok);
			this.Name = "Frm_FireSettle";
			this.Text = "业务结算收费";
			this.Load += new System.EventHandler(this.Frm_FireSettle_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_ysje.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_yj.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_cash.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_precash.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_reg_precash.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton b_exit;
        private DevExpress.XtraEditors.SimpleButton b_ok;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit te_ysje;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit te_yj;
		private DevExpress.XtraEditors.TextEdit te_cash;
		private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.TextEdit te_precash;
        private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.CheckEdit checkEdit2;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.TextEdit te_reg_precash;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
	}
}