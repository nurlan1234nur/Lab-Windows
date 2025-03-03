using CalculatorApp;
using CalculatorApp.Abstract;
using CalculatorApp.Memory;
using System;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Toonii_mashin toonii_mashin = new Toonii_mashin();
        Memory memory = new Memory();

        private string operator_tuluv = "";

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int Number))
            {
                if (operator_tuluv == "+")
                {
                    toonii_mashin.Add(Number);
                    textBox1.Text = toonii_mashin.result.ToString();
                }
                else if (operator_tuluv == "-")
                {
                    toonii_mashin.Substract(Number);
                    textBox1.Text = toonii_mashin.result.ToString();
                }
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int num))
            {
                toonii_mashin.result = num;
                operator_tuluv = "+";
                textBox1.Clear();
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int num))
            {
                toonii_mashin.result = num;
                operator_tuluv = "-";
                textBox1.Clear();
            }
        }

        private void buttonAddNumbertoMemory_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int y);
            memory.Store(y);
            UpdateMemoryDisplay();
        }

        private void AddtoMemoryItem_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int value);
            int index = memory._memoryItems.Count - 1;
            if (index >= 0 && index < memory._memoryItems.Count)
            {
                memory._memoryItems[index].Add(value);
            }

            UpdateMemoryDisplay();
        }


        private void SubstractFromMemoryItem_Click(object sender, EventArgs e)
        {

            int.TryParse(textBox1.Text, out int value);
            int index = memory._memoryItems.Count - 1;
            if (index >= 0 && index < memory._memoryItems.Count)
            {
                memory._memoryItems[index].Substract(value);
            }

            UpdateMemoryDisplay();
        }

        private void buttonClearMemory_Click(object sender, EventArgs e)
        {
            memory.Clear();
            UpdateMemoryDisplay();
        }

        private void ResetResult_Click(object sender, EventArgs e)
        {
            toonii_mashin.resetResult();
            textBox1.Text = string.Empty;
            operator_tuluv = "";
        }
        private void UpdateMemoryDisplay()
        {
            MemoryItems.Text = string.Empty;
            foreach (var item in memory._memoryItems)
            {
                MemoryItems.Text += item.value.ToString() + Environment.NewLine;
            }
        }


        private void MemoryItems_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
                                                                                                                                