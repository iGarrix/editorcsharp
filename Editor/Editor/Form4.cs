using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form4 : Form
    {
        public RichTextBox rt;
        public Form4(RichTextBox _rt)
        {
            InitializeComponent();
            this.rt = _rt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//показуємо стандартне вікно відкриття файлу
            {

                try
                {
                    // Save selected text to the chosen file
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, rt.SelectedText);
                    MessageBox.Show("Selected text saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving selected text: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { saveFileDialog1.Dispose(); this.Close(); } 
            }
        }
    }
}
