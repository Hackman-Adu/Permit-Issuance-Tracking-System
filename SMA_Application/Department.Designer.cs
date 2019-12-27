namespace SMA_Application
{
    partial class Department
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Department));
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainName = new System.Windows.Forms.Label();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deptRegion = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.proName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.EmailA = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.El = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deptName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tel = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.telL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.MainName);
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 36);
            this.panel1.TabIndex = 3;
            // 
            // MainName
            // 
            this.MainName.AutoSize = true;
            this.MainName.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainName.ForeColor = System.Drawing.Color.White;
            this.MainName.Location = new System.Drawing.Point(287, 7);
            this.MainName.Name = "MainName";
            this.MainName.Size = new System.Drawing.Size(163, 22);
            this.MainName.TabIndex = 1;
            this.MainName.Text = "Department Details";
            this.MainName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.SteelBlue;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(704, 5);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(29, 25);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 6;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tel);
            this.groupBox1.Controls.Add(this.telL);
            this.groupBox1.Controls.Add(this.deptRegion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.proName);
            this.groupBox1.Controls.Add(this.EmailA);
            this.groupBox1.Controls.Add(this.El);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.deptName);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 253);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Details";
            // 
            // deptRegion
            // 
            this.deptRegion.BorderColorFocused = System.Drawing.Color.White;
            this.deptRegion.BorderColorIdle = System.Drawing.Color.White;
            this.deptRegion.BorderColorMouseHover = System.Drawing.Color.White;
            this.deptRegion.BorderThickness = 1;
            this.deptRegion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deptRegion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptRegion.ForeColor = System.Drawing.Color.White;
            this.deptRegion.isPassword = false;
            this.deptRegion.Location = new System.Drawing.Point(168, 113);
            this.deptRegion.Margin = new System.Windows.Forms.Padding(4);
            this.deptRegion.Name = "deptRegion";
            this.deptRegion.Size = new System.Drawing.Size(524, 29);
            this.deptRegion.TabIndex = 40;
            this.deptRegion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 39;
            this.label2.Tag = "";
            this.label2.Text = "Region";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 38;
            this.label3.Tag = "";
            this.label3.Text = "Project Name";
            // 
            // proName
            // 
            this.proName.BorderColorFocused = System.Drawing.Color.White;
            this.proName.BorderColorIdle = System.Drawing.Color.White;
            this.proName.BorderColorMouseHover = System.Drawing.Color.White;
            this.proName.BorderThickness = 1;
            this.proName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.proName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proName.ForeColor = System.Drawing.Color.White;
            this.proName.isPassword = false;
            this.proName.Location = new System.Drawing.Point(168, 69);
            this.proName.Margin = new System.Windows.Forms.Padding(4);
            this.proName.Name = "proName";
            this.proName.Size = new System.Drawing.Size(524, 29);
            this.proName.TabIndex = 37;
            this.proName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // EmailA
            // 
            this.EmailA.BorderColorFocused = System.Drawing.Color.White;
            this.EmailA.BorderColorIdle = System.Drawing.Color.White;
            this.EmailA.BorderColorMouseHover = System.Drawing.Color.White;
            this.EmailA.BorderThickness = 1;
            this.EmailA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailA.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailA.ForeColor = System.Drawing.Color.White;
            this.EmailA.isPassword = false;
            this.EmailA.Location = new System.Drawing.Point(168, 157);
            this.EmailA.Margin = new System.Windows.Forms.Padding(4);
            this.EmailA.Name = "EmailA";
            this.EmailA.Size = new System.Drawing.Size(524, 29);
            this.EmailA.TabIndex = 34;
            this.EmailA.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // El
            // 
            this.El.AutoSize = true;
            this.El.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.El.ForeColor = System.Drawing.Color.White;
            this.El.Location = new System.Drawing.Point(8, 167);
            this.El.Name = "El";
            this.El.Size = new System.Drawing.Size(115, 19);
            this.El.TabIndex = 33;
            this.El.Tag = "";
            this.El.Text = "Email Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 19);
            this.label1.TabIndex = 29;
            this.label1.Tag = "";
            this.label1.Text = "Department Name";
            // 
            // deptName
            // 
            this.deptName.BorderColorFocused = System.Drawing.Color.White;
            this.deptName.BorderColorIdle = System.Drawing.Color.White;
            this.deptName.BorderColorMouseHover = System.Drawing.Color.White;
            this.deptName.BorderThickness = 1;
            this.deptName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deptName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptName.ForeColor = System.Drawing.Color.White;
            this.deptName.isPassword = false;
            this.deptName.Location = new System.Drawing.Point(168, 25);
            this.deptName.Margin = new System.Windows.Forms.Padding(4);
            this.deptName.Name = "deptName";
            this.deptName.Size = new System.Drawing.Size(524, 29);
            this.deptName.TabIndex = 30;
            this.deptName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this;
            this.bunifuDragControl2.Vertical = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(12, 311);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(118, 24);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Edit Settings";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::SMA_Application.Properties.Resources.save_1;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(180, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(544, 29);
            this.button2.TabIndex = 30;
            this.button2.Text = "    Save Settings";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tel
            // 
            this.tel.BorderColorFocused = System.Drawing.Color.White;
            this.tel.BorderColorIdle = System.Drawing.Color.White;
            this.tel.BorderColorMouseHover = System.Drawing.Color.White;
            this.tel.BorderThickness = 1;
            this.tel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tel.ForeColor = System.Drawing.Color.White;
            this.tel.isPassword = false;
            this.tel.Location = new System.Drawing.Point(168, 205);
            this.tel.Margin = new System.Windows.Forms.Padding(4);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(524, 29);
            this.tel.TabIndex = 42;
            this.tel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // telL
            // 
            this.telL.AutoSize = true;
            this.telL.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telL.ForeColor = System.Drawing.Color.White;
            this.telL.Location = new System.Drawing.Point(8, 214);
            this.telL.Name = "telL";
            this.telL.Size = new System.Drawing.Size(143, 19);
            this.telL.TabIndex = 41;
            this.telL.Tag = "";
            this.telL.Text = "Telephone (+233)";
            // 
            // Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(736, 344);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Department";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Department_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MainName;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Bunifu.Framework.UI.BunifuMetroTextbox EmailA;
        private System.Windows.Forms.Label El;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuMetroTextbox deptRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        public Bunifu.Framework.UI.BunifuMetroTextbox deptName;
        public Bunifu.Framework.UI.BunifuMetroTextbox proName;
        private Bunifu.Framework.UI.BunifuMetroTextbox tel;
        private System.Windows.Forms.Label telL;
    }
}