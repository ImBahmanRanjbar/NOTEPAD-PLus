using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NOTEPAD_PLus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label1.Text != "Hi")
            {

                if (label1.Text == "Saved")
                    this.Close();
                else
                {
                    if (label1.Text != "Hi")
                    {

                        if (label1.Text == "Saved")
                            this.Close();
                        else
                        {

                            DialogResult a = MessageBox.Show("Do you want to save changes??? ", "NOTEPAD PLus", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (a == DialogResult.Yes)
                            {
                                saveToolStripMenuItem_Click(null, null); this.Close();
                            }
                            else if (a == DialogResult.No)
                            {
                                this.Close();
                            }
                        }
                    }


                }
            }
            else
                this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(367, 0);
            label1.Text = "Hi";
            panel1.BackColor = Color.FromArgb(125, 203, 61);
            timer1.Enabled = true;
        }
        string filename = "";

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Location = new Point(15, 0);
            label1.BackColor = Color.FromArgb(255, 222, 173);
            label1.Text = "NotSaved";
            panel1.BackColor = Color.FromArgb(255, 222, 173);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (label1.Text == "NotSaved")
            {
                DialogResult a = MessageBox.Show("Do you want to save changes??? ", "NOTEPAD PLus", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (a == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(null, null);
                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName != "")
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                        filename = openFileDialog1.FileName;
                        label1.Location = new Point(367, 0);
                        label1.Text = "Hi";
                        label1.BackColor = Color.FromArgb(125, 203, 61);
                        panel1.BackColor = Color.FromArgb(125, 203, 61);
                    }
                }
                else if (a == DialogResult.No)
                {


                    openFileDialog1.ShowDialog();
                    if (openFileDialog1.FileName != "")
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                        filename = openFileDialog1.FileName;
                        label1.Location = new Point(367, 0);
                        label1.Text = "Hi";
                        label1.BackColor = Color.FromArgb(125, 203, 61);
                        panel1.BackColor = Color.FromArgb(125, 203, 61);
                    }
                }
            }

            else
            {
                openFileDialog1.ShowDialog();
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                filename = openFileDialog1.FileName;
            }



        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                filename = saveFileDialog1.FileName;
                label1.BackColor = Color.FromArgb(125, 203, 61);
                label1.Text = "Saved";
                panel1.BackColor = Color.FromArgb(125, 203, 61);

            }
            else if (saveFileDialog1.FileName == "")
            {
                label1.BackColor = Color.FromArgb(255, 222, 173);
                label1.Text = "NotSaved";
                panel1.BackColor = Color.FromArgb(255, 222, 173);
            }

        }
        //شمردن لاین ها
        private void timer1_Tick(object sender, EventArgs e)
        {
            long p = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength);
            p += 1;
            label2.Text = "Line : " + p.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (label1.Text == "NotSaved")
            {
                DialogResult a = MessageBox.Show("Do you want to save changes??? ", "NOTEPAD PLus", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (a == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(null, null);
                }
                else if (a == DialogResult.No)
                {

                    richTextBox1.Clear();
                    label1.Location = new Point(367, 0);
                    label1.Text = "Hi";
                    label1.BackColor = Color.FromArgb(125, 203, 61);
                    panel1.BackColor = Color.FromArgb(125, 203, 61);
                }
            }
            else
                richTextBox1.Clear();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Location = new Point(15, 0);
            File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
            label1.BackColor = Color.FromArgb(125, 203, 61);
            label1.Text = "Saved";
            panel1.BackColor = Color.FromArgb(125, 203, 61);
            if (filename == "")
                saveAsToolStripMenuItem_Click(null, null);
            else
                File.WriteAllText(filename, richTextBox1.Text);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmabout frmabout = new frmabout();
            frmabout.ShowDialog();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Text != "Hi")
            {

                if (label1.Text == "Saved")
                    Application.Exit();
                else
                {
                    if (label1.Text != "Hi")
                    {


                        if (label1.Text != "Saved")
                        {

                            DialogResult a = MessageBox.Show("Do you want to save changes??? ", "NOTEPAD PLus", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            if (a == DialogResult.Yes)
                            {
                                saveToolStripMenuItem_Click(null, null);
                            }

                            else if (a == DialogResult.Cancel)
                                e.Cancel = true;
                        }
                    }


                }
            }



        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
    }
}
