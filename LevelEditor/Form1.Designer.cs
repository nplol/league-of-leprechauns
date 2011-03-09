namespace LevelEditor
{
    partial class form1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxBackgrounds = new System.Windows.Forms.PictureBox();
            this.pictureBoxSprites = new System.Windows.Forms.PictureBox();
            this.txtBoxSprites = new System.Windows.Forms.TextBox();
            this.listBoxSprites = new System.Windows.Forms.ListBox();
            this.listBoxBackgrounds = new System.Windows.Forms.ListBox();
            this.txtBoxBackground = new System.Windows.Forms.TextBox();
            this.btnSelectSpritesFolder = new System.Windows.Forms.Button();
            this.labelBackground = new System.Windows.Forms.Label();
            this.lblSprites = new System.Windows.Forms.Label();
            this.dialogBackground = new System.Windows.Forms.FolderBrowserDialog();
            this.dialogSprites = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectBGFolder = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgrounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSprites)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 621);
            this.panel2.TabIndex = 1;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // pictureBoxBackgrounds
            // 
            this.pictureBoxBackgrounds.Location = new System.Drawing.Point(997, 206);
            this.pictureBoxBackgrounds.Name = "pictureBoxBackgrounds";
            this.pictureBoxBackgrounds.Size = new System.Drawing.Size(159, 108);
            this.pictureBoxBackgrounds.TabIndex = 2;
            this.pictureBoxBackgrounds.TabStop = false;
            // 
            // pictureBoxSprites
            // 
            this.pictureBoxSprites.Location = new System.Drawing.Point(997, 515);
            this.pictureBoxSprites.Name = "pictureBoxSprites";
            this.pictureBoxSprites.Size = new System.Drawing.Size(159, 118);
            this.pictureBoxSprites.TabIndex = 3;
            this.pictureBoxSprites.TabStop = false;
            // 
            // txtBoxSprites
            // 
            this.txtBoxSprites.Location = new System.Drawing.Point(997, 343);
            this.txtBoxSprites.Name = "txtBoxSprites";
            this.txtBoxSprites.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSprites.TabIndex = 5;
            // 
            // listBoxSprites
            // 
            this.listBoxSprites.FormattingEnabled = true;
            this.listBoxSprites.Location = new System.Drawing.Point(997, 398);
            this.listBoxSprites.Name = "listBoxSprites";
            this.listBoxSprites.Size = new System.Drawing.Size(120, 95);
            this.listBoxSprites.TabIndex = 6;
            this.listBoxSprites.SelectedIndexChanged += new System.EventHandler(this.listBoxSprites_SelectedIndexChanged);
            // 
            // listBoxBackgrounds
            // 
            this.listBoxBackgrounds.FormattingEnabled = true;
            this.listBoxBackgrounds.Location = new System.Drawing.Point(997, 91);
            this.listBoxBackgrounds.Name = "listBoxBackgrounds";
            this.listBoxBackgrounds.Size = new System.Drawing.Size(120, 95);
            this.listBoxBackgrounds.TabIndex = 8;
            this.listBoxBackgrounds.SelectedIndexChanged += new System.EventHandler(this.listBoxBackgrounds_SelectedIndexChanged);
            // 
            // txtBoxBackground
            // 
            this.txtBoxBackground.Location = new System.Drawing.Point(997, 36);
            this.txtBoxBackground.Name = "txtBoxBackground";
            this.txtBoxBackground.Size = new System.Drawing.Size(100, 20);
            this.txtBoxBackground.TabIndex = 7;
            // 
            // btnSelectSpritesFolder
            // 
            this.btnSelectSpritesFolder.Location = new System.Drawing.Point(1103, 340);
            this.btnSelectSpritesFolder.Name = "btnSelectSpritesFolder";
            this.btnSelectSpritesFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSpritesFolder.TabIndex = 10;
            this.btnSelectSpritesFolder.Text = "Select Folder";
            this.btnSelectSpritesFolder.UseVisualStyleBackColor = true;
            this.btnSelectSpritesFolder.Click += new System.EventHandler(this.btnSelectSpritesFolder_Click);
            // 
            // labelBackground
            // 
            this.labelBackground.AutoSize = true;
            this.labelBackground.Location = new System.Drawing.Point(997, 12);
            this.labelBackground.Name = "labelBackground";
            this.labelBackground.Size = new System.Drawing.Size(65, 13);
            this.labelBackground.TabIndex = 11;
            this.labelBackground.Text = "Background";
            // 
            // lblSprites
            // 
            this.lblSprites.AutoSize = true;
            this.lblSprites.Location = new System.Drawing.Point(994, 317);
            this.lblSprites.Name = "lblSprites";
            this.lblSprites.Size = new System.Drawing.Size(39, 13);
            this.lblSprites.TabIndex = 12;
            this.lblSprites.Text = "Sprites";
            // 
            // buttonSelectBGFolder
            // 
            this.buttonSelectBGFolder.Location = new System.Drawing.Point(1103, 34);
            this.buttonSelectBGFolder.Name = "buttonSelectBGFolder";
            this.buttonSelectBGFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectBGFolder.TabIndex = 13;
            this.buttonSelectBGFolder.Text = "Select folder";
            this.buttonSelectBGFolder.UseVisualStyleBackColor = true;
            this.buttonSelectBGFolder.Click += new System.EventHandler(this.buttonSelectBGFolder_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(295, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Place";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(361, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Move";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(419, 26);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(56, 17);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Delete";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Edit options";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonSelectBGFolder);
            this.Controls.Add(this.lblSprites);
            this.Controls.Add(this.labelBackground);
            this.Controls.Add(this.btnSelectSpritesFolder);
            this.Controls.Add(this.listBoxBackgrounds);
            this.Controls.Add(this.txtBoxBackground);
            this.Controls.Add(this.listBoxSprites);
            this.Controls.Add(this.txtBoxSprites);
            this.Controls.Add(this.pictureBoxSprites);
            this.Controls.Add(this.pictureBoxBackgrounds);
            this.Controls.Add(this.panel2);
            this.Name = "form1";
            this.Text = "LoL Level Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackgrounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSprites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxBackgrounds;
        private System.Windows.Forms.PictureBox pictureBoxSprites;
        private System.Windows.Forms.TextBox txtBoxSprites;
        private System.Windows.Forms.ListBox listBoxSprites;
        private System.Windows.Forms.ListBox listBoxBackgrounds;
        private System.Windows.Forms.TextBox txtBoxBackground;
        private System.Windows.Forms.Button btnSelectSpritesFolder;
        private System.Windows.Forms.Label labelBackground;
        private System.Windows.Forms.Label lblSprites;
        private System.Windows.Forms.FolderBrowserDialog dialogBackground;
        private System.Windows.Forms.FolderBrowserDialog dialogSprites;
        private System.Windows.Forms.Button buttonSelectBGFolder;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label1;
    }
}

