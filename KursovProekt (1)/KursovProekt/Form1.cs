using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovProekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = new string(Class1.M);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Text = "Текст";
            button1.Text = "Криптирай";
            textBox1.Text = new string(Class1.M);
            textBox2.Text = Class1.TestText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Въведи текст преди да започнеш процеса на криптиране/декриптиране.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }


                if (radioButton1.Checked)
                {
                    textBox3.Text = Class1.Encrypt(textBox2.Text).Item2;
                }
                else
                {
                    textBox3.Text = Class1.Decrypt(textBox2.Text);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Декриптирай";
            groupBox2.Text = "Криптограма";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
