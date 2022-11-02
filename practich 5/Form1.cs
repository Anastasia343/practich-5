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
            
            l.sum -= Convert.ToInt32(textBox2.Text);
            listBox1.Items.Add($"Снята сумма: {textBox2.Text}\nТекущий баланс: {l.sum}");
            textBox2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 ex = new Class1(0);
            listBox1.Items.Add($"Пользователь: {textBox1.Text}\nТекущий баланс : {l.sum}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            l.sum += Convert.ToInt32(textBox2.Text);
            listBox1.Items.Add($"Внесена сумма: {textBox2.Text}\nТекущий баланс: {l.sum}");
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
