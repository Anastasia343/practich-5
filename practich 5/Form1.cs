using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary2;

namespace practich_5
{
    public partial class Form1 : Form
    {
        Class1 l = new Class1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            bn.Notify += DisplayMessage;

            bn.Take(Convert.ToInt32(textBox2.Text));
        }
        Class1 bn = new Class1(0);

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add($"Пользователь: {textBox1.Text}\nТекущий баланс : {bn.Sum}");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bn.Notify += DisplayMessage;
            bn.Put(Convert.ToInt32(textBox2.Text));
        }
        void DisplayMessage(Class1 sender, AccountEventArgs e)
        {
            
           listBox1.Items.Add(e.Message);
           listBox1.Items.Add($"Текущая сумма на счете: {sender.Sum}");
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
