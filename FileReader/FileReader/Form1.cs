using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileReader
{
    public partial class Form1 : Form
    {
        Font boldFont = new Font("Arial", 10, FontStyle.Bold);
        Font italicFont = new Font("Arial", 10, FontStyle.Italic);
        Font strikeFont = new Font("Arial", 10, FontStyle.Strikeout);
        Font underlineFont = new Font("Arial", 10, FontStyle.Underline);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Select a File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Fies (*.txt) | *.txt";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                txtSourceFile.Text = openFileDialog1.FileName;
            else
                txtSourceFile.Text = "";
        }


        private void btnDestination_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Select a Destination Directory";
            saveFileDialog1.Filter = "Text Fies (*.txt) | *.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.OverwritePrompt = true;
                       
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                txtDestinationFile.Text = saveFileDialog1.FileName;
            else
                txtDestinationFile.Text = "";
        }

        bool SourceFileExists()
        {
            if (!System.IO.File.Exists(txtSourceFile.Text))
            {
                MessageBox.Show("The Source File Doesen't Exist");
                return false;
            }
            else
                return true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!SourceFileExists())
                return;
            System.IO.File.Copy(txtSourceFile.Text, txtDestinationFile.Text);
            MessageBox.Show("The file has been successfully copied!");
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!SourceFileExists())
                return;
            System.IO.File.Move(txtSourceFile.Text, txtDestinationFile.Text);
            MessageBox.Show("The file has been successfully moved!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!SourceFileExists())
                return;
            if(MessageBox.Show("Are you sure you want to delete?", "Delete Verfication", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.IO.File.Delete(txtSourceFile.Text);
                MessageBox.Show("The file has been successfully deleted!");
            }
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string pathfile = @txtSourceFile.Text;
            txtOpenedFile.Text = File.ReadAllText(pathfile);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string content = txtOpenedFile.Text;
            string pathfile = @txtSourceFile.Text;

            File.WriteAllText(pathfile, content);
            MessageBox.Show("The file has been successfully updated!");
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionFont = boldFont;
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionFont = italicFont;
        }

        private void btnALeft_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btnACenter_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnARight_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionFont = underlineFont;
        }

        private void btnStrike_Click(object sender, EventArgs e)
        {
            txtOpenedFile.SelectionFont = strikeFont;
        }
    }
}
