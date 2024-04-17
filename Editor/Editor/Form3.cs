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
    public partial class Form3 : Form
    {
        public int ind = 0;//індекс символу з якого відбувається пошук

        public RichTextBox rt;//посилання на багаторядковий редактор, в якому відбувається пошук

        public Form3(RichTextBox r)//конструктор форми

        {

            InitializeComponent();//ініціалізація форми

            rt = r;//зберігаємо посилання на компоненту редактора тексту

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rt.HideSelection = false;//показуємо виділення при втраті фокусу

            string s = textBox1.Text;//шуканий фрагмент тексту

            string rs = textBox2.Text;//текст для заміни

            StringComparison sc;//вид пошуку

            if (checkBox1.Checked)//якщо відмічено ігнорувати реєстр

            { sc = StringComparison.CurrentCultureIgnoreCase; }
            else { sc = StringComparison.CurrentCulture; }
            while (ind != -1)//поки в тексті містяться задані фрагменти тексту (ind = -1 -- нічого не знайдено)

            {

                ind = rt.Text.IndexOf(s, ind, sc);

                if (ind != -1)//перевіряємо чи знайшли

                {//знайшли

                    rt.SelectionStart = ind;//пробуємо знайти фрагмент тексту

                    rt.SelectionLength = s.Length;//вказуємо довжину виділеного фрагменту

                    //виводимо повідомлення про заміну тексту

                    if (MessageBox.Show("Replace this?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)

                        //якщо користувач дав згоду

                        rt.SelectedText = rs;//замінюємо виділений фрагмент новим

                    ind += s.Length;//зміщуємо індекс пошуку

                }

            }

            MessageBox.Show("Done!");//виводимо повідомлення про завершення заміни

            this.Close();//ховаємо форму


        }

        private void button3_Click(object sender, EventArgs e)
        {
            rt.HideSelection = true;//ховаємо виділення тексту при втраті фокусу компоненти

            string s = textBox1.Text;//текст який шукаємо

            string rs = textBox2.Text;//текст на який замінюємо

            StringComparison sc;//вид пошуку для заміни

            if (checkBox1.Checked)//якщо відмічено ігнорувати реєстр

            { sc = StringComparison.CurrentCultureIgnoreCase; }
            else { sc = StringComparison.CurrentCulture; }
            while (ind != -1)//поки в тексті містяться задані фрагменти тексту (ind = -1 -- нічого не знайдено)

            {

                ind = rt.Text.IndexOf(s, ind, sc);//пробуємо знайти фрагмент тексту

                if (ind != -1) //перевіряємо чи знайшли

                { //знайшли

                    rt.SelectionStart = ind;//помічаємо початок виділеного тексту в компоненті

                    rt.SelectionLength = s.Length;//вказуємо довжину виділеного фрагменту

                    rt.SelectedText = rs;//замінюємо виділений текст на новий

                    ind += s.Length;//зміщуємо початок пошуку для іншої ітерації

                }

            }

            MessageBox.Show("Done!");//виводимо що заміна завершена

            this.Close();
        }
    }
}
