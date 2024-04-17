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
    public partial class Form1 : Form
    {
        public bool edt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!edt) //якщо документ не змінювався

            { richTextBox1.Clear();/* Очищуемо текст в багаторядковому редакторі */ }

            else

            {//якщо текст змінювався

                //нагадуємо користувачу що зміни пропадуть

                if (MessageBox.Show("Text changed - continue?", "Qestion", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)

                    richTextBox1.Clear(); //якщо користувач натиснув "Так"

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//показуємо стандартне вікно відкриття файлу

            {

                //якщо файл вибрано

                richTextBox1.LoadFile(openFileDialog1.FileName);//відкриваємо файл

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//показуємо стандартне вікно відкриття файлу

            {

                //якщо вибрано ім’я файлу

                richTextBox1.SaveFile(saveFileDialog1.FileName);//зберігаємо файл

                edt = false;//прописуємо, що текст не змінений

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            edt = true;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) //показуємо стандартне вікно шрифтів

                //якщо новий шрифт вибрано

                richTextBox1.Font = fontDialog1.Font;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);//копіюємо текст в буфер обміну

            richTextBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = Clipboard.GetText();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(richTextBox1);//ініціалізуємо форму пошуку

            f2.ShowDialog();
        }
            
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(richTextBox1);//ініціалізуємо форму заміни

            f3.ShowDialog();
        }

        private void saveSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f4 = new Form4(richTextBox1);
            f4.ShowDialog();
        }
    }
}
