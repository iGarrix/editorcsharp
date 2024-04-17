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
    public partial class Form2 : Form
    {
        public RichTextBox rt; //посилання на багаторядковий редактор, в якому відбувається пошук

        int ind = 0;
        public Form2(RichTextBox r)//конструктор форми

        {

            InitializeComponent();//ініціалізація форми

            rt = r;//зберігаємо посилання на компоненту редактора тексту

            rt.HideSelection = false;//при втраті фокусу не приховувати виділений фрагмент

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;//зберігаємо в змінну текст для пошуку, так зручніше

            if (checkBox1.Checked)//якщо відмічено ігнорувати реєстр

            {

                //шукаємо фрагмент тексту

                //s - фрагмент тексту,

                //ind - індекс початку пошуку,

                //StringComparison.CurrentCultureIgnoreCase - знехтувати реєстром

                ind = rt.Text.IndexOf(s, ind, StringComparison.CurrentCultureIgnoreCase);

                if (ind != -1)//ind = -1 якщо нічого не знайдено

                {

                    //виділяємо в редакторі фрагмент знайденого тексту

                    rt.SelectionStart = ind;//позначаємо початок

                    rt.SelectionLength = s.Length;//вказуємо довжину виділення

                    ind += s.Length;//зміщуємо початок пошуку, для того, щоб знову не знайти те саме включення шуканого фрагменту

                }

                else { MessageBox.Show("Noting finded!"); }//виводимо повідомлення що не вдалося нічого знайти

            }

            else //якщо реєстр ігнорувати непотрібно

            {

                //шукаємо фрагмент тексту

                //s - фрагмент тексту,

                //ind - індекс початку пошуку,

                //StringComparison.CurrentCulture - пошук повного входження фрагменту тексту згідно локальних налаштувань

                ind = rt.Text.IndexOf(s, ind, StringComparison.CurrentCulture);

                if (ind != -1)//ind = -1 якщо нічого не знайдено

                {

                    //виділяємо в редакторі фрагмент знайденого тексту

                    rt.SelectionStart = ind;//позначаємо початок

                    rt.SelectionLength = s.Length;//вказуємо довжину виділення

                    ind += s.Length;//зміщуємо початок пошуку, для того, щоб знову не знайти те саме включення шуканого фрагменту

                }

                else { MessageBox.Show("Noting finded!"); }//виводимо повідомлення що не вдалося нічого знайти

            }



        }
    }
}
