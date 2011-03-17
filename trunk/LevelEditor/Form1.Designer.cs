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
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLevelSizeY = new System.Windows.Forms.TextBox();
            this.txtLevelSizeX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkMoveSelected = new System.Windows.Forms.CheckBox();
            this.checkCreateActor = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.display1 = new LevelEditor.Display();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSprite)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(12, 648);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(982, 17);
            this.hScrollBar1.TabIndex = 7;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateLevelSize);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(995, 7);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 640);
            this.vScrollBar1.TabIndex = 8;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // listBoxBackgrounds
            // 
            this.listBoxBackgrounds.FormattingEnabled = true;
            this.listBoxBackgrounds.Location = new System.Drawing.Point(1053, 46);
            this.listBoxBackgrounds.Name = "listBoxBackgrounds";
            this.listBoxBackgrounds.Size = new System.Drawing.Size(143, 108);
            this.listBoxBackgrounds.TabIndex = 10;
            this.listBoxBackgrounds.SelectedIndexChanged += new System.EventHandler(this.listBoxBackground_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1053, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Backgrounds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1053, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sprites";
            // 
            // listBoxSprites
            // 
            this.listBoxSprites.FormattingEnabled = true;
            this.listBoxSprites.Location = new System.Drawing.Point(1050, 308);
            this.listBoxSprites.Name = "listBoxSprites";
            this.listBoxSprites.Size = new System.Drawing.Size(143, 108);
            this.listBoxSprites.TabIndex = 12;
            this.listBoxSprites.SelectedIndexChanged += new System.EventHandler(this.listBoxSprites_SelectedIndexChanged);
            // 
            // imageBoxBackground
            // 
            this.imageBoxBackground.Location = new System.Drawing.Point(1053, 160);
            this.imageBoxBackground.Name = "imageBoxBackground";
            this.imageBoxBackground.Size = new System.Drawing.Size(140, 118);
            this.imageBoxBackground.TabIndex = 11;
            this.imageBoxBackground.TabStop = false;
            // 
            // imageBoxSprite
            // 
            this.imageBoxSprite.Location = new System.Drawing.Point(1050, 422);
            this.imageBoxSprite.Name = "imageBoxSprite";
            this.imageBoxSprite.Size = new System.Drawing.Size(143, 118);
            this.imageBoxSprite.TabIndex = 12;
            this.imageBoxSprite.TabStop = false;
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(1071, 556);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(36, 20);
            this.txtPosX.TabIndex = 0;
            this.txtPosX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateSelectedSprite);
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(1071, 605);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(36, 20);
            this.txtScaleX.TabIndex = 2;
            this.txtScaleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateSelectedSprite);
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(1113, 605);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(38, 20);
            this.txtScaleY.TabIndex = 3;
            this.txtScaleY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateSelectedSprite);
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(1113, 556);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(38, 20);
            this.txtPosY.TabIndex = 1;
            this.txtPosY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateSelectedSprite);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1026, 563);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1036, 612);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Scale";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1018, 652);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "LevelSize";
            // 
            // txtLevelSizeY
            // 
            this.txtLevelSizeY.Location = new System.Drawing.Point(1113, 652);
            this.txtLevelSizeY.Name = "txtLevelSizeY";
            this.txtLevelSizeY.Size = new System.Drawing.Size(38, 20);
            this.txtLevelSizeY.TabIndex = 5;
            this.txtLevelSizeY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateLevelSize);
            // 
            // txtLevelSizeX
            // 
            this.txtLevelSizeX.Location = new System.Drawing.Point(1071, 652);
            this.txtLevelSizeX.Name = "txtLevelSizeX";
            this.txtLevelSizeX.Size = new System.Drawing.Size(36, 20);
            this.txtLevelSizeX.TabIndex = 4;
            this.txtLevelSizeX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.updateLevelSize);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Action:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(444, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLevelToolStripMenuItem,
            this.loadLevelToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveLevelToolStripMenuItem.Text = "Save Level";
            this.saveLevelToolStripMenuItem.Click += new System.EventHandler(this.saveLevelToolStripMenuItem_Click);
            // 
            // loadLevelToolStripMenuItem
            // 
            this.loadLevelToolStripMenuItem.Name = "loadLevelToolStripMenuItem";
            this.loadLevelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.loadLevelToolStripMenuItem.Text = "Load Level";
            this.loadLevelToolStripMenuItem.Click += new System.EventHandler(this.loadLevelToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkMoveSelected
            // 
            this.checkMoveSelected.AutoSize = true;
            this.checkMoveSelected.Location = new System.Drawing.Point(692, 13);
            this.checkMoveSelected.Name = "checkMoveSelected";
            this.checkMoveSelected.Size = new System.Drawing.Size(96, 17);
            this.checkMoveSelected.TabIndex = 19;
            this.checkMoveSelected.Text = "Move selected";
            this.checkMoveSelected.UseVisualStyleBackColor = true;
            // 
            // checkCreateActor
            // 
            this.checkCreateActor.AutoSize = true;
            this.checkCreateActor.Location = new System.Drawing.Point(807, 12);
            this.checkCreateActor.Name = "checkCreateActor";
            this.checkCreateActor.Size = new System.Drawing.Size(84, 17);
            this.checkCreateActor.TabIndex = 20;
            this.checkCreateActor.Text = "Create actor";
            this.checkCreateActor.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(593, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Mouse action:";
            // 
            // display1
            // 
            this.display1.Location = new System.Drawing.Point(12, 46);
            this.display1.Name = "display1";
            this.display1.Size = new System.Drawing.Size(1000, 619);
            this.display1.TabIndex = 6;
            this.display1.Text = "display1";
            this.display1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.display1_MouseClick);
            this.display1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.display1_MouseDown);
            this.display1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.display1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 682);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkCreateActor);
            this.Controls.Add(this.checkMoveSelected);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLevelSizeY);
            this.Controls.Add(this.txtLevelSizeX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.txtScaleY);
            this.Controls.Add(this.txtScaleX);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.imageBoxSprite);
            this.Controls.Add(this.imageBoxBackground);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxSprites);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxBackgrounds);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.display1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LoL Level Editor";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxSprite)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLevelSizeY;
        private System.Windows.Forms.TextBox txtLevelSizeX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLevelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkMoveSelected;
        private System.Windows.Forms.CheckBox checkCreateActor;
        private System.Windows.Forms.Label label7;
    }
}

