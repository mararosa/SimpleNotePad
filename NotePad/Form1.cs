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

namespace NotePad
{
    public partial class Form1 : Form
    {
        //Dialogs
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Creates a new file.
        private void NewFile()
        {
            try
            {
                if(!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    MessageBox.Show("You need to save first");
                }
                else
                {
                    this.richTextBox1.Text = string.Empty;
                    this.Text = "Untitled";
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }

        private void SaveFile()
        {
            try
            {

                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text File (*.txt) | *.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("There is no text");
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }

        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while trying to open file");
            }
            finally
            {
                openFileDialog = null; //convert the object to new again
            }
        }
        private void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text File (*.txt) | *.txt! All Files(*.*) | *.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("There is no text");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(); 
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog = new FontDialog();

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fontDialog.Font;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
