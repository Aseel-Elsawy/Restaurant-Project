namespace ElmasryCsharp
{
    partial class store
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(store));
            this.totaltxt = new System.Windows.Forms.MaskedTextBox();
            this.quantitytxt = new System.Windows.Forms.MaskedTextBox();
            this.pricetxt = new System.Windows.Forms.MaskedTextBox();
            this.itmname = new System.Windows.Forms.TextBox();
            this.datetxt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.itmunitxt = new System.Windows.Forms.ComboBox();
            this.labelid = new System.Windows.Forms.Label();
            this.vendorcombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchcombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deletebtn = new System.Windows.Forms.Button();
            this.editbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // totaltxt
            // 
            this.totaltxt.HidePromptOnLeave = true;
            this.totaltxt.Location = new System.Drawing.Point(438, 277);
            this.totaltxt.Mask = "00000000";
            this.totaltxt.Name = "totaltxt";
            this.totaltxt.Size = new System.Drawing.Size(292, 29);
            this.totaltxt.TabIndex = 0;
            // 
            // quantitytxt
            // 
            this.quantitytxt.HidePromptOnLeave = true;
            this.quantitytxt.Location = new System.Drawing.Point(438, 198);
            this.quantitytxt.Mask = "000000";
            this.quantitytxt.Name = "quantitytxt";
            this.quantitytxt.Size = new System.Drawing.Size(292, 29);
            this.quantitytxt.TabIndex = 1;
            // 
            // pricetxt
            // 
            this.pricetxt.HidePromptOnLeave = true;
            this.pricetxt.Location = new System.Drawing.Point(438, 117);
            this.pricetxt.Mask = "0000000";
            this.pricetxt.Name = "pricetxt";
            this.pricetxt.Size = new System.Drawing.Size(292, 29);
            this.pricetxt.TabIndex = 2;
            // 
            // itmname
            // 
            this.itmname.Location = new System.Drawing.Point(438, 47);
            this.itmname.Name = "itmname";
            this.itmname.Size = new System.Drawing.Size(292, 29);
            this.itmname.TabIndex = 3;
            // 
            // datetxt
            // 
            this.datetxt.Location = new System.Drawing.Point(26, 134);
            this.datetxt.Name = "datetxt";
            this.datetxt.Size = new System.Drawing.Size(270, 29);
            this.datetxt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "اسم المورد:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "تاريخ الدخول:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "الاجمالي:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(769, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "الكمية:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(767, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "السعر:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(738, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "اسم الصنف:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.itmunitxt);
            this.groupBox1.Controls.Add(this.labelid);
            this.groupBox1.Controls.Add(this.vendorcombo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.totaltxt);
            this.groupBox1.Controls.Add(this.quantitytxt);
            this.groupBox1.Controls.Add(this.pricetxt);
            this.groupBox1.Controls.Add(this.itmname);
            this.groupBox1.Controls.Add(this.datetxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(225, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 365);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اضافة صنف";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 53);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(96, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = " وحدة الصنف:";
            // 
            // itmunitxt
            // 
            this.itmunitxt.FormattingEnabled = true;
            this.itmunitxt.Items.AddRange(new object[] {
            "المشويات",
            "محاشي",
            "سلطات",
            "الطواجن",
            "اطباق رئيسية",
            "اطباق مميزة"});
            this.itmunitxt.Location = new System.Drawing.Point(28, 53);
            this.itmunitxt.Name = "itmunitxt";
            this.itmunitxt.Size = new System.Drawing.Size(268, 30);
            this.itmunitxt.TabIndex = 19;
            // 
            // labelid
            // 
            this.labelid.AutoSize = true;
            this.labelid.Location = new System.Drawing.Point(32, 24);
            this.labelid.Name = "labelid";
            this.labelid.Size = new System.Drawing.Size(20, 22);
            this.labelid.TabIndex = 16;
            this.labelid.Text = "0";
            // 
            // vendorcombo
            // 
            this.vendorcombo.FormattingEnabled = true;
            this.vendorcombo.Location = new System.Drawing.Point(26, 210);
            this.vendorcombo.Name = "vendorcombo";
            this.vendorcombo.Size = new System.Drawing.Size(270, 30);
            this.vendorcombo.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchcombo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(385, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "البحث";
            // 
            // searchcombo
            // 
            this.searchcombo.FormattingEnabled = true;
            this.searchcombo.Location = new System.Drawing.Point(64, 39);
            this.searchcombo.Name = "searchcombo";
            this.searchcombo.Size = new System.Drawing.Size(296, 30);
            this.searchcombo.TabIndex = 13;
            this.searchcombo.SelectedIndexChanged += new System.EventHandler(this.searchcombo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "اسم الصنف:";
            // 
            // deletebtn
            // 
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebtn.ForeColor = System.Drawing.Color.White;
            this.deletebtn.Location = new System.Drawing.Point(32, 569);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(130, 35);
            this.deletebtn.TabIndex = 12;
            this.deletebtn.Text = "حذف";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // editbtn
            // 
            this.editbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editbtn.ForeColor = System.Drawing.Color.White;
            this.editbtn.Location = new System.Drawing.Point(32, 487);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(130, 35);
            this.editbtn.TabIndex = 13;
            this.editbtn.Text = "تعديل";
            this.editbtn.UseVisualStyleBackColor = true;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.ForeColor = System.Drawing.Color.White;
            this.savebtn.Location = new System.Drawing.Point(32, 398);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(130, 35);
            this.savebtn.TabIndex = 14;
            this.savebtn.Text = "حفظ";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbtn.ForeColor = System.Drawing.Color.White;
            this.newbtn.Location = new System.Drawing.Point(32, 318);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(130, 35);
            this.newbtn.TabIndex = 15;
            this.newbtn.Text = "جديد";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.editbtn);
            this.panel1.Controls.Add(this.newbtn);
            this.panel1.Controls.Add(this.deletebtn);
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 729);
            this.panel1.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-191, -42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(643, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1109, 27);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(88, 24);
            this.toolStripDropDownButton1.Text = "الرئسية";
            // 
            // store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1109, 733);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "store";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المخازن";
            this.Load += new System.EventHandler(this.store_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox totaltxt;
        private System.Windows.Forms.MaskedTextBox quantitytxt;
        private System.Windows.Forms.MaskedTextBox pricetxt;
        private System.Windows.Forms.TextBox itmname;
        private System.Windows.Forms.DateTimePicker datetxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox vendorcombo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox searchcombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox itmunitxt;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button editbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    }
}