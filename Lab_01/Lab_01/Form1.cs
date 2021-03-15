using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab_01
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        float current = 0;
        float buf = 0;
        float memory;

        private void button1_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 9;
        }


        int operation = 0;
        private void Sin_Click(object sender, EventArgs e)
        {
            boolReset();
            Sin.BackColor = Color.Azure;
            operation = 1;
        }

        private void Cos_Click(object sender, EventArgs e)
        {
            boolReset();
            Cos.BackColor = Color.Azure;
            operation = 2;
        }

        private void Tang_Click(object sender, EventArgs e)
        {
            boolReset();
            Tang.BackColor = Color.Azure;
            operation = 3;
        }

        private void Ctg_Click(object sender, EventArgs e)
        {
            boolReset();
            Ctg.BackColor = Color.Azure;
            operation = 4;
        }

        private void Expon_Click(object sender, EventArgs e)
        {
            boolReset();
            Expon.BackColor = Color.Azure;
            operation = 7;
            buf = float.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try { 
            colors();
            current = float.Parse(textBox1.Text);
            switch (operation)
            {
                
                case 1:
                    current = (float)Math.Sin(current);
                textBox1.Text = current.ToString();
                break;
                case 2:
                    current = (float)Math.Cos(current);
                textBox1.Text = current.ToString();
                break;
                case 3:
                    current = (float)Math.Tan(current);
                textBox1.Text = current.ToString();
                break;
                case 4:
                    current = 1 / (float)Math.Tan(current);
                textBox1.Text = current.ToString();
                break;
                case 5:
                    current = (float)Math.Pow(current, 1.0 / 3);
                textBox1.Text = current.ToString();
                break;
                case 6:
                    if (current >= 0)
                {
                    current = (float)Math.Sqrt(current);
                    textBox1.Text = current.ToString();
                }
                else
                {
                    textBox1.Text = "error";
                    throw new Exception("Ошибочка вышла");
                }
                break;
                case 7:
                    current = (float)Math.Pow(buf, current);
                textBox1.Text = current.ToString();
                break;
                case 8:
                    current = buf + current;
                textBox1.Text = current.ToString();
                break;
                case 9:
                    current = buf - current;
                textBox1.Text = current.ToString();
                break;
                case 10:
                    current = buf / current;
                textBox1.Text = current.ToString();
                break;
                case 11:
                    current = buf * current;
                textBox1.Text = current.ToString();
                break;
                default:
                    textBox1.Text = "error";
                throw new Exception("Ошибочка вышла");
                break;
            }
            }catch(Exception a)
            { textBox1.Text = a.Message; }
        }

        private void colors()
        {
            Sin.BackColor = Color.Gainsboro;
            Cos.BackColor = Color.Gainsboro;
            AddMemory.BackColor = Color.Gainsboro;
            OutMemory.BackColor = Color.Gainsboro;
            Tang.BackColor = Color.Gainsboro;
            Ctg.BackColor = Color.Gainsboro;
            Root3.BackColor = Color.Gainsboro;
            Root.BackColor = Color.Gainsboro;
            OutMemory.BackColor = Color.Gainsboro;
            Expon.BackColor = Color.Gainsboro;
            Plus.BackColor = Color.Gainsboro;
            Minus.BackColor = Color.Gainsboro;
            Multiple.BackColor = Color.Gainsboro;
            Division.BackColor = Color.Gainsboro;
        }

        private void boolReset()
        {

            operation = 0;
            colors();
        }
        private void Root3_Click(object sender, EventArgs e)
        {
            colors();
            Root3.BackColor = Color.Azure;
            operation = 5;
        }

        private void Root_Click(object sender, EventArgs e)
        {
            colors();
            Root.BackColor = Color.Azure;
            operation = 6;
        }

        private void AddMemory_Click(object sender, EventArgs e)
        {
            boolReset();
            memory = float.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            boolReset();
            textBox1.Text = "";
        }

        private void OutMemory_Click(object sender, EventArgs e)
        {
            boolReset();
            textBox1.Text = memory.ToString();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            boolReset();
            Plus.BackColor = Color.Azure;
            operation = 8;
            buf = float.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            boolReset();
            Minus.BackColor = Color.Azure;
            operation = 9;
            if (textBox1.Text == "error" || textBox1.Text == "") buf = 0;
            else buf = float.Parse(textBox1.Text);

            textBox1.Text = "";
        }

        private void Division_Click(object sender, EventArgs e)
        {
            boolReset();
            Division.BackColor = Color.Azure;
            operation = 10;
            buf = float.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void Multiple_Click(object sender, EventArgs e)
        {
            boolReset();
            Multiple.BackColor = Color.Azure;
            operation = 11;
            buf = float.Parse(textBox1.Text);
            textBox1.Text = "";
        }

        private void Equal_Load(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (operation < 7) boolReset();
            textBox1.Text = textBox1.Text + 0;
        }
    }
}
