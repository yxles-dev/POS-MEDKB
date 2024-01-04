using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace POS_MEDKB
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            new ToolTip().SetToolTip(Cookie, "Cookie");
            new ToolTip().SetToolTip(pictureBox2, "Cake");
            new ToolTip().SetToolTip(pictureBox5, "Halo-Halo");
            new ToolTip().SetToolTip(pictureBox7, "Leche Flan");
            new ToolTip().SetToolTip(pictureBox10, "Turon");
            new ToolTip().SetToolTip(pictureBox11, "Ube Halaya");
            new ToolTip().SetToolTip(pictureBox3, "Biko");
            new ToolTip().SetToolTip(pictureBox8, "Mango Graham");
            new ToolTip().SetToolTip(pictureBox4, "Buko Pandan");
            new ToolTip().SetToolTip(pictureBox9, "Puto");
            new ToolTip().SetToolTip(pictureBox6, "Ice Cream");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addItems("Cookie", 100);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addItems("Cake", 500);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            addItems("Halo-Halo", 80);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            addItems("Biko", 50);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            addItems("Buko Pandan", 40);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            addItems("Ice Cream", 30);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            addItems("Leche Flan", 60);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            addItems("Mango Graham", 75);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            addItems("Puto", 10);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            addItems("Turon", 40);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            addItems("Ube Halaya", 65);
        }

        public void addItems(string item, int price)
        {
            bool itemFound = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Item"].Value.ToString() == item)
                {
                    Console.WriteLine("Item exist");
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = quantity + 1;
                    int newPrice = int.Parse(row.Cells["Price"].Value.ToString());
                    row.Cells["Price"].Value = newPrice + price;
                    itemFound = true;
                    break;
                }
            }
            if (!itemFound)
            {
                Debug.WriteLine("Item doesnt exist");
                dataGridView1.Rows.Add(1, item, price);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Value Changed");
            if (e.ColumnIndex == 0)
            {
                try
                {
                    string food = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                    int price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    int newquantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    Debug.WriteLine(food);
                    int newprice;
                    switch (food)
                    {
                        case "Biko":
                            newprice = newquantity * 50;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Halo-Halo":
                            newprice = 80 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Leche Flan":
                            newprice = 60 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Turon":
                            newprice = 40 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Ube Halaya":
                            newprice = 65 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Mango Graham":
                            newprice = 75 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Buko Pandan":
                            newprice = 40 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Puto":
                            newprice = 10 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Ice Cream":
                            newprice = 30 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Cake":
                            newprice = 500 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                        case "Cookie":
                            newprice = 100 * newquantity;
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = newprice;
                            break;
                    }
                    updateTotal();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Debug.WriteLine("FailSafe");
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please input a numerical value");
                }
                else
                {
                    // the input is numeric 
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateTotal();
        }
        
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateTotal();
        }

        private void updateTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Price"].Value != null)
                {
                    total += Convert.ToInt32(row.Cells["Price"].Value);
                }
            }
            label2.Text = $"Total: {total}";
        }
    }
}