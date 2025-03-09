using CalculatorApp;
using CalculatorApp.Abstract;
using CalculatorApp.MemoryName;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private Toonii_mashin toonii_mashin = new Toonii_mashin();
        private string operator_tuluv = "";

        public Form1()
        {   InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {  textBox1.Text += "1";}
        private void button0_Click(object sender, EventArgs e)
        {   textBox1.Text += "0";}
        private void button2_Click(object sender, EventArgs e)
        {    textBox1.Text += "2"; }
        private void button3_Click(object sender, EventArgs e)
        {   textBox1.Text += "3"; }
        private void button4_Click(object sender, EventArgs e)
        {   textBox1.Text += "4"; }
        private void button5_Click(object sender, EventArgs e)
        {    textBox1.Text += "5"; }
        private void button6_Click(object sender, EventArgs e)
        {  textBox1.Text += "6"; }
        private void button7_Click(object sender, EventArgs e)
        {   textBox1.Text += "7"; }
        private void button8_Click(object sender, EventArgs e)
        {    textBox1.Text += "8"; }
        private void button9_Click(object sender, EventArgs e)
        {   textBox1.Text += "9";}
        private void button10_Click(object sender, EventArgs e)
        {    textBox1.Text += "."; }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int Number))
            {
                if (operator_tuluv == "+")
                    toonii_mashin.Add(Number);
                else if (operator_tuluv == "-")
                    toonii_mashin.Substract(Number);

                textBox1.Text = toonii_mashin.result.ToString();
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

        private void AddtoMemoryItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                var lastItem = toonii_mashin.memory._memoryItems.LastOrDefault();
                if (lastItem != null)
                {
                    lastItem.Add(value);
                }
                UpdateMemoryDisplay();
            }
        }

        private void SubstractFromMemoryItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value))
            {
                var lastItem = toonii_mashin.memory._memoryItems.LastOrDefault();
                if (lastItem != null)
                {
                    lastItem.Substract(value);
                }
                UpdateMemoryDisplay();
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
            if (int.TryParse(textBox1.Text, out int y))
            {
                toonii_mashin.memory.Store(y);
                AddMemoryItemToPanel(y);
            }
        }

        private void AddMemoryItemToPanel(int value)
        {
            Panel itemPanel = new Panel
            {
                Size = new Size(280, 50),
                BackColor = Color.White,
            };

            Label label = new Label
            {
                Text = value.ToString(),
                Size = new Size(100, 30),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
            };

            Button buttonMC = CreateButton("MC", () =>
            {
                panel1.Controls.Remove(itemPanel);
                toonii_mashin.memory.clearItem(value);
            });

            Button buttonMPlus = CreateButton("M+", () =>
            {
                if (int.TryParse(textBox1.Text, out int y))
                {
                    var memoryItem = toonii_mashin.memory._memoryItems.FirstOrDefault(memoryItem => memoryItem.value == value);
                    if (memoryItem != null)
                    {
                        memoryItem.Add(y);
                        label.Text = memoryItem.value.ToString();
                    }
                }
            });

            Button buttonMMinus = CreateButton("M-", () =>
            {
                if (int.TryParse(textBox1.Text, out int y))
                {
                    var memoryItem = toonii_mashin.memory._memoryItems.FirstOrDefault(memoryItem => memoryItem.value == value);
                    if (memoryItem != null)
                    {
                        memoryItem.Substract(y);
                        label.Text = memoryItem.value.ToString();
                    }
                }
            });

            buttonMC.Location = new Point(120, 10);
            buttonMPlus.Location = new Point(170, 10);
            buttonMMinus.Location = new Point(220, 10);

            itemPanel.Controls.Add(label);
            itemPanel.Controls.Add(buttonMC);
            itemPanel.Controls.Add(buttonMPlus);
            itemPanel.Controls.Add(buttonMMinus);

            panel1.Controls.Add( itemPanel);
            panel1.Controls.SetChildIndex(itemPanel, 0);

            UpdatePanelLocations();
        }

        private void UpdatePanelLocations()
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Location = new Point(10, i * 55);
            }
        }


        private Button CreateButton(string text, Action onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Size = new Size(40, 30),
                Visible = true
            };
            btn.Click += (s, e) => onClick();
            return btn;
        }

        private void buttonClearMemory_Click(object sender, EventArgs e)
        {
            toonii_mashin.memory.Clear();
            panel1.Controls.Clear();
            
        }

        private void ResetResult_Click(object sender, EventArgs e)
        {
            toonii_mashin.resetResult();
            textBox1.Text = string.Empty;
            operator_tuluv = "";
        }

        private void UpdateMemoryDisplay()
        {
            panel1.Controls.Clear();
            foreach (var item in toonii_mashin.memory._memoryItems)
            {
                AddMemoryItemToPanel(item.value);
            }
        }

        private void MemoryItems_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
