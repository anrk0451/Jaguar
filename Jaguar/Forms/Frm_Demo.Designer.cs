
namespace Jaguar.Forms
{
    partial class Frm_Demo
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
			this.button1 = new System.Windows.Forms.Button();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
			this.button2 = new System.Windows.Forms.Button();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
			this.button3 = new System.Windows.Forms.Button();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(11, 114);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(121, 29);
			this.button1.TabIndex = 1;
			this.button1.Text = "电子票冲红";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textEdit1
			// 
			this.textEdit1.Location = new System.Drawing.Point(11, 10);
			this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Size = new System.Drawing.Size(396, 20);
			this.textEdit1.TabIndex = 2;
			// 
			// textEdit2
			// 
			this.textEdit2.Location = new System.Drawing.Point(10, 33);
			this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textEdit2.Name = "textEdit2";
			this.textEdit2.Size = new System.Drawing.Size(396, 20);
			this.textEdit2.TabIndex = 3;
			// 
			// textEdit3
			// 
			this.textEdit3.Location = new System.Drawing.Point(11, 57);
			this.textEdit3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textEdit3.Name = "textEdit3";
			this.textEdit3.Size = new System.Drawing.Size(396, 20);
			this.textEdit3.TabIndex = 4;
			// 
			// textEdit4
			// 
			this.textEdit4.Location = new System.Drawing.Point(11, 91);
			this.textEdit4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textEdit4.Name = "textEdit4";
			this.textEdit4.Size = new System.Drawing.Size(396, 20);
			this.textEdit4.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(137, 114);
			this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(155, 29);
			this.button2.TabIndex = 6;
			this.button2.Text = "获取电子票据告知单";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// memoEdit1
			// 
			this.memoEdit1.Location = new System.Drawing.Point(11, 149);
			this.memoEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(732, 128);
			this.memoEdit1.TabIndex = 7;
			// 
			// memoEdit2
			// 
			this.memoEdit2.Location = new System.Drawing.Point(11, 282);
			this.memoEdit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.memoEdit2.Name = "memoEdit2";
			this.memoEdit2.Size = new System.Drawing.Size(732, 29);
			this.memoEdit2.TabIndex = 8;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(298, 115);
			this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(155, 29);
			this.button3.TabIndex = 9;
			this.button3.Text = "发送电子票通知";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(460, 115);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(145, 29);
			this.simpleButton1.TabIndex = 10;
			this.simpleButton1.Text = "发送post请求";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(13, 317);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(329, 281);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(348, 317);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(145, 29);
			this.simpleButton2.TabIndex = 12;
			this.simpleButton2.Text = "生产二维码";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// Frm_Demo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 610);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.memoEdit2);
			this.Controls.Add(this.memoEdit1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textEdit4);
			this.Controls.Add(this.textEdit3);
			this.Controls.Add(this.textEdit2);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.button1);
			this.Name = "Frm_Demo";
			this.Text = "me";
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private System.Windows.Forms.Button button3;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
	}
}