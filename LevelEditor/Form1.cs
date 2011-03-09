using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace LevelEditor
{
    public partial class form1 : Form
    {
        string fileExtension = ".png";
        string backgroundPath;
        string spritesPath;
        Graphics graphics;
        public form1()
        {
            InitializeComponent();
            graphics = panel2.CreateGraphics();
            panel2.VerticalScroll.Enabled = true; 
        }

        private void buttonSelectBGFolder_Click(object sender, EventArgs e)
        {
            dialogBackground.SelectedPath = @"C:\workspace\League of Leprechauns\League of Leprechauns\League of LeprechaunsContent";
            dialogBackground.ShowDialog();
            txtBoxBackground.Text = dialogBackground.SelectedPath;
            backgroundPath = dialogBackground.SelectedPath;
            addFiles(listBoxBackgrounds, dialogBackground.SelectedPath);
        }

        private void addFiles(ListBox box, string pathname)
        {
            String []files = Directory.GetFiles(pathname);

            for (int i = 0; i < files.Length; i++)
            {
                box.Items.Add(Path.GetFileNameWithoutExtension(files[i]));
            }
        }

        private void listBoxBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBackgrounds.SelectedItem == null)
                return;
            Image image = Image.FromFile(Path.Combine(backgroundPath, (string)listBoxBackgrounds.SelectedItem + fileExtension));
            pictureBoxBackgrounds.Image = image;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            //check if 
        }

        private void btnSelectSpritesFolder_Click(object sender, EventArgs e)
        {
            dialogBackground.SelectedPath = @"C:\workspace\League of Leprechauns\League of Leprechauns\League of LeprechaunsContent";
            dialogBackground.ShowDialog();
            txtBoxBackground.Text = dialogBackground.SelectedPath;
            spritesPath = dialogBackground.SelectedPath;
            addFiles(listBoxSprites, dialogBackground.SelectedPath);
        }

        private void listBoxSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBackgrounds.SelectedItem == null)
                return;
            Image image = Image.FromFile(Path.Combine(backgroundPath, (string)listBoxBackgrounds.SelectedItem + fileExtension));
            pictureBoxBackgrounds.Image = image;
        }
    }
}
