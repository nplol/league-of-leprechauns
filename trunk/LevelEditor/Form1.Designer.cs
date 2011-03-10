namespace LevelEditor
{
    partial class Form1
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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.listBoxBackgrounds = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSprites = new System.Windows.Forms.ListBox();
            this.dialogBackground = new System.Windows.Forms.FolderBrowserDialog();
            this.dialogSprites = new System.Windows.Forms.FolderBrowserDialog();
            this.imageBoxBackground = new System.Windows.Forms.PictureBox();
            this.imageBoxSprite = new System.Windows.Forms.PictureBox();
            this.display1 = new LevelEditor.Display();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 710);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(982, 17);
            this.hScrollBar1.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(995, 7);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 702);
            this.vScrollBar1.TabIndex = 2;
            // 
            // listBoxBackgrounds
            // 
            this.listBoxBackgrounds.FormattingEnabled = true;
            this.listBoxBackgrounds.Location = new System.Drawing.Point(1053, 46);
            this.listBoxBackgrounds.Name = "listBoxBackgrounds";
            this.listBoxBackgrounds.Size = new System.Drawing.Size(143, 108);
            this.listBoxBackgrounds.TabIndex = 5;
            this.listBoxBackgrounds.SelectedIndexChanged += new System.EventHandler(this.listBoxBackground_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1053, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Backgrounds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1053, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Sprites";
            // 
            // listBoxSprites
            // 
            this.listBoxSprites.FormattingEnabled = true;
            this.listBoxSprites.Location = new System.Drawing.Point(1053, 392);
            this.listBoxSprites.Name = "listBoxSprites";
            this.listBoxSprites.Size = new System.Drawing.Size(143, 108);
            this.listBoxSprites.TabIndex = 9;
            this.listBoxSprites.SelectedIndexChanged += new System.EventHandler(this.listBoxSprites_SelectedIndexChanged);
            // 
            // imageBoxBackground
            // 
            this.imageBoxBackground.Location = new System.Drawing.Point(1056, 184);
            this.imageBoxBackground.Name = "imageBoxBackground";
            this.imageBoxBackground.Size = new System.Drawing.Size(140, 118);
            this.imageBoxBackground.TabIndex = 11;
            this.imageBoxBackground.TabStop = false;
            // 
            // imageBoxSprite
            // 
            this.imageBoxSprite.Location = new System.Drawing.Point(1053, 529);
            this.imageBoxSprite.Name = "imageBoxSprite";
            this.imageBoxSprite.Size = new System.Drawing.Size(143, 118);
            this.imageBoxSprite.TabIndex = 12;
            this.imageBoxSprite.TabStop = false;
            // 
            // display1
            // 
            this.display1.Location = new System.Drawing.Point(12, 7);
            this.display1.Name = "display1";
            this.display1.Size = new System.Drawing.Size(1000, 720);
            this.display1.TabIndex = 0;
            this.display1.Text = "display1";
            this.display1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.display1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 742);
            this.Controls.Add(this.imageBoxSprite);
            this.Controls.Add(this.imageBoxBackground);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxSprites);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxBackgrounds);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.display1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Display display1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ListBox listBoxBackgrounds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSprites;
        private System.Windows.Forms.FolderBrowserDialog dialogBackground;
        private System.Windows.Forms.FolderBrowserDialog dialogSprites;
        private System.Windows.Forms.PictureBox imageBoxBackground;
        private System.Windows.Forms.PictureBox imageBoxSprite;
    }
}

